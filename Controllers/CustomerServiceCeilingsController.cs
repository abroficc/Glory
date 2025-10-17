using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inspinia.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class CustomerServiceCeilingsController : Controller
    {
        // GET: CustomerServiceCeilings
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new CustomerServiceCeilingsIndexVm
            {
                CustomerServiceCeilings = new List<CustomerServiceCeiling>
                {
                    new CustomerServiceCeiling
                    {
                        Id = 1,
                        CeilingName = "سقف الخدمات الأساسية",
                        Description = "تحديد الحد الأقصى للخدمات الأساسية المسموحة للعميل",
                        CreateDate = DateTime.Now.AddDays(-30),
                        UpdateDate = DateTime.Now.AddDays(-30),
                        Status = 1,
                        Notes = "سقف أساسي"
                    },
                    new CustomerServiceCeiling
                    {
                        Id = 2,
                        CeilingName = "سقف الخدمات المتقدمة",
                        Description = "تحديد الحد الأقصى للخدمات المتقدمة المسموحة للعميل",
                        CreateDate = DateTime.Now.AddDays(-29),
                        UpdateDate = DateTime.Now.AddDays(-29),
                        Status = 1,
                        Notes = "لخدمات خاصة"
                    },
                    new CustomerServiceCeiling
                    {
                        Id = 3,
                        CeilingName = "سقف الخدمات الخاصة",
                        Description = "تحديد الحد الأقصى للخدمات الخاصة المسموحة للعميل",
                        CreateDate = DateTime.Now.AddDays(-28),
                        UpdateDate = DateTime.Now.AddDays(-28),
                        Status = 1,
                        Notes = "للخدمات المميزة"
                    }
                }
            };

            return View(viewModel);
        }
    }
}