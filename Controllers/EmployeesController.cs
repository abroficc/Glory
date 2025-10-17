using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ASP.Net_Core_MVC.Full.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            // Create sample data using the new ViewModel structure
            var vm = new EmployeesIndexVm
            {
                Employees = new List<EmployeeModel>
                {
                    new EmployeeModel
                    {
                        Id = 1,
                        FullName = "مازن الوشلي",
                        PhoneNumber = "782222855",
                        AccountId = 1,
                    },
                    new EmployeeModel
                    {
                        Id = 2,
                        FullName = "زكي الامين تلكيم",
                        PhoneNumber = "781500003",
                        AccountId = 2,
                    },
                    new EmployeeModel
                    {
                        Id = 3,
                        FullName = "فراس تلكيم",
                        PhoneNumber = "770700060",
                        AccountId = 3,
                    },
                    new EmployeeModel
                    {
                        Id = 4,
                        FullName = "المجد كاش",
                        PhoneNumber = "778855000",
                        AccountId = 4,
                    },
                    new EmployeeModel
                    {
                        Id = 5,
                        FullName = "الهليس الاتصالات",
                        PhoneNumber = "773338337",
                        AccountId = 5,
                    },
                    new EmployeeModel
                    {
                        Id = 6,
                        FullName = "اتصالاتي",
                        PhoneNumber = "777500400",
                        AccountId = 6,
                    },
                    new EmployeeModel
                    {
                        Id = 7,
                        FullName = "صنعاء كاش",
                        PhoneNumber = "770737222",
                        AccountId = 7,
                    },
                    new EmployeeModel
                    {
                        Id = 8,
                        FullName = "جرافيكول",
                        PhoneNumber = "739288888",
                        AccountId = 8,
                    },
                    new EmployeeModel
                    {
                        Id = 9,
                        FullName = "محمد عبدالرحمن يحيى الوشلي",
                        PhoneNumber = "777866739",
                        AccountId = 9,
                    },
                    new EmployeeModel
                    {
                        Id = 10,
                        FullName = "المنير",
                        PhoneNumber = "777813389",
                        AccountId = 10,
                    }
                },
                
                Permissions = new List<PermissionVm>
                {
                    new PermissionVm { Key = "viewCustomers", DisplayName = "مشاهدة", Group = "Customers" },
                    new PermissionVm { Key = "addCustomers", DisplayName = "اضافة", Group = "Customers" },
                    new PermissionVm { Key = "editCustomers", DisplayName = "تعديل", Group = "Customers" },
                    new PermissionVm { Key = "deleteCustomers", DisplayName = "حذف", Group = "Customers" },
                    new PermissionVm { Key = "viewEmployees", DisplayName = "مشاهدة", Group = "Employees" },
                    new PermissionVm { Key = "addEmployees", DisplayName = "اضافة", Group = "Employees" },
                    new PermissionVm { Key = "editEmployees", DisplayName = "تعديل", Group = "Employees" },
                    new PermissionVm { Key = "deleteEmployees", DisplayName = "حذف", Group = "Employees" }
                },
                
                Pages = new List<PagePermissionVm>
                {
                    new PagePermissionVm
                    {
                        PageKey = "customers",
                        PageTitle = "العملاء",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectCustomersAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteCustomers", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "viewCustomers", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "printCustomers", DisplayName = "طباعة", IsSelected = false },
                            new PermissionOptionVm { Key = "activateCustomers", DisplayName = "تفعيل", IsSelected = false },
                            new PermissionOptionVm { Key = "deactivateCustomers", DisplayName = "الغاء التفعيل", IsSelected = false },
                            new PermissionOptionVm { Key = "addCustomers", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "linkInsurance", DisplayName = "ربط بالتأمين", IsSelected = false },
                            new PermissionOptionVm { Key = "unlinkInsurance", DisplayName = "الغاء الربط بالتأمين", IsSelected = false },
                            new PermissionOptionVm { Key = "editCustomers", DisplayName = "تعديل", IsSelected = false },
                            new PermissionOptionVm { Key = "addLoan", DisplayName = "اضافة قرض", IsSelected = false },
                            new PermissionOptionVm { Key = "saveDeviceNumber", DisplayName = "حفظ رقم الجهاز", IsSelected = false },
                            new PermissionOptionVm { Key = "servicePermissions", DisplayName = "صلاحيات الخدمات", IsSelected = false },
                            new PermissionOptionVm { Key = "saveIP", DisplayName = "حفظ الايبي", IsSelected = false },
                            new PermissionOptionVm { Key = "grantAppFeature", DisplayName = "منح صلاحية ميزة تطبيقي", IsSelected = false },
                            new PermissionOptionVm { Key = "revokeAppFeature", DisplayName = "الغاء صلاحية ميزة تطبيقي", IsSelected = false },
                            new PermissionOptionVm { Key = "grantWhatsApp", DisplayName = "منح صلاحية واتسابي", IsSelected = false },
                            new PermissionOptionVm { Key = "revokeWhatsApp", DisplayName = "الغاء صلاحية واتسابي", IsSelected = false },
                            new PermissionOptionVm { Key = "requestWhatsAppCode", DisplayName = "طلب رمز سري واتسابي", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteLoan", DisplayName = "حذف القرض الي", IsSelected = false },
                            new PermissionOptionVm { Key = "viewAppCustomers", DisplayName = "مشاهدة عملاء تطبيقي", IsSelected = false },
                            new PermissionOptionVm { Key = "stopBestCustomerNotification", DisplayName = "ايقاف اشعار افضل عميل", IsSelected = false },
                            new PermissionOptionVm { Key = "chatUp", DisplayName = "شآت آب", IsSelected = false },
                            new PermissionOptionVm { Key = "grantAgentPasswordReset", DisplayName = "منح صلاحية استعادة كلمة السر للوكيل", IsSelected = false },
                            new PermissionOptionVm { Key = "revokeAgentPasswordReset", DisplayName = "الغاء صلاحية استعادة كلمة السر للوكيل", IsSelected = false },
                            new PermissionOptionVm { Key = "grantDistributorToCustomer", DisplayName = "منح صلاحية الموزع للعميل", IsSelected = false },
                            new PermissionOptionVm { Key = "saveDistributorRate", DisplayName = "حفظ نسبة الموزع", IsSelected = false },
                            new PermissionOptionVm { Key = "addToDistributor", DisplayName = "اضافة الى موزع", IsSelected = false },
                            new PermissionOptionVm { Key = "exportImportCustomerNumbers", DisplayName = "تصدير ارقام العملاء واسيرادها في الهاتف", IsSelected = false },
                            new PermissionOptionVm { Key = "sendWhatsAppMessages", DisplayName = "ارسال رسائل واتس للعملاء", IsSelected = false },
                            new PermissionOptionVm { Key = "addCustomersToCommissionGroups", DisplayName = "اضافة العملاء لمجموعات نسب العمولات", IsSelected = false },
                            new PermissionOptionVm { Key = "editRateGroup", DisplayName = "تعديل مجموعة التسعيرة", IsSelected = false },
                            new PermissionOptionVm { Key = "defineCustomersPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "employees",
                        PageTitle = "الموظفين",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectEmployeesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteEmployees", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "viewEmployees", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addEmployees", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "editEmployees", DisplayName = "تعديل", IsSelected = false },
                            new PermissionOptionVm { Key = "defineEmployeesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "services",
                        PageTitle = "الخدمات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectServicesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteServices", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "viewServices", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addServices", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "editServices", DisplayName = "تحرير", IsSelected = false },
                            new PermissionOptionVm { Key = "defineServicesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "data",
                        PageTitle = "البيانات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectDataAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "linkPreparation", DisplayName = "ربط للتجهيز", IsSelected = false },
                            new PermissionOptionVm { Key = "unlinkPreparation", DisplayName = "الغاء الربط", IsSelected = false },
                            new PermissionOptionVm { Key = "viewData", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "readyData", DisplayName = "جاهز", IsSelected = false },
                            new PermissionOptionVm { Key = "cancelOperation", DisplayName = "الغاء العملية", IsSelected = false },
                            new PermissionOptionVm { Key = "addAdvance", DisplayName = "اضافة سلفة", IsSelected = false },
                            new PermissionOptionVm { Key = "thisNumberBorrowed", DisplayName = "هذا الرقم متسلف", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteData", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "cancelReadiness", DisplayName = "الغاء الجاهزية", IsSelected = false },
                            new PermissionOptionVm { Key = "addData", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "returnOperation", DisplayName = "ارجاع العملية", IsSelected = false },
                            new PermissionOptionVm { Key = "setPrice", DisplayName = "تحديد السعر", IsSelected = false },
                            new PermissionOptionVm { Key = "messageData", DisplayName = "مراسلة", IsSelected = false },
                            new PermissionOptionVm { Key = "addAmount", DisplayName = "اضافة مبلغ", IsSelected = false },
                            new PermissionOptionVm { Key = "printData", DisplayName = "طباعة", IsSelected = false },
                            new PermissionOptionVm { Key = "editCustomerName", DisplayName = "تعديل اسم العميل", IsSelected = false },
                            new PermissionOptionVm { Key = "cancelRelatedOperations", DisplayName = "الغاء العمليات فقط المرتبطه في ا لموظف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineDataPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "insuranceAmounts",
                        PageTitle = "مبالغ التأمين",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectInsuranceAmountsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteInsuranceAmounts", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "addInsuranceAmounts", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "viewInsuranceAmounts", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateInsuranceAmounts", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "updateSource", DisplayName = "تحديث المصدر", IsSelected = false },
                            new PermissionOptionVm { Key = "bulkUpdateSource", DisplayName = "التحديث الجماعي للمصدر الحسابي", IsSelected = false },
                            new PermissionOptionVm { Key = "updateSourceAllTimes", DisplayName = "تحديث المصدر في كل الاوقات", IsSelected = false },
                            new PermissionOptionVm { Key = "updateDataAllTimes", DisplayName = "تحديث البيان في كل الاوقات", IsSelected = false },
                            new PermissionOptionVm { Key = "updateData", DisplayName = "تحديث البيان", IsSelected = false },
                            new PermissionOptionVm { Key = "reverseInsuranceAmount", DisplayName = "عكس مبلغ التأمين", IsSelected = false },
                            new PermissionOptionVm { Key = "addNonTodayDate", DisplayName = "اضافة بتأريخ غير تاريخ اليوم", IsSelected = false },
                            new PermissionOptionVm { Key = "defineInsuranceAmountsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "packages",
                        PageTitle = "باقات الشرايح",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectPackagesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "addPackages", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "viewPackages", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "deletePackages", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "definePackagesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "numbers",
                        PageTitle = "ارقام الشرايح",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectNumbersAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewNumbers", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteNumbers", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "deliverContracts", DisplayName = "تسليم العقود", IsSelected = false },
                            new PermissionOptionVm { Key = "addNumbersFromCustomerAccount", DisplayName = "اضافه شرائح فقط من حساب عميل", IsSelected = false },
                            new PermissionOptionVm { Key = "defineNumbersPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "invoices",
                        PageTitle = "الفواتير",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectInvoicesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewInvoices", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "viewInvoiceData", DisplayName = "مشاهدة البيانات", IsSelected = false },
                            new PermissionOptionVm { Key = "defineInvoicesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "customerJournals",
                        PageTitle = "يوميات العملاء",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectCustomerJournalsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewCustomerJournals", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addCustomerJournals", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateCustomerJournals", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteCustomerJournals", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "editCustomerJournalsSameDay", DisplayName = "تعديل في نفس اليوم", IsSelected = false },
                            new PermissionOptionVm { Key = "addCustomerJournalsNonTodayDate", DisplayName = "اضافه بتاريخ غير تاريخ اليوم", IsSelected = false },
                            new PermissionOptionVm { Key = "defineCustomerJournalsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "employeeJournals",
                        PageTitle = "يوميات الموظفين",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectEmployeeJournalsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewEmployeeJournals", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addEmployeeJournals", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateEmployeeJournals", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteEmployeeJournals", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineEmployeeJournalsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "customerEmployeeActivities",
                        PageTitle = "أنشطة للعملاء والموظفين",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectCustomerEmployeeActivitiesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewCustomerEmployeeActivities", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addCustomerEmployeeActivities", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateCustomerEmployeeActivities", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteCustomerEmployeeActivities", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineCustomerEmployeeActivitiesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "companyBranches",
                        PageTitle = "فروع الشركة",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectCompanyBranchesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewCompanyBranches", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addCompanyBranches", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateCompanyBranches", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteCompanyBranches", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineCompanyBranchesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "internetPackages",
                        PageTitle = "باقات الانترنت",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectInternetPackagesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewInternetPackages", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addInternetPackages", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateInternetPackages", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteInternetPackages", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineInternetPackagesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "accountTree",
                        PageTitle = "شجرة الحسابات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectAccountTreeAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewAccountTree", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addAccountTree", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateAccountTree", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteAccountTree", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineAccountTreePrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "advertisements",
                        PageTitle = "الاعلانات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectAdvertisementsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewAdvertisements", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addAdvertisements", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateAdvertisements", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteAdvertisements", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineAdvertisementsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "youCategories",
                        PageTitle = "فئات يو YOU",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectYouCategoriesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewYouCategories", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addYouCategories", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateYouCategories", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteYouCategories", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineYouCategoriesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "sabafon",
                        PageTitle = "سبأفون",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectSabafonAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewSabafon", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addSabafon", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateSabafon", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteSabafon", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineSabafonPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "yemenMobile",
                        PageTitle = "يمن موبايل",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectYemenMobileAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewYemenMobile", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addYemenMobile", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateYemenMobile", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteYemenMobile", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineYemenMobilePrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "wholesaleRate",
                        PageTitle = "نسبة الجملة",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectWholesaleRateAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewWholesaleRate", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addWholesaleRate", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateWholesaleRate", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteWholesaleRate", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineWholesaleRatePrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "wifi",
                        PageTitle = "واي",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectWifiAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewWifi", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addWifi", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateWifi", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteWifi", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineWifiPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "serviceCategories",
                        PageTitle = "فئات الخدمات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectServiceCategoriesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewServiceCategories", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addServiceCategories", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateServiceCategories", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteServiceCategories", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineServiceCategoriesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "moneyTransferCommission",
                        PageTitle = "عمولة الحوالات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectMoneyTransferCommissionAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewMoneyTransferCommission", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addMoneyTransferCommission", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateMoneyTransferCommission", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteMoneyTransferCommission", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineMoneyTransferCommissionPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "youPackages",
                        PageTitle = "باقات YOU",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectYouPackagesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewYouPackages", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addYouPackages", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateYouPackages", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteYouPackages", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "importYouPackages", DisplayName = "استيراد", IsSelected = false },
                            new PermissionOptionVm { Key = "defineYouPackagesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "wifiCategories",
                        PageTitle = "فئات Wifi",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectWifiCategoriesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewWifiCategories", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addWifiCategories", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateWifiCategories", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteWifiCategories", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineWifiCategoriesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "wifiCards",
                        PageTitle = "كروت Wifi",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectWifiCardsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewWifiCards", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addWifiCards", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateWifiCards", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteWifiCards", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineWifiCardsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "purchaseReturns",
                        PageTitle = "مرتجع مشتريات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectPurchaseReturnsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewPurchaseReturns", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addPurchaseReturns", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updatePurchaseReturns", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deletePurchaseReturns", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "editPurchaseReturnsSameDay", DisplayName = "تعديل في نفس اليوم", IsSelected = false },
                            new PermissionOptionVm { Key = "definePurchaseReturnsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "salesReturns",
                        PageTitle = "مرتجع مبيعات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectSalesReturnsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewSalesReturns", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addSalesReturns", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateSalesReturns", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteSalesReturns", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "editSalesReturnsSameDay", DisplayName = "تعديل في نفس اليوم", IsSelected = false },
                            new PermissionOptionVm { Key = "defineSalesReturnsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "productFeatures",
                        PageTitle = "خصائص المنتجات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectProductFeaturesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewProductFeatures", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addProductFeatures", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateProductFeatures", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteProductFeatures", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineProductFeaturesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "openingBalances",
                        PageTitle = "الارصدة الافتتاحية",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectOpeningBalancesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewOpeningBalances", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addOpeningBalances", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateOpeningBalances", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteOpeningBalances", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineOpeningBalancesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "distributorCommissions",
                        PageTitle = "عمولات الموزعين",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectDistributorCommissionsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewDistributorCommissions", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addDistributorCommissions", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteDistributorCommissions", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineDistributorCommissionsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "surveys",
                        PageTitle = "الاستبيانات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectSurveysAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewSurveys", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addSurveys", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteSurveys", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineSurveysPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "surveyNotes",
                        PageTitle = "ملاحظات الاستبيانات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectSurveyNotesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewSurveyNotes", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteSurveyNotes", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineSurveyNotesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "telegramChannelsBots",
                        PageTitle = "قنوات وبوت التليجرام",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectTelegramChannelsBotsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewTelegramChannelsBots", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addTelegramChannelsBots", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateTelegramChannelsBots", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteTelegramChannelsBots", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "startTelegramChannelsBots", DisplayName = "تشغيل", IsSelected = false },
                            new PermissionOptionVm { Key = "stopTelegramChannelsBots", DisplayName = "ايقاف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineTelegramChannelsBotsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "telegramSubscribers",
                        PageTitle = "مشتركين التليجرام",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectTelegramSubscribersAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewTelegramSubscribers", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteTelegramSubscribers", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineTelegramSubscribersPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "cardCurrencyGuides",
                        PageTitle = "دليل عملات الكروت",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectCardCurrencyGuidesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewCardCurrencyGuides", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addCardCurrencyGuides", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateCardCurrencyGuides", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteCardCurrencyGuides", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineCardCurrencyGuidesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "additionalCommissions",
                        PageTitle = "عمولات اضافية",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectAdditionalCommissionsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewAdditionalCommissions", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addAdditionalCommissions", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateAdditionalCommissions", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteAdditionalCommissions", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineAdditionalCommissionsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "subscriptions",
                        PageTitle = "اشتراكات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectSubscriptionsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewSubscriptions", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addSubscriptions", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateSubscriptions", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteSubscriptions", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineSubscriptionsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "gameCategories",
                        PageTitle = "فئات الالعاب",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectGameCategoriesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewGameCategories", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addGameCategories", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateGameCategories", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteGameCategories", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "importGames", DisplayName = "استيراد الالعاب", IsSelected = false },
                            new PermissionOptionVm { Key = "defineGameCategoriesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "whatsappMessageFormats",
                        PageTitle = "تنسيق رسائل الواتس",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectWhatsappMessageFormatsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewWhatsappMessageFormats", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addWhatsappMessageFormats", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateWhatsappMessageFormats", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteWhatsappMessageFormats", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineWhatsappMessageFormatsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "whatsappSmartReplies",
                        PageTitle = "ردود الواتس الذكية",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectWhatsappSmartRepliesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewWhatsappSmartReplies", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addWhatsappSmartReplies", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateWhatsappSmartReplies", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteWhatsappSmartReplies", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineWhatsappSmartRepliesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "employeeLockers",
                        PageTitle = "سقوف الموظفين",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectEmployeeLockersAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewEmployeeLockers", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addEmployeeLockers", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateEmployeeLockers", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteEmployeeLockers", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineEmployeeLockersPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "whatsappMarketing",
                        PageTitle = "واتساب تسويق",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectWhatsappMarketingAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewWhatsappMarketing", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addWhatsappMarketing", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteWhatsappMarketing", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineWhatsappMarketingPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "socialMediaFeeds",
                        PageTitle = "التغذية عبر الشبكات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectSocialMediaFeedsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewSocialMediaFeeds", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addSocialMediaFeeds", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteSocialMediaFeeds", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "addAmountToCustomerAccount", DisplayName = "اضافة المبلغ لحساب العميل", IsSelected = false },
                            new PermissionOptionVm { Key = "resendToWhatsapp", DisplayName = "اعادة ارسال للواتس", IsSelected = false },
                            new PermissionOptionVm { Key = "defineSocialMediaFeedsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "verifiedCustomers",
                        PageTitle = "العملاء الموثقين",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectVerifiedCustomersAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewVerifiedCustomers", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addVerifiedCustomers", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateVerifiedCustomers", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteVerifiedCustomers", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineVerifiedCustomersPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "banksAndFeedingNetworks",
                        PageTitle = "بنوك وشبكات التغذية",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectBanksAndFeedingNetworksAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewBanksAndFeedingNetworks", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addBanksAndFeedingNetworks", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateBanksAndFeedingNetworks", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteBanksAndFeedingNetworks", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineBanksAndFeedingNetworksPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "atmMachines",
                        PageTitle = "أجهزة شركات الصرافة",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectAtmMachinesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewAtmMachines", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addAtmMachines", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateAtmMachines", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteAtmMachines", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineAtmMachinesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "rateGroups",
                        PageTitle = "مجموعات النسب",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectRateGroupsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewRateGroups", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addRateGroups", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateRateGroups", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteRateGroups", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineRateGroupsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "dailyCommissions",
                        PageTitle = "العمولات اليومية",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectDailyCommissionsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewDailyCommissions", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteDailyCommissions", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineDailyCommissionsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "monthlyCommissions",
                        PageTitle = "العمولات الشهرية",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectMonthlyCommissionsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewMonthlyCommissions", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteMonthlyCommissions", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "exportMonthlyCommissions", DisplayName = "اخراج العمولة الشهرية", IsSelected = false },
                            new PermissionOptionVm { Key = "defineMonthlyCommissionsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "electricityAreas",
                        PageTitle = "مناطق الكهرباء",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectElectricityAreasAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewElectricityAreas", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addElectricityAreas", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateElectricityAreas", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteElectricityAreas", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineElectricityAreasPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "waterAreas",
                        PageTitle = "مناطق الماء",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectWaterAreasAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewWaterAreas", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addWaterAreas", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateWaterAreas", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteWaterAreas", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineWaterAreasPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "devices1",
                        PageTitle = "اجهزة",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectDevices1All", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewDevices1", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addDevices1", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateDevices1", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteDevices1", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineDevices1PrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "devices2",
                        PageTitle = "اجهزة",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectDevices2All", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewDevices2", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addDevices2", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateDevices2", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteDevices2", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineDevices2PrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "rateByAmount",
                        PageTitle = "نسب التسعيرة حسب المبلغ",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectRateByAmountAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewRateByAmount", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addRateByAmount", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateRateByAmount", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteRateByAmount", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineRateByAmountPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "devices3",
                        PageTitle = "أجهزة",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectDevices3All", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewDevices3", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addDevices3", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateDevices3", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteDevices3", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineDevices3PrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "yemenForjiPackages",
                        PageTitle = "باقات يمن فورجي",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectYemenForjiPackagesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewYemenForjiPackages", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addYemenForjiPackages", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateYemenForjiPackages", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteYemenForjiPackages", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineYemenForjiPackagesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "wifiPackages",
                        PageTitle = "باقات واي",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectWifiPackagesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewWifiPackages", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addWifiPackages", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateWifiPackages", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteWifiPackages", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "importWifiPackages", DisplayName = "استيراد", IsSelected = false },
                            new PermissionOptionVm { Key = "defineWifiPackagesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "wifiNetworks",
                        PageTitle = "شبكات WIFI",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectWifiNetworksAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewWifiNetworks", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addWifiNetworks", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateWifiNetworks", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteWifiNetworks", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineWifiNetworksPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "currencies",
                        PageTitle = "العملات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectCurrenciesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewCurrencies", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addCurrencies", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateCurrencies", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteCurrencies", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineCurrenciesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "cities",
                        PageTitle = "المدن",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectCitiesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewCities", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addCities", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateCities", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteCities", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineCitiesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "transportationCompanies",
                        PageTitle = "شركات النقل",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectTransportationCompaniesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewTransportationCompanies", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addTransportationCompanies", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateTransportationCompanies", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteTransportationCompanies", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineTransportationCompaniesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "ticketPrices",
                        PageTitle = "اسعار التذاكر",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectTicketPricesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewTicketPrices", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addTicketPrices", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateTicketPrices", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteTicketPrices", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineTicketPricesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "moneyTransferCompanies",
                        PageTitle = "شركات الحوالات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectMoneyTransferCompaniesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewMoneyTransferCompanies", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addMoneyTransferCompanies", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateMoneyTransferCompanies", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteMoneyTransferCompanies", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineMoneyTransferCompaniesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "specialNumbers",
                        PageTitle = "الارقام المميزة",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectSpecialNumbersAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewSpecialNumbers", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addSpecialNumbers", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateSpecialNumbers", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteSpecialNumbers", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineSpecialNumbersPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "networkCards",
                        PageTitle = "كروت الشبكات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectNetworkCardsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewNetworkCards", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addNetworkCards", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateNetworkCards", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteNetworkCards", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineNetworkCardsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "sabafonPackages",
                        PageTitle = "باقات سبافون",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectSabafonPackagesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewSabafonPackages", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addSabafonPackages", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateSabafonPackages", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteSabafonPackages", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "importSabafonPackages", DisplayName = "استيراد", IsSelected = false },
                            new PermissionOptionVm { Key = "defineSabafonPackagesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "yemenMobilePackages",
                        PageTitle = "باقات يمن موبايل",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectYemenMobilePackagesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewYemenMobilePackages", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addYemenMobilePackages", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateYemenMobilePackages", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteYemenMobilePackages", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "importYemenMobilePackages", DisplayName = "استيراد", IsSelected = false },
                            new PermissionOptionVm { Key = "defineYemenMobilePackagesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "internetCategories",
                        PageTitle = "فئات الانترنت",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectInternetCategoriesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewInternetCategories", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addInternetCategories", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateInternetCategories", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteInternetCategories", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineInternetCategoriesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "dataCategories",
                        PageTitle = "فئات النت ريال",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectDataCategoriesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewDataCategories", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addDataCategories", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateDataCategories", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteDataCategories", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineDataCategoriesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "landlineCategories",
                        PageTitle = "فئات الثابت",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectLandlineCategoriesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewLandlineCategories", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addLandlineCategories", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateLandlineCategories", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteLandlineCategories", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineLandlineCategoriesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "robots",
                        PageTitle = "روبوتات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectRobotsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewRobots", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateRobots", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteRobots", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "runRobots", DisplayName = "تشغيل", IsSelected = false },
                            new PermissionOptionVm { Key = "stopRobots", DisplayName = "توقيف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineRobotsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "commissions",
                        PageTitle = "العمولات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectCommissionsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewCommissions", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteCommissions", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineCommissionsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "systemLinks",
                        PageTitle = "ربطيات الانظمة",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectSystemLinksAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewSystemLinks", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addSystemLinks", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateSystemLinks", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteSystemLinks", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "viewUpdatePassword", DisplayName = "مشاهدة وتعديل كلمة السر", IsSelected = false },
                            new PermissionOptionVm { Key = "viewUpdateUsername", DisplayName = "مشاهدة وتعديل اسم الدخول", IsSelected = false },
                            new PermissionOptionVm { Key = "runSystemLink", DisplayName = "تشغيل الربطية", IsSelected = false },
                            new PermissionOptionVm { Key = "stopSystemLink", DisplayName = "ايقاف الربطية", IsSelected = false },
                            new PermissionOptionVm { Key = "orderSystemLinks", DisplayName = "ترتيب الربطيات", IsSelected = false },
                            new PermissionOptionVm { Key = "balanceInquiry", DisplayName = "استعلام عن الرصيد", IsSelected = false },
                            new PermissionOptionVm { Key = "runNetwork", DisplayName = "تشغيل الشبكة", IsSelected = false },
                            new PermissionOptionVm { Key = "stopNetwork", DisplayName = "ايقاف الشبكة", IsSelected = false },
                            new PermissionOptionVm { Key = "defineSystemLinksPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "basicSettings",
                        PageTitle = "الاعدادات الاساسية",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectBasicSettingsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewBasicSettings", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addBasicSettings", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateBasicSettings", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteBasicSettings", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineBasicSettingsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "rateGroups",
                        PageTitle = "مجموعات التسعيرة",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectRateGroupsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewRateGroups", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addRateGroups", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateRateGroups", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteRateGroups", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineRateGroupsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "devices",
                        PageTitle = "الاجهزة",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectDevicesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewDevices", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateDevices", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteDevices", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineDevicesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "responses",
                        PageTitle = "الردود",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectResponsesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewResponses", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteResponses", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "updateResponses", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "defineResponsesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "accountingConstraints",
                        PageTitle = "القيود الحسابية",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectAccountingConstraintsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewAccountingConstraints", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addAccountingConstraints", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateAccountingConstraints", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteAccountingConstraints", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "totalAmounts", DisplayName = "اجمالي المبالغ", IsSelected = false },
                            new PermissionOptionVm { Key = "defineAccountingConstraintsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "smsMessages",
                        PageTitle = "الرسائل النصية",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectSmsMessagesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewSmsMessages", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addSmsMessages", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteSmsMessages", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineSmsMessagesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "paymentDistribution",
                        PageTitle = "مبدأ توزيع التسديدات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectPaymentDistributionAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewPaymentDistribution", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addPaymentDistribution", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updatePaymentDistribution", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deletePaymentDistribution", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "definePaymentDistributionPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "employeeDevices",
                        PageTitle = "اجهزة الموظفين",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectEmployeeDevicesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewEmployeeDevices", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addEmployeeDevices", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateEmployeeDevices", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteEmployeeDevices", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineEmployeeDevicesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "customerWebDevices",
                        PageTitle = "اجهزة العملاء ويب",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectCustomerWebDevicesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewCustomerWebDevices", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addCustomerWebDevices", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateCustomerWebDevices", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteCustomerWebDevices", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineCustomerWebDevicesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "storeCategories",
                        PageTitle = "أصناف المتجر",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectStoreCategoriesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewStoreCategories", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addStoreCategories", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateStoreCategories", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteStoreCategories", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineStoreCategoriesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "products",
                        PageTitle = "المنتجات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectProductsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewProducts", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addProducts", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateProducts", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteProducts", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineProductsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "sales",
                        PageTitle = "المبيعات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectSalesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewSales", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteSales", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineSalesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "merchantSettings",
                        PageTitle = "اعدادات التجار",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectMerchantSettingsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewMerchantSettings", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addMerchantSettings", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateMerchantSettings", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteMerchantSettings", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineMerchantSettingsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "incomingSettings",
                        PageTitle = "الاعدادات الواردة",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectIncomingSettingsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewIncomingSettings", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addIncomingSettings", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateIncomingSettings", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteIncomingSettings", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineIncomingSettingsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "blackList",
                        PageTitle = "القائمة السوداء",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectBlackListAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewBlackList", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addBlackList", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateBlackList", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteBlackList", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineBlackListPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "sabafonSouthPackages",
                        PageTitle = "باقات سبأفون جنوب",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectSabafonSouthPackagesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewSabafonSouthPackages", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addSabafonSouthPackages", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateSabafonSouthPackages", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteSabafonSouthPackages", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineSabafonSouthPackagesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "sabafonSouth",
                        PageTitle = "سبأفون جنوب",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectSabafonSouthAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewSabafonSouth", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addSabafonSouth", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateSabafonSouth", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteSabafonSouth", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineSabafonSouthPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "saddlyRequests",
                        PageTitle = "طلبات سددلي",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectSaddlyRequestsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewSaddlyRequests", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addSaddlyRequests", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateSaddlyRequests", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteSaddlyRequests", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineSaddlyRequestsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "saddlyOperations",
                        PageTitle = "عمليات سددلي",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectSaddlyOperationsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewSaddlyOperations", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateSaddlyOperations", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "defineSaddlyOperationsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "paymentSuspensionRescue",
                        PageTitle = "مبدأ انقاذ تعليق السداد",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectPaymentSuspensionRescueAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewPaymentSuspensionRescue", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addPaymentSuspensionRescue", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updatePaymentSuspensionRescue", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deletePaymentSuspensionRescue", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "definePaymentSuspensionRescuePrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "adenNet",
                        PageTitle = "عدن نت",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectAdenNetAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewAdenNet", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addAdenNet", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateAdenNet", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteAdenNet", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineAdenNetPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "customerInquiries",
                        PageTitle = "استعلامات العملاء",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectCustomerInquiriesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewCustomerInquiries", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteCustomerInquiries", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineCustomerInquiriesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "serviceManagement",
                        PageTitle = "ادارة الخدمات مباشر|يدوي",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectServiceManagementAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewServiceManagement", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addServiceManagement", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateServiceManagement", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteServiceManagement", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineServiceManagementPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "rialCardsDirect",
                        PageTitle = "شرائح الريال (مباشر)",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectRialCardsDirectAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewRialCardsDirect", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addRialCardsDirect", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateRialCardsDirect", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteRialCardsDirect", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineRialCardsDirectPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "paymentOperationsViaMessages",
                        PageTitle = "عمليات التسديد عبر الرسائل",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectPaymentOperationsViaMessagesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewPaymentOperationsViaMessages", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "definePaymentOperationsViaMessagesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "customerSummary",
                        PageTitle = "حصالة العملاء",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectCustomerSummaryAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewCustomerSummary", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "defineCustomerSummaryPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "balanceRechargeCards",
                        PageTitle = "كروت تغذية الرصيد",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectBalanceRechargeCardsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewBalanceRechargeCards", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addBalanceRechargeCards", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteBalanceRechargeCards", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineBalanceRechargeCardsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "comprehensiveCardRequests",
                        PageTitle = "طلبات الكروت الشاملة",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectComprehensiveCardRequestsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewComprehensiveCardRequests", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "defineComprehensiveCardRequestsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "providerCosts",
                        PageTitle = "تكلفة المزودين",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectProviderCostsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewProviderCosts", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addProviderCosts", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateProviderCosts", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteProviderCosts", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineProviderCostsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "electricityCompaniesDirectory",
                        PageTitle = "دليل شركات الكهرباء",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectElectricityCompaniesDirectoryAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewElectricityCompaniesDirectory", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addElectricityCompaniesDirectory", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateElectricityCompaniesDirectory", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteElectricityCompaniesDirectory", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineElectricityCompaniesDirectoryPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "competitions",
                        PageTitle = "المسابقات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectCompetitionsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewCompetitions", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addCompetitions", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateCompetitions", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteCompetitions", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineCompetitionsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "participantSubmissions",
                        PageTitle = "مشاركات المتسابقين",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectParticipantSubmissionsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewParticipantSubmissions", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteParticipantSubmissions", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineParticipantSubmissionsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "rialCardFeedingSettings",
                        PageTitle = "اعدادات تغذية شرائح الريال",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectRialCardFeedingSettingsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewRialCardFeedingSettings", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addRialCardFeedingSettings", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateRialCardFeedingSettings", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteRialCardFeedingSettings", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineRialCardFeedingSettingsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "deepMobileDevices",
                        PageTitle = "اجهزة عمقي جوال",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectDeepMobileDevicesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewDeepMobileDevices", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addDeepMobileDevices", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateDeepMobileDevices", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteDeepMobileDevices", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineDeepMobileDevicesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "proDistributionPrinciple",
                        PageTitle = "مبدأ التوزيع برو",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectProDistributionPrincipleAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewProDistributionPrinciple", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addProDistributionPrinciple", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateProDistributionPrinciple", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteProDistributionPrinciple", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineProDistributionPrinciplePrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "appInterfaceDesigns",
                        PageTitle = "تصاميم واجهات التطبيق",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectAppInterfaceDesignsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewAppInterfaceDesigns", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addAppInterfaceDesigns", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateAppInterfaceDesigns", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteAppInterfaceDesigns", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineAppInterfaceDesignsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "designYourOwnApp",
                        PageTitle = "صمم تطبيقك بنفسك",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectDesignYourOwnAppAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewDesignYourOwnApp", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addDesignYourOwnApp", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateDesignYourOwnApp", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteDesignYourOwnApp", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineDesignYourOwnAppPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "warehouses",
                        PageTitle = "المخازن",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectWarehousesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewWarehouses", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addWarehouses", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateWarehouses", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteWarehouses", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineWarehousesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "items",
                        PageTitle = "الاصناف",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectItemsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewItems", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addItems", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateItems", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteItems", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineItemsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "failedLoginAttempts",
                        PageTitle = "محاولات الدخول الخاطئة",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectFailedLoginAttemptsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewFailedLoginAttempts", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteFailedLoginAttempts", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineFailedLoginAttemptsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "purchaseInvoices",
                        PageTitle = "فواتير الشراء",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectPurchaseInvoicesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewPurchaseInvoices", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addPurchaseInvoices", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updatePurchaseInvoices", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deletePurchaseInvoices", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "generateAutomaticInvoices", DisplayName = "توليد الفواتير الاليه", IsSelected = false },
                            new PermissionOptionVm { Key = "editSameDay", DisplayName = "تعديل في نفس اليوم", IsSelected = false },
                            new PermissionOptionVm { Key = "definePurchaseInvoicesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "salesInvoices",
                        PageTitle = "فواتير البيع",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectSalesInvoicesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewSalesInvoices", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addSalesInvoices", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateSalesInvoices", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteSalesInvoices", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "editSameDay", DisplayName = "تعديل في نفس اليوم", IsSelected = false },
                            new PermissionOptionVm { Key = "defineSalesInvoicesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "purchaseReturns",
                        PageTitle = "مرتجع مشتريات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectPurchaseReturnsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewPurchaseReturns", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addPurchaseReturns", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updatePurchaseReturns", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deletePurchaseReturns", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "editSameDayPurchaseReturns", DisplayName = "تعديل في نفس اليوم", IsSelected = false },
                            new PermissionOptionVm { Key = "definePurchaseReturnsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "salesReturns",
                        PageTitle = "مرتجع مبيعات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectSalesReturnsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewSalesReturns", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addSalesReturns", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateSalesReturns", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteSalesReturns", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "editSameDaySalesReturns", DisplayName = "تعديل في نفس اليوم", IsSelected = false },
                            new PermissionOptionVm { Key = "defineSalesReturnsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "productAttributes",
                        PageTitle = "خصائص المنتجات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectProductAttributesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewProductAttributes", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addProductAttributes", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateProductAttributes", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteProductAttributes", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineProductAttributesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "openingBalances",
                        PageTitle = "الارصدة الافتتاحية",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectOpeningBalancesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewOpeningBalances", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addOpeningBalances", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateOpeningBalances", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteOpeningBalances", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineOpeningBalancesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "distributorCommissions",
                        PageTitle = "عمولات الموزعين",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectDistributorCommissionsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewDistributorCommissions", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addDistributorCommissions", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteDistributorCommissions", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineDistributorCommissionsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "surveys",
                        PageTitle = "الاستبيانات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectSurveysAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewSurveys", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addSurveys", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteSurveys", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineSurveysPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "surveyNotes",
                        PageTitle = "ملاحظات الاستبيانات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectSurveyNotesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewSurveyNotes", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteSurveyNotes", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineSurveyNotesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "telegramChannelsBots",
                        PageTitle = "قنوات وبوت التليجرام",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectTelegramChannelsBotsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewTelegramChannelsBots", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addTelegramChannelsBots", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateTelegramChannelsBots", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteTelegramChannelsBots", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "runTelegramChannelsBots", DisplayName = "تشغيل", IsSelected = false },
                            new PermissionOptionVm { Key = "stopTelegramChannelsBots", DisplayName = "ايقاف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineTelegramChannelsBotsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "telegramSubscribers",
                        PageTitle = "مشتركين التليجرام",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectTelegramSubscribersAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewTelegramSubscribers", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteTelegramSubscribers", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineTelegramSubscribersPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "cardCurrencyDirectory",
                        PageTitle = "دليل عملات الكروت",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectCardCurrencyDirectoryAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewCardCurrencyDirectory", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addCardCurrencyDirectory", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateCardCurrencyDirectory", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteCardCurrencyDirectory", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineCardCurrencyDirectoryPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "additionalCommissions",
                        PageTitle = "عمولات اضافية",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectAdditionalCommissionsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewAdditionalCommissions", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addAdditionalCommissions", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateAdditionalCommissions", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteAdditionalCommissions", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineAdditionalCommissionsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "subscriptions",
                        PageTitle = "اشتراكات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectSubscriptionsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewSubscriptions", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addSubscriptions", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateSubscriptions", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteSubscriptions", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineSubscriptionsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "gameCategories",
                        PageTitle = "فئات الالعاب",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectGameCategoriesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewGameCategories", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addGameCategories", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateGameCategories", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteGameCategories", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "importGames", DisplayName = "استيراد الالعاب", IsSelected = false },
                            new PermissionOptionVm { Key = "defineGameCategoriesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "whatsappMessageFormatting",
                        PageTitle = "تنسيق رسائل الواتس",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectWhatsappMessageFormattingAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewWhatsappMessageFormatting", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addWhatsappMessageFormatting", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateWhatsappMessageFormatting", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteWhatsappMessageFormatting", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineWhatsappMessageFormattingPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "intelligentWhatsappReplies",
                        PageTitle = "ردود الواتس الذكية",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectIntelligentWhatsappRepliesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewIntelligentWhatsappReplies", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addIntelligentWhatsappReplies", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateIntelligentWhatsappReplies", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteIntelligentWhatsappReplies", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineIntelligentWhatsappRepliesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "employeeFunds",
                        PageTitle = "صندوق الموظفين",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectEmployeeFundsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewEmployeeFunds", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addEmployeeFunds", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateEmployeeFunds", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteEmployeeFunds", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineEmployeeFundsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "whatsappMarketing",
                        PageTitle = "واتساب تسويق",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectWhatsappMarketingAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewWhatsappMarketing", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addWhatsappMarketing", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteWhatsappMarketing", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineWhatsappMarketingPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "networkFeeding",
                        PageTitle = "التغذية عبر الشبكات",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectNetworkFeedingAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewNetworkFeeding", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addNetworkFeeding", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteNetworkFeeding", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "addAmountToCustomerAccount", DisplayName = "اضافة المبلغ لحساب العميل", IsSelected = false },
                            new PermissionOptionVm { Key = "resendToWhatsapp", DisplayName = "اعادة ارسال للواتس", IsSelected = false },
                            new PermissionOptionVm { Key = "defineNetworkFeedingPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "verifiedCustomers",
                        PageTitle = "العملاء الموثقين",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectVerifiedCustomersAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewVerifiedCustomers", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addVerifiedCustomers", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateVerifiedCustomers", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteVerifiedCustomers", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineVerifiedCustomersPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "banksAndFeedingNetworks",
                        PageTitle = "بنوك وشبكات التغذية",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectBanksAndFeedingNetworksAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewBanksAndFeedingNetworks", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addBanksAndFeedingNetworks", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateBanksAndFeedingNetworks", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteBanksAndFeedingNetworks", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineBanksAndFeedingNetworksPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "exchangeCompanyDevices",
                        PageTitle = "أجهزة شركات الصرافة",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectExchangeCompanyDevicesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewExchangeCompanyDevices", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addExchangeCompanyDevices", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateExchangeCompanyDevices", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteExchangeCompanyDevices", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineExchangeCompanyDevicesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "rateGroups",
                        PageTitle = "مجموعات النسب",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectRateGroupsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewRateGroups", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addRateGroups", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateRateGroups", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteRateGroups", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineRateGroupsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "dailyCommissions",
                        PageTitle = "العمولات اليومية",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectDailyCommissionsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewDailyCommissions", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteDailyCommissions", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineDailyCommissionsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "monthlyCommissions",
                        PageTitle = "العمولات الشهرية",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectMonthlyCommissionsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewMonthlyCommissions", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "deleteMonthlyCommissions", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "exportMonthlyCommission", DisplayName = "اخراج العمولة الشهرية", IsSelected = false },
                            new PermissionOptionVm { Key = "defineMonthlyCommissionsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "electricityAreas",
                        PageTitle = "مناطق الكهرباء",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectElectricityAreasAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewElectricityAreas", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addElectricityAreas", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateElectricityAreas", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteElectricityAreas", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineElectricityAreasPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "waterAreas",
                        PageTitle = "مناطق الماء",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectWaterAreasAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewWaterAreas", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addWaterAreas", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateWaterAreas", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteWaterAreas", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineWaterAreasPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "devices",
                        PageTitle = "اجهزة",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectDevicesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewDevices", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addDevices", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateDevices", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteDevices", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineDevicesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "devices2",
                        PageTitle = "اجهزة",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectDevices2All", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewDevices2", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addDevices2", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateDevices2", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteDevices2", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineDevices2PrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "rateByAmount",
                        PageTitle = "نسب التسعيرة حسب المبلغ",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectRateByAmountAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewRateByAmount", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addRateByAmount", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateRateByAmount", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteRateByAmount", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineRateByAmountPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "devices3",
                        PageTitle = "أجهزة",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectDevices3All", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewDevices3", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addDevices3", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateDevices3", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteDevices3", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineDevices3PrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "yemenForjiPackages",
                        PageTitle = "باقات يمن فورجي",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectYemenForjiPackagesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewYemenForjiPackages", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addYemenForjiPackages", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateYemenForjiPackages", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteYemenForjiPackages", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineYemenForjiPackagesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "wifiPackages",
                        PageTitle = "باقات واي",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectWifiPackagesAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewWifiPackages", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addWifiPackages", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateWifiPackages", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteWifiPackages", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "importWifiPackages", DisplayName = "استيراد", IsSelected = false },
                            new PermissionOptionVm { Key = "defineWifiPackagesPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "automatedPricingSystem",
                        PageTitle = "نظام التسعيره الآليه",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectAutomatedPricingSystemAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewAutomatedPricingSystem", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addAutomatedPricingSystem", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateAutomatedPricingSystem", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteAutomatedPricingSystem", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineAutomatedPricingSystemPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "monthlyTransfer",
                        PageTitle = "الترحيل الشهري",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectMonthlyTransferAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewMonthlyTransfer", DisplayName = "مشاهدة", IsSelected = true },
                            new PermissionOptionVm { Key = "addMonthlyTransfer", DisplayName = "اضافة", IsSelected = true },
                            new PermissionOptionVm { Key = "updateMonthlyTransfer", DisplayName = "تحديث", IsSelected = false },
                            new PermissionOptionVm { Key = "deleteMonthlyTransfer", DisplayName = "حذف", IsSelected = false },
                            new PermissionOptionVm { Key = "defineMonthlyTransferPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "reports",
                        PageTitle = "التقارير",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectReportsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "viewCustomerReport", DisplayName = "تقرير العملاء", IsSelected = true },
                            new PermissionOptionVm { Key = "viewEmployeeReport", DisplayName = "تقرير الموظفين", IsSelected = true },
                            new PermissionOptionVm { Key = "viewDailyCustomerReport", DisplayName = "تقرير العملاء اليومي", IsSelected = true },
                            new PermissionOptionVm { Key = "viewCustomerAccountStatement", DisplayName = "كشف حساب العملاء", IsSelected = true },
                            new PermissionOptionVm { Key = "viewAccountBalancesReport", DisplayName = "تقرير الارصدة الحسابية", IsSelected = true },
                            new PermissionOptionVm { Key = "viewTotalsReport", DisplayName = "تقرير اجماليات", IsSelected = true },
                            new PermissionOptionVm { Key = "viewTrialBalanceReport", DisplayName = "تقرير ميزان المراجعة", IsSelected = true },
                            new PermissionOptionVm { Key = "viewGatewaysReport", DisplayName = "تقرير البوابات", IsSelected = true },
                            new PermissionOptionVm { Key = "defineReportsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "otherInteractions",
                        PageTitle = "تفاعلات اخرى",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectOtherInteractionsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "grantAgentPermission", DisplayName = "منح صلاحية الوكيل", IsSelected = false },
                            new PermissionOptionVm { Key = "revokeAgentPermission", DisplayName = "الغاء صلاحية الوكيل", IsSelected = false },
                            new PermissionOptionVm { Key = "assignAgentToCustomer", DisplayName = "تحديد الوكيل للعميل", IsSelected = false },
                            new PermissionOptionVm { Key = "resetPassword", DisplayName = "استعادة كلمة السر", IsSelected = false },
                            new PermissionOptionVm { Key = "queryBalance", DisplayName = "المفاتيح والاستعلام عن الرصيد المتبقي عند المزودين", IsSelected = false },
                            new PermissionOptionVm { Key = "accessArchive", DisplayName = "دخول الارشيف", IsSelected = false },
                            new PermissionOptionVm { Key = "addLoan", DisplayName = "اضافة قرض", IsSelected = false },
                            new PermissionOptionVm { Key = "transferAccount", DisplayName = "ترحيل حساب", IsSelected = false },
                            new PermissionOptionVm { Key = "cancelLinkedOperation", DisplayName = "الغاء عملية مربوطه بموظف اخر", IsSelected = false },
                            new PermissionOptionVm { Key = "viewLinkedOperations", DisplayName = "مشاهدة عمليات مربوطه", IsSelected = false },
                            new PermissionOptionVm { Key = "editInsuranceData", DisplayName = "تعديل البيان للتامين", IsSelected = false },
                            new PermissionOptionVm { Key = "cancelOperationReadiness", DisplayName = "الغا الجاهزية للعملية", IsSelected = false },
                            new PermissionOptionVm { Key = "viewAdministrativeReport", DisplayName = "التقرير الاداري", IsSelected = false },
                            new PermissionOptionVm { Key = "enableCustomerAgentPermission", DisplayName = "اتاحة صلاحية وكيل للعميل", IsSelected = false },
                            new PermissionOptionVm { Key = "disableCustomerAgentPermission", DisplayName = "الغاء صلاحية وكيل للعميل", IsSelected = false },
                            new PermissionOptionVm { Key = "addCustomerToAgent", DisplayName = "اضافة العميل الى وكيل", IsSelected = false },
                            new PermissionOptionVm { Key = "enableCustomerMerchantPermission", DisplayName = "اتاحة صلاحية التاجر للعميل", IsSelected = false },
                            new PermissionOptionVm { Key = "disableCustomerMerchantPermission", DisplayName = "الغاء صلاحية التاجر للعميل", IsSelected = false },
                            new PermissionOptionVm { Key = "accountBalancesReportPermission", DisplayName = "صلاحية تقرير الارصدة الحسابية", IsSelected = false },
                            new PermissionOptionVm { Key = "customerAccountStatementPermission", DisplayName = "صلاحية تقرير كشف حساب للعميل", IsSelected = false },
                            new PermissionOptionVm { Key = "employeeReportPermission", DisplayName = "صلاحية تقرير الموظفين", IsSelected = false },
                            new PermissionOptionVm { Key = "dailyCustomerReportPermission", DisplayName = "صلاحية تقرير العملاء اليومي", IsSelected = false },
                            new PermissionOptionVm { Key = "customerReportTotalsPermission", DisplayName = "صلاحية تقرير العملاء اجماليات", IsSelected = false },
                            new PermissionOptionVm { Key = "installmentsReportPermission", DisplayName = "صلاحية تقرير التسديدات/ *** صلاحية تقرير ***/", IsSelected = false },
                            new PermissionOptionVm { Key = "commissionsReportPermission", DisplayName = "العمولات صلاحية اضافة عمولة للعميل من التقرير", IsSelected = false },
                            new PermissionOptionVm { Key = "updateCustomerCommissionRate", DisplayName = "صلاحية تحديد، وتحديث نسبة عمولة للعميل من التقرير", IsSelected = false },
                            new PermissionOptionVm { Key = "grantBranchIPPermission", DisplayName = "منح صلاحية فرع (الايه بي اي) للعميل", IsSelected = false },
                            new PermissionOptionVm { Key = "addCustomerToRateGroup", DisplayName = "اضافة العميل لمجموعة التسعيرة", IsSelected = false },
                            new PermissionOptionVm { Key = "humanResourcesReport", DisplayName = "تقرير الموارد البشرية", IsSelected = false },
                            new PermissionOptionVm { Key = "editInsuranceAmountSameDay", DisplayName = "تعديل مبلغ التامين في نفس اليوم فقط", IsSelected = false },
                            new PermissionOptionVm { Key = "editInsuranceAmountAnyDay", DisplayName = "تعديل مبلغ التامين في أي يوم", IsSelected = false },
                            new PermissionOptionVm { Key = "editInsuranceDate", DisplayName = "تعديل تاريخ التامين", IsSelected = false },
                            new PermissionOptionVm { Key = "providerPerformanceReport", DisplayName = "تقرير تقييم أداء المزودين", IsSelected = false },
                            new PermissionOptionVm { Key = "approveFeedingRequests", DisplayName = "الموافقة على طلبات التغذية الواردة", IsSelected = false },
                            new PermissionOptionVm { Key = "customerPerformanceReport", DisplayName = "تقرير أداء العملاء", IsSelected = false },
                            new PermissionOptionVm { Key = "providerNetworkCollectionReport", DisplayName = "تقرير تحصيل شبكات المزودين", IsSelected = false },
                            new PermissionOptionVm { Key = "addInsuranceNonTodayDate", DisplayName = "اضافة تأمين بتأريخ غير تأريخ اليوم", IsSelected = false },
                            new PermissionOptionVm { Key = "displayChartsOnHomepage", DisplayName = "عرض تقارير الرسوم البيانية في الصفحة الرئيسية", IsSelected = false },
                            new PermissionOptionVm { Key = "displayTotalsUnderOperations", DisplayName = "عرض الاجمالي اسفل جدول بيانات العمليات", IsSelected = false },
                            new PermissionOptionVm { Key = "displayTotalsUnderInsurance", DisplayName = "عرض الاجمالي اسفل جدول التامينات", IsSelected = false },
                            new PermissionOptionVm { Key = "displayTotalsUnderBotReplies", DisplayName = "عرض الاجمالي اسفل جدول ردود الروبوتات", IsSelected = false },
                            new PermissionOptionVm { Key = "displayTotalsUnderJournals", DisplayName = "عرض الاجمالي اسفل جدول اليوميات", IsSelected = false },
                            new PermissionOptionVm { Key = "providerNetworkCostReport", DisplayName = "تقرير تكلفة شبكات المزودين", IsSelected = false },
                            new PermissionOptionVm { Key = "rechargeFullCardsOnFailure", DisplayName = "اعادة شحن الكروت الشاملة في حالة فشل شحن الكرت للزبون", IsSelected = false },
                            new PermissionOptionVm { Key = "simReport", DisplayName = "تقرير الشرائح", IsSelected = false },
                            new PermissionOptionVm { Key = "backupDatabase", DisplayName = "نسخ احتياطي لقاعدة البيانات", IsSelected = false },
                            new PermissionOptionVm { Key = "captureWhatsAppForLinking", DisplayName = "التقاط الواتساب للربط", IsSelected = false },
                            new PermissionOptionVm { Key = "defineOtherInteractionsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    },
                    new PagePermissionVm
                    {
                        PageKey = "employeeSpecificOperations",
                        PageTitle = "خصص للموظف عمليات محددة!",
                        Options = new List<PermissionOptionVm>
                        {
                            new PermissionOptionVm { Key = "selectEmployeeSpecificOperationsAll", DisplayName = "تحديد الكل", IsSelected = true },
                            new PermissionOptionVm { Key = "mobileBalancePayment", DisplayName = "تسديد رصيد موبايل", IsSelected = false },
                            new PermissionOptionVm { Key = "balanceAndPackage", DisplayName = "رصيد وباقة ( سعر الرصيد+نوع الباقة )", IsSelected = false },
                            new PermissionOptionVm { Key = "adslInternetPayment", DisplayName = "تسديد الانترنت ADSL", IsSelected = false },
                            new PermissionOptionVm { Key = "landlinePhonePayment", DisplayName = "تسديد الهاتف الثابت", IsSelected = false },
                            new PermissionOptionVm { Key = "yemenMobileLostCardFee", DisplayName = "بدل فاقد يمن موبايل", IsSelected = false },
                            new PermissionOptionVm { Key = "newMobileSim", DisplayName = "شريحة جديد موبايل", IsSelected = false },
                            new PermissionOptionVm { Key = "instantRechargeForAll", DisplayName = "شحن فوري للجميع", IsSelected = false },
                            new PermissionOptionVm { Key = "newPrepaidProgrammedSim", DisplayName = "شريحة جديدة دفع مسبق/برمجه", IsSelected = false },
                            new PermissionOptionVm { Key = "lostCardFee2", DisplayName = "بدل فاقد(2)", IsSelected = false },
                            new PermissionOptionVm { Key = "newYouActivation", DisplayName = "تفعيل You جديده", IsSelected = false },
                            new PermissionOptionVm { Key = "sabafonActivation", DisplayName = "تفعيل سبافون", IsSelected = false },
                            new PermissionOptionVm { Key = "mtnPackages", DisplayName = "باقات MTN", IsSelected = false },
                            new PermissionOptionVm { Key = "sendRemittance", DisplayName = "إرسال حواله", IsSelected = false },
                            new PermissionOptionVm { Key = "addYourNetworkFree", DisplayName = "أضف شبكتك مجاناَ", IsSelected = false },
                            new PermissionOptionVm { Key = "receiveRemittance", DisplayName = "استلام حواله", IsSelected = false },
                            new PermissionOptionVm { Key = "smsNetworkCards", DisplayName = "كروت شبكةsms", IsSelected = false },
                            new PermissionOptionVm { Key = "instantRechargeWholesale", DisplayName = "شحن فوري جمله", IsSelected = false },
                            new PermissionOptionVm { Key = "insuranceNotification", DisplayName = "إرسال اشعار التامين-", IsSelected = false },
                            new PermissionOptionVm { Key = "manualInternetPayment", DisplayName = "تسديد النت يدوي", IsSelected = false },
                            new PermissionOptionVm { Key = "manualLandline", DisplayName = "الخط الثابت يدوي", IsSelected = false },
                            new PermissionOptionVm { Key = "sabafonPackages", DisplayName = "باقات سبأفون", IsSelected = false },
                            new PermissionOptionVm { Key = "wirelessCardsNotificationsOnly", DisplayName = "كروت وايرلس اشعارات فقط", IsSelected = false },
                            new PermissionOptionVm { Key = "transferBalanceForInstantPayment", DisplayName = "حول رصيد لتسديد فوري", IsSelected = false },
                            new PermissionOptionVm { Key = "mobilePackages", DisplayName = "باقات موبايل", IsSelected = false },
                            new PermissionOptionVm { Key = "onDemandUnits", DisplayName = "وحدات حسب الطلب", IsSelected = false },
                            new PermissionOptionVm { Key = "mobileRiyalWholesale", DisplayName = "ريال موبايل جمله", IsSelected = false },
                            new PermissionOptionVm { Key = "insuranceNotification2", DisplayName = "إرسال اشعار التامين", IsSelected = false },
                            new PermissionOptionVm { Key = "manualSabafonBilling", DisplayName = "فوترة سبافون يدوي", IsSelected = false },
                            new PermissionOptionVm { Key = "treasuryForAppTransfer", DisplayName = "الخزنه للتحويل بين التطبيقات", IsSelected = false },
                            new PermissionOptionVm { Key = "pubgUc", DisplayName = "شدات بوبجي", IsSelected = false },
                            new PermissionOptionVm { Key = "internationalRemittanceCommission", DisplayName = "عمولة ارسال حوالة اجنبية", IsSelected = false },
                            new PermissionOptionVm { Key = "updatePersonalName", DisplayName = "تعديل الاسم الشخصي ليطابق نظام الكريمي", IsSelected = false },
                            new PermissionOptionVm { Key = "appFeature", DisplayName = "ميزة تطبيقي", IsSelected = false },
                            new PermissionOptionVm { Key = "sabafonSouthPackages", DisplayName = "باقات سبافون جنوب", IsSelected = false },
                            new PermissionOptionVm { Key = "instantRechargeSabafonSouth", DisplayName = "شحن فوري سبافون جنوب", IsSelected = false },
                            new PermissionOptionVm { Key = "razerCardGlobal", DisplayName = "بطاقة ريزر عالمي", IsSelected = false },
                            new PermissionOptionVm { Key = "itunesAmerican", DisplayName = "ايتونز امريكي", IsSelected = false },
                            new PermissionOptionVm { Key = "freeFire", DisplayName = "فري فاير", IsSelected = false },
                            new PermissionOptionVm { Key = "pubgRecoveryCode", DisplayName = "رمز استرداد ببجي", IsSelected = false },
                            new PermissionOptionVm { Key = "freeFireRecoveryCode", DisplayName = "فري فاير رمز استرداد", IsSelected = false },
                            new PermissionOptionVm { Key = "wirelessCardsSales", DisplayName = "مبيعات كروت الوايرلس", IsSelected = false },
                            new PermissionOptionVm { Key = "beinSportConnect", DisplayName = "بطاقة BeinSport-Connect بين سبورت", IsSelected = false },
                            new PermissionOptionVm { Key = "playStationNetworkAmerican", DisplayName = "PlayStation Network بلاستيشن امريكي", IsSelected = false },
                            new PermissionOptionVm { Key = "playStationNetworkKSA", DisplayName = "PlayStation Network KSA (سعودي)", IsSelected = false },
                            new PermissionOptionVm { Key = "crossFireCard", DisplayName = "CrossFire Card", IsSelected = false },
                            new PermissionOptionVm { Key = "mobileLegend", DisplayName = "موبايل ليجند", IsSelected = false },
                            new PermissionOptionVm { Key = "visaCardStoreOnly", DisplayName = "بطاقة فيزا للمتجر فقط", IsSelected = false },
                            new PermissionOptionVm { Key = "instantGPackageActivation", DisplayName = "تفعيل باقات فوري جي ب 100 ريال", IsSelected = false },
                            new PermissionOptionVm { Key = "likee", DisplayName = "لايكي Likee", IsSelected = false },
                            new PermissionOptionVm { Key = "pubgNewState", DisplayName = "PUBG: NEW STATE", IsSelected = false },
                            new PermissionOptionVm { Key = "googlePlayAmerican", DisplayName = "بطاقة جوجل بلاي امريكي", IsSelected = false },
                            new PermissionOptionVm { Key = "clashOfClans", DisplayName = "كلاش اوف كلانس", IsSelected = false },
                            new PermissionOptionVm { Key = "lordsMobileGems", DisplayName = "جواهر لوردس موبايل", IsSelected = false },
                            new PermissionOptionVm { Key = "clashRoyale", DisplayName = "كلاش رويال", IsSelected = false },
                            new PermissionOptionVm { Key = "brawlStars", DisplayName = "براول ستارز", IsSelected = false },
                            new PermissionOptionVm { Key = "highDayGems", DisplayName = "هاي داي جواهر", IsSelected = false },
                            new PermissionOptionVm { Key = "highDayGoldCoin", DisplayName = "هاي داي عملة ذهبية", IsSelected = false },
                            new PermissionOptionVm { Key = "callOfDuty", DisplayName = "كول او ديوتي", IsSelected = false },
                            new PermissionOptionVm { Key = "bigolive", DisplayName = "بيجو لايف", IsSelected = false },
                            new PermissionOptionVm { Key = "boomBeach", DisplayName = "بوم بيتش", IsSelected = false },
                            new PermissionOptionVm { Key = "masterCardPrepaid", DisplayName = "بطائق مستر كارد دفع مسبق", IsSelected = false },
                            new PermissionOptionVm { Key = "trafficViolationPayment", DisplayName = "تسديد المخالفات المروروية", IsSelected = false },
                            new PermissionOptionVm { Key = "electricityRenewal", DisplayName = "كهرباء تجدد", IsSelected = false },
                            new PermissionOptionVm { Key = "waterBillPayment", DisplayName = "سداد فواتير الماء", IsSelected = false },
                            new PermissionOptionVm { Key = "electricityCompany", DisplayName = "مؤسسة الكهرباء", IsSelected = false },
                            new PermissionOptionVm { Key = "yemenPostWifi", DisplayName = "البريد اليمني وايفاي", IsSelected = false },
                            new PermissionOptionVm { Key = "crystalGenesisImpact", DisplayName = "كرستال جنشن امباكت", IsSelected = false },
                            new PermissionOptionVm { Key = "tangoLiveCard", DisplayName = "بطاقة تانجو لايف", IsSelected = false },
                            new PermissionOptionVm { Key = "conezatYou", DisplayName = "كونزات يويو", IsSelected = false },
                            new PermissionOptionVm { Key = "fortniteVBucks", DisplayName = "بطاقة فورتنايت V-Bucks", IsSelected = false },
                            new PermissionOptionVm { Key = "crunchyRollSubscriptions", DisplayName = "اشتراكات كرنشي رول", IsSelected = false },
                            new PermissionOptionVm { Key = "tiktokCoins", DisplayName = "عملات تيكتوك", IsSelected = false },
                            new PermissionOptionVm { Key = "micoLive", DisplayName = "ميكو لايف", IsSelected = false },
                            new PermissionOptionVm { Key = "imoLive", DisplayName = "ايمو لايف", IsSelected = false },
                            new PermissionOptionVm { Key = "pubgCodes", DisplayName = "اكواد بوبجي", IsSelected = false },
                            new PermissionOptionVm { Key = "kingsChallenge", DisplayName = "تحدي الملوك حرب / حرب السلاطين", IsSelected = false },
                            new PermissionOptionVm { Key = "yemenForji", DisplayName = "يمن فورجي", IsSelected = false },
                            new PermissionOptionVm { Key = "youLostCardFee", DisplayName = "بدل فاقد يو", IsSelected = false },
                            new PermissionOptionVm { Key = "topTop", DisplayName = "توب توب", IsSelected = false },
                            new PermissionOptionVm { Key = "bronzeMobile4500", DisplayName = "برونزي موبايل 4500", IsSelected = false },
                            new PermissionOptionVm { Key = "vengeanceOfKings", DisplayName = "انتقام السلاطين", IsSelected = false },
                            new PermissionOptionVm { Key = "youBalance", DisplayName = "رصيد يو", IsSelected = false },
                            new PermissionOptionVm { Key = "accountVerification", DisplayName = "توثيق الحساب", IsSelected = false },
                            new PermissionOptionVm { Key = "ahlaChat", DisplayName = "اهلا شات", IsSelected = false },
                            new PermissionOptionVm { Key = "conezatKfo", DisplayName = "كونزات كفو (", IsSelected = false },
                            new PermissionOptionVm { Key = "yallaLudo", DisplayName = "يلا لودو", IsSelected = false },
                            new PermissionOptionVm { Key = "queensatYouho", DisplayName = "كوينزات يوهو", IsSelected = false },
                            new PermissionOptionVm { Key = "queensatTalkTalk", DisplayName = "كوينزات تالك تالك", IsSelected = false },
                            new PermissionOptionVm { Key = "yallaLiveGoldPieces", DisplayName = "يلا لايف قطع ذهبية", IsSelected = false },
                            new PermissionOptionVm { Key = "soulShell", DisplayName = "سول شيل", IsSelected = false },
                            new PermissionOptionVm { Key = "netflix", DisplayName = "نتفلكس", IsSelected = false },
                            new PermissionOptionVm { Key = "binanceTransfer", DisplayName = "تحويل الى حساب بايننس برنامج", IsSelected = false },
                            new PermissionOptionVm { Key = "sawaChat", DisplayName = "سوا شات", IsSelected = false },
                            new PermissionOptionVm { Key = "boboLive", DisplayName = "بوبو لايف", IsSelected = false },
                            new PermissionOptionVm { Key = "partyStar", DisplayName = "بارتي ستار", IsSelected = false },
                            new PermissionOptionVm { Key = "bellaChat", DisplayName = "بيلا شات", IsSelected = false },
                            new PermissionOptionVm { Key = "happyChat", DisplayName = "هابي شات", IsSelected = false },
                            new PermissionOptionVm { Key = "pinmoChat", DisplayName = "بينمو شات", IsSelected = false },
                            new PermissionOptionVm { Key = "azalLive", DisplayName = "ازال لايف", IsSelected = false },
                            new PermissionOptionVm { Key = "fifaMobile", DisplayName = "فيفا موبايل", IsSelected = false },
                            new PermissionOptionVm { Key = "lamaChat", DisplayName = "لما شات", IsSelected = false },
                            new PermissionOptionVm { Key = "ohlaChat", DisplayName = "اوهلا شات", IsSelected = false },
                            new PermissionOptionVm { Key = "specialLost", DisplayName = "بدل خاص", IsSelected = false },
                            new PermissionOptionVm { Key = "specialNew", DisplayName = "جديد خاص", IsSelected = false },
                            new PermissionOptionVm { Key = "nova", DisplayName = "نوڤا", IsSelected = false },
                            new PermissionOptionVm { Key = "hiya", DisplayName = "هيا HIYA", IsSelected = false },
                            new PermissionOptionVm { Key = "topTop2", DisplayName = "توب توب", IsSelected = false },
                            new PermissionOptionVm { Key = "lama", DisplayName = "لما lama", IsSelected = false },
                            new PermissionOptionVm { Key = "fakeWhatsAppNumbers", DisplayName = "ارقام واتساب وهميه", IsSelected = false },
                            new PermissionOptionVm { Key = "yalla", DisplayName = "يلا Yalla", IsSelected = false },
                            new PermissionOptionVm { Key = "livULive", DisplayName = "لايف يو LivU", IsSelected = false },
                            new PermissionOptionVm { Key = "digitalCurrencyUSDT", DisplayName = "عملات رقميه USDT", IsSelected = false },
                            new PermissionOptionVm { Key = "8BallPool", DisplayName = "8Ball Pool", IsSelected = false },
                            new PermissionOptionVm { Key = "zengaPoker", DisplayName = "زنجا بوكر", IsSelected = false },
                            new PermissionOptionVm { Key = "hawa", DisplayName = "هوا HAWA", IsSelected = false },
                            new PermissionOptionVm { Key = "oohla", DisplayName = "اوهلا OOHLA", IsSelected = false },
                            new PermissionOptionVm { Key = "lami", DisplayName = "لامي Lami", IsSelected = false },
                            new PermissionOptionVm { Key = "pesEfootball", DisplayName = "بيس - eFootball", IsSelected = false },
                            new PermissionOptionVm { Key = "tangoLive", DisplayName = "تانجو لايف", IsSelected = false },
                            new PermissionOptionVm { Key = "kwai", DisplayName = "كواي", IsSelected = false },
                            new PermissionOptionVm { Key = "meYo", DisplayName = "ميو MeYo", IsSelected = false },
                            new PermissionOptionVm { Key = "superLive", DisplayName = "سوبر SuperLive", IsSelected = false },
                            new PermissionOptionVm { Key = "poppo", DisplayName = "ببو - Poppo", IsSelected = false },
                            new PermissionOptionVm { Key = "xenaLive", DisplayName = "زينا لايف - Xena", IsSelected = false },
                            new PermissionOptionVm { Key = "fancy", DisplayName = "فانسي - FANCY", IsSelected = false },
                            new PermissionOptionVm { Key = "sky", DisplayName = "سكاي - SKY", IsSelected = false },
                            new PermissionOptionVm { Key = "4Fun", DisplayName = "فور فن - 4Fun", IsSelected = false },
                            new PermissionOptionVm { Key = "upLive", DisplayName = "اب لايف- Up live", IsSelected = false },
                            new PermissionOptionVm { Key = "migo", DisplayName = "ميجو - MIGO", IsSelected = false },
                            new PermissionOptionVm { Key = "olamet", DisplayName = "اولاميت - Olamet", IsSelected = false },
                            new PermissionOptionVm { Key = "dido", DisplayName = "ديدو - DiDO", IsSelected = false },
                            new PermissionOptionVm { Key = "ligo", DisplayName = "ليجو - Ligo", IsSelected = false },
                            new PermissionOptionVm { Key = "tumile", DisplayName = "توميل - Tumile", IsSelected = false },
                            new PermissionOptionVm { Key = "perfectMoney", DisplayName = "بيرفكت موني", IsSelected = false },
                            new PermissionOptionVm { Key = "facebookSupport", DisplayName = "دعم فيسبوك", IsSelected = false },
                            new PermissionOptionVm { Key = "instagramSupport", DisplayName = "دعم انستقرام", IsSelected = false },
                            new PermissionOptionVm { Key = "tiktokSupport", DisplayName = "دعم تيك توك", IsSelected = false },
                            new PermissionOptionVm { Key = "youtubeSupport", DisplayName = "دعم يوتيوب", IsSelected = false },
                            new PermissionOptionVm { Key = "yoobi", DisplayName = "يوبي", IsSelected = false },
                            new PermissionOptionVm { Key = "woshat", DisplayName = "الووشات", IsSelected = false },
                            new PermissionOptionVm { Key = "buyerBalance", DisplayName = "رصيد بايير", IsSelected = false },
                            new PermissionOptionVm { Key = "pubgLte", DisplayName = "PUBG Lite", IsSelected = false },
                            new PermissionOptionVm { Key = "echoChat", DisplayName = "ايكو شات", IsSelected = false },
                            new PermissionOptionVm { Key = "soulfChat", DisplayName = "سولف شات", IsSelected = false },
                            new PermissionOptionVm { Key = "marhabaChat", DisplayName = "مرحبا شات", IsSelected = false },
                            new PermissionOptionVm { Key = "chatChill", DisplayName = "CHAT CHILL شات شيل", IsSelected = false },
                            new PermissionOptionVm { Key = "ludoStar", DisplayName = "لودو استار", IsSelected = false },
                            new PermissionOptionVm { Key = "saudiTelecomCards", DisplayName = "بطائق اتصالات السعودية", IsSelected = false },
                            new PermissionOptionVm { Key = "shahidVIP", DisplayName = "شاهد VIP", IsSelected = false },
                            new PermissionOptionVm { Key = "kwai2", DisplayName = "كواي", IsSelected = false },
                            new PermissionOptionVm { Key = "bobo", DisplayName = "بوبو BoBo", IsSelected = false },
                            new PermissionOptionVm { Key = "wePlay", DisplayName = "وي بلاي - WePlay", IsSelected = false },
                            new PermissionOptionVm { Key = "ayome", DisplayName = "ايوم - Ayome", IsSelected = false },
                            new PermissionOptionVm { Key = "light", DisplayName = "لايت - Light", IsSelected = false },
                            new PermissionOptionVm { Key = "marhabaChat2", DisplayName = "مرحبا شات", IsSelected = false },
                            new PermissionOptionVm { Key = "wahoChat", DisplayName = "واهو شات waho", IsSelected = false },
                            new PermissionOptionVm { Key = "soulU", DisplayName = "سول يو Soul U", IsSelected = false },
                            new PermissionOptionVm { Key = "cocco", DisplayName = "كوكوcocco", IsSelected = false },
                            new PermissionOptionVm { Key = "yooyChat", DisplayName = "يووي YooY Chat", IsSelected = false },
                            new PermissionOptionVm { Key = "haky", DisplayName = "هاكي", IsSelected = false },
                            new PermissionOptionVm { Key = "chatVoices", DisplayName = "اصوات شات", IsSelected = false },
                            new PermissionOptionVm { Key = "layla", DisplayName = "ليلى LAYLA", IsSelected = false },
                            new PermissionOptionVm { Key = "gimmeLive", DisplayName = "جمي لايف Gimme", IsSelected = false },
                            new PermissionOptionVm { Key = "soyo", DisplayName = "سويوSOYO", IsSelected = false },
                            new PermissionOptionVm { Key = "gala", DisplayName = "غلا Gala", IsSelected = false },
                            new PermissionOptionVm { Key = "wyak", DisplayName = "وياك wyak", IsSelected = false },
                            new PermissionOptionVm { Key = "wegoChat", DisplayName = "ويجو شات WEGO", IsSelected = false },
                            new PermissionOptionVm { Key = "maan", DisplayName = "Maan- مان", IsSelected = false },
                            new PermissionOptionVm { Key = "kamalna", DisplayName = "كملنا", IsSelected = false },
                            new PermissionOptionVm { Key = "pika", DisplayName = "بيكا Pika", IsSelected = false },
                            new PermissionOptionVm { Key = "salamChat", DisplayName = "سلام شات", IsSelected = false },
                            new PermissionOptionVm { Key = "alulu", DisplayName = "الولو ALULU", IsSelected = false },
                            new PermissionOptionVm { Key = "veco", DisplayName = "فيكو Veco", IsSelected = false },
                            new PermissionOptionVm { Key = "yaahlan", DisplayName = "ياهلن YAAHLAN", IsSelected = false },
                            new PermissionOptionVm { Key = "starMaker", DisplayName = "ستار ميكر", IsSelected = false },
                            new PermissionOptionVm { Key = "sugo", DisplayName = "سوغو SUGO", IsSelected = false },
                            new PermissionOptionVm { Key = "honeyJar", DisplayName = "هوني جار Honey jar", IsSelected = false },
                            new PermissionOptionVm { Key = "sparty", DisplayName = "سبارتي", IsSelected = false },
                            new PermissionOptionVm { Key = "wanasaChat", DisplayName = "وناسة شات", IsSelected = false },
                            new PermissionOptionVm { Key = "hoby", DisplayName = "هوبي HOBY", IsSelected = false },
                            new PermissionOptionVm { Key = "tami", DisplayName = "تامي Tami", IsSelected = false },
                            new PermissionOptionVm { Key = "habi", DisplayName = "هبي habi", IsSelected = false },
                            new PermissionOptionVm { Key = "jwaker", DisplayName = "جواكر", IsSelected = false },
                            new PermissionOptionVm { Key = "warRobots", DisplayName = "روبوتات الحرب", IsSelected = false },
                            new PermissionOptionVm { Key = "varlight84", DisplayName = "فارلايت 84", IsSelected = false },
                            new PermissionOptionVm { Key = "ditto", DisplayName = "ديتو Ditto", IsSelected = false },
                            new PermissionOptionVm { Key = "nabd", DisplayName = "نبض Nabd", IsSelected = false },
                            new PermissionOptionVm { Key = "ashaLive", DisplayName = "اشا لايف Asha live", IsSelected = false },
                            new PermissionOptionVm { Key = "highParty", DisplayName = "هاي بارتي", IsSelected = false },
                            new PermissionOptionVm { Key = "bloodStrike", DisplayName = "بلود سترايك Blood Strike", IsSelected = false },
                            new PermissionOptionVm { Key = "partyU", DisplayName = "بارتي يو Party U", IsSelected = false },
                            new PermissionOptionVm { Key = "topWar", DisplayName = "توب وار Top War", IsSelected = false },
                            new PermissionOptionVm { Key = "honorOfKings", DisplayName = "هونر اوف كينج Honor of Kings", IsSelected = false },
                            new PermissionOptionVm { Key = "soulSatar", DisplayName = "سول ستار SoulSatar", IsSelected = false },
                            new PermissionOptionVm { Key = "yamiStar", DisplayName = "يامي ستار YamiStar", IsSelected = false },
                            new PermissionOptionVm { Key = "canva", DisplayName = "كانفا Canva", IsSelected = false },
                            new PermissionOptionVm { Key = "defineEmployeeSpecificOperationsPrintFields", DisplayName = "تحديد الحقول للطباعه", IsSelected = false }
                        }
                    }
                }
            };
            
            return View(vm);
        }
        
        public IActionResult Details() => View();
        public IActionResult Edit() => View();
        public IActionResult Add() => View();
        
        [HttpPost]
        public IActionResult Add(EmployeeModel model)
        {
            // In a real application, you would save the employee to a database
            // For demo purposes, we'll just return success
            return Json(new { success = true, message = "تم إضافة الموظف بنجاح" });
        }
    }
}