using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inspinia.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class ServicePermissionsController : Controller
    {
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new ServicePermissionsIndexVm
            {
                ServicePermissions = new List<ServicePermission>
                {
                    new ServicePermission
                    {
                        Id = 1,
                        PrincipleName = "صلاحيات خدمات العملاء",
                        Description = "تحديد الخدمات التي يمكن للعملاء الوصول إليها",
                        Conditions = "تحديد الخدمات حسب نوع العميل",
                        CreateDate = DateTime.Now.AddDays(-30),
                        UpdateDate = DateTime.Now.AddDays(-30),
                        Status = 1,
                        Notes = "للحالات العNormals",
                        Services = GenerateSampleServices(1)
                    },
                    new ServicePermission
                    {
                        Id = 2,
                        PrincipleName = "صلاحيات خدمات الوكلاء",
                        Description = "تحديد الخدمات التي يمكن للوكلاء الوصول إليها",
                        Conditions = "تحديد الخدمات حسب تصنيف الوكيل",
                        CreateDate = DateTime.Now.AddDays(-29),
                        UpdateDate = DateTime.Now.AddDays(-29),
                        Status = 1,
                        Notes = "للعملاء المميزين",
                        Services = GenerateSampleServices(2)
                    },
                    new ServicePermission
                    {
                        Id = 3,
                        PrincipleName = "صلاحيات خدمات خاصة",
                        Description = "تحديد الخدمات الخاصة التي يمكن الوصول إليها",
                        Conditions = "تحديد الخدمات الخاصة حسب الطلب",
                        CreateDate = DateTime.Now.AddDays(-28),
                        UpdateDate = DateTime.Now.AddDays(-28),
                        Status = 1,
                        Notes = "للعملاء الكبار",
                        Services = GenerateSampleServices(3)
                    }
                }
            };

            return View(viewModel);
        }

        private List<ServiceInfo> GenerateSampleServices(int permissionId)
        {
            var services = new List<ServiceInfo>();
            var random = new Random(permissionId); // Use permissionId as seed for variation
            
            // Sample service names
            var serviceNames = new string[] {
                "يمن موبايل مباشر", "التحويل من رصيد التأمين", "الخزنة", "التغذية عبر الكريمي",
                "التغذية عبر كاش", "التغذية عبر فلوسك", "التغذية عبر جوالي", "التغذية عبر بنك الامل",
                "التغذية عبر جيب", "التغذية عبر سبا كاش", "تسديد رصيد موبايل", "رصيد وباقة",
                "تسديد الانترنت ADSL", "تسديد الهاتف الثابت", "بدل فاقد يمن موبايل", "شريحة جديد موبايل",
                "شحن فوري تجزئة يمن موبايل", "شحن فوري تجزئة سبافون", "شحن فوري تجزئة MTN", "شحن فوري تجزئة واي"
            };

            for (int i = 1; i <= serviceNames.Length; i++)
            {
                services.Add(new ServiceInfo
                {
                    Id = i,
                    Name = serviceNames[i-1],
                    IsEnabled = random.Next(0, 2) == 1, // Randomly enable/disable services
                    Category = i <= 10 ? "تحويلات" : "فواتير"
                });
            }

            return services;
        }
    }
}