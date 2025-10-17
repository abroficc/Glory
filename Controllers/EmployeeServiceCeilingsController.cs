using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inspinia.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class EmployeeServiceCeilingsController : Controller
    {
        // GET: EmployeeServiceCeilings
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new EmployeeServiceCeilingsIndexVm
            {
                EmployeeServiceCeilings = new List<EmployeeServiceCeiling>
                {
                    new EmployeeServiceCeiling
                    {
                        Id = 1,
                        CeilingName = "سقف خدمات الموظفين الأساسي",
                        Description = "تحديد الحد الأقصى للخدمات الأساسية المسموحة للموظف",
                        CreateDate = DateTime.Now.AddDays(-30),
                        UpdateDate = DateTime.Now.AddDays(-30),
                        Status = 1,
                        Notes = "سقف أساسي للموظفين"
                    },
                    new EmployeeServiceCeiling
                    {
                        Id = 2,
                        CeilingName = "سقف خدمات الموظفين المتقدم",
                        Description = "تحديد الحد الأقصى للخدمات المتقدمة المسموحة للموظف",
                        CreateDate = DateTime.Now.AddDays(-29),
                        UpdateDate = DateTime.Now.AddDays(-29),
                        Status = 1,
                        Notes = "لخدمات خاصة بالموظفين"
                    },
                    new EmployeeServiceCeiling
                    {
                        Id = 3,
                        CeilingName = "سقف خدمات الموظفين الخاص",
                        Description = "تحديد الحد الأقصى للخدمات الخاصة المسموحة للموظف",
                        CreateDate = DateTime.Now.AddDays(-28),
                        UpdateDate = DateTime.Now.AddDays(-28),
                        Status = 1,
                        Notes = "للخدمات المميزة للموظفين"
                    }
                }
            };

            return View(viewModel);
        }
    }
}