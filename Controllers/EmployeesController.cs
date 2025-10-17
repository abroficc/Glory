using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ASP.Net_Core_MVC.Full.Models;
using Inspinia.Services;

namespace Inspinia.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly PermissionsService _permissionsService;

        public EmployeesController()
        {
            _permissionsService = new PermissionsService();
        }

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
                
                // تحميل الصلاحيات من الخدمة بدلاً من الكود المباشر لحل مشكلة CS8103
                Pages = _permissionsService.GetAllPermissions()
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







