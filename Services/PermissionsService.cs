using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ASP.Net_Core_MVC.Full.Models;

namespace Inspinia.Services
{
    /// <summary>
    /// خدمة إدارة الصلاحيات - تحميل البيانات من ملف JSON بدلاً من الكود المباشر
    /// </summary>
    public class PermissionsService
    {
        private readonly string _dataPath;
        private List<PagePermissionVm> _cachedPermissions;

        public PermissionsService()
        {
            _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "PermissionsData.json");
        }

        /// <summary>
        /// تحميل جميع الصلاحيات من ملف JSON
        /// </summary>
        /// <returns>قائمة الصلاحيات</returns>
        public List<PagePermissionVm> GetAllPermissions()
        {
            if (_cachedPermissions != null)
                return _cachedPermissions;

            try
            {
                if (!File.Exists(_dataPath))
                {
                    // إنشاء ملف افتراضي إذا لم يكن موجوداً
                    CreateDefaultPermissionsFile();
                }

                var jsonContent = File.ReadAllText(_dataPath);
                var permissionsData = JsonSerializer.Deserialize<List<PermissionData>>(jsonContent, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                _cachedPermissions = ConvertToPagePermissionVm(permissionsData);
                return _cachedPermissions;
            }
            catch (Exception ex)
            {
                // في حالة الخطأ، إرجاع قائمة افتراضية
                Console.WriteLine($"خطأ في تحميل الصلاحيات: {ex.Message}");
                return GetDefaultPermissions();
            }
        }

        /// <summary>
        /// تحويل بيانات JSON إلى نموذج PagePermissionVm
        /// </summary>
        private List<PagePermissionVm> ConvertToPagePermissionVm(List<PermissionData> permissionsData)
        {
            var result = new List<PagePermissionVm>();

            foreach (var data in permissionsData)
            {
                var options = new List<PermissionOptionVm>();
                foreach (var option in data.Options)
                {
                    options.Add(new PermissionOptionVm
                    {
                        Key = option.Key,
                        DisplayName = option.DisplayName,
                        IsSelected = option.IsSelected
                    });
                }

                result.Add(new PagePermissionVm
                {
                    PageKey = data.PageKey,
                    PageTitle = data.PageTitle,
                    Options = options
                });
            }

            return result;
        }

        /// <summary>
        /// إنشاء ملف صلاحيات افتراضي
        /// </summary>
        private void CreateDefaultPermissionsFile()
        {
            var defaultPermissions = GetDefaultPermissionsData();
            var jsonContent = JsonSerializer.Serialize(defaultPermissions, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });

            Directory.CreateDirectory(Path.GetDirectoryName(_dataPath));
            File.WriteAllText(_dataPath, jsonContent);
        }

        /// <summary>
        /// الحصول على صلاحيات افتراضية في حالة الخطأ
        /// </summary>
        private List<PagePermissionVm> GetDefaultPermissions()
        {
            return new List<PagePermissionVm>
            {
                new PagePermissionVm
                {
                    PageKey = "employees",
                    PageTitle = "الموظفين",
                    Options = new List<PermissionOptionVm>
                    {
                        new PermissionOptionVm { Key = "selectEmployeesAll", DisplayName = "تحديد الكل", IsSelected = true },
                        new PermissionOptionVm { Key = "viewEmployees", DisplayName = "مشاهدة", IsSelected = true },
                        new PermissionOptionVm { Key = "addEmployees", DisplayName = "اضافة", IsSelected = true },
                        new PermissionOptionVm { Key = "updateEmployees", DisplayName = "تحديث", IsSelected = false },
                        new PermissionOptionVm { Key = "deleteEmployees", DisplayName = "حذف", IsSelected = false }
                    }
                },
                new PagePermissionVm
                {
                    PageKey = "customers",
                    PageTitle = "العملاء",
                    Options = new List<PermissionOptionVm>
                    {
                        new PermissionOptionVm { Key = "selectCustomersAll", DisplayName = "تحديد الكل", IsSelected = true },
                        new PermissionOptionVm { Key = "viewCustomers", DisplayName = "مشاهدة", IsSelected = true },
                        new PermissionOptionVm { Key = "addCustomers", DisplayName = "اضافة", IsSelected = true },
                        new PermissionOptionVm { Key = "updateCustomers", DisplayName = "تحديث", IsSelected = false },
                        new PermissionOptionVm { Key = "deleteCustomers", DisplayName = "حذف", IsSelected = false }
                    }
                }
            };
        }

        /// <summary>
        /// بيانات الصلاحيات الافتراضية للإنشاء
        /// </summary>
        private List<PermissionData> GetDefaultPermissionsData()
        {
            return new List<PermissionData>
            {
                new PermissionData
                {
                    PageKey = "employees",
                    PageTitle = "الموظفين",
                    Options = new List<PermissionOptionData>
                    {
                        new PermissionOptionData { Key = "selectEmployeesAll", DisplayName = "تحديد الكل", IsSelected = true },
                        new PermissionOptionData { Key = "viewEmployees", DisplayName = "مشاهدة", IsSelected = true },
                        new PermissionOptionData { Key = "addEmployees", DisplayName = "اضافة", IsSelected = true },
                        new PermissionOptionData { Key = "updateEmployees", DisplayName = "تحديث", IsSelected = false },
                        new PermissionOptionData { Key = "deleteEmployees", DisplayName = "حذف", IsSelected = false }
                    }
                }
            };
        }

        /// <summary>
        /// حفظ الصلاحيات المحدثة
        /// </summary>
        public void SavePermissions(List<PagePermissionVm> permissions)
        {
            try
            {
                var permissionsData = new List<PermissionData>();
                
                foreach (var permission in permissions)
                {
                    var options = new List<PermissionOptionData>();
                    foreach (var option in permission.Options)
                    {
                        options.Add(new PermissionOptionData
                        {
                            Key = option.Key,
                            DisplayName = option.DisplayName,
                            IsSelected = option.IsSelected
                        });
                    }

                    permissionsData.Add(new PermissionData
                    {
                        PageKey = permission.PageKey,
                        PageTitle = permission.PageTitle,
                        Options = options
                    });
                }

                var jsonContent = JsonSerializer.Serialize(permissionsData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });

                File.WriteAllText(_dataPath, jsonContent);
                _cachedPermissions = null; // إعادة تعيين الكاش
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"فشل في حفظ الصلاحيات: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// إعادة تحميل الصلاحيات من الملف
        /// </summary>
        public void RefreshPermissions()
        {
            _cachedPermissions = null;
        }
    }

    /// <summary>
    /// نموذج بيانات الصلاحية للـ JSON
    /// </summary>
    public class PermissionData
    {
        public string PageKey { get; set; }
        public string PageTitle { get; set; }
        public List<PermissionOptionData> Options { get; set; }
    }

    /// <summary>
    /// نموذج بيانات خيار الصلاحية للـ JSON
    /// </summary>
    public class PermissionOptionData
    {
        public string Key { get; set; }
        public string DisplayName { get; set; }
        public bool IsSelected { get; set; }
    }
}
