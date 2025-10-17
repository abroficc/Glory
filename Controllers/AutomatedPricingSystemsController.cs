using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inspinia.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class AutomatedPricingSystemsController : Controller
    {
        // GET: AutomatedPricingSystems
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new AutomatedPricingSystemsIndexVm
            {
                AutomatedPricingSystems = new List<AutomatedPricingSystem>
                {
                    new AutomatedPricingSystem
                    {
                        Id = 1,
                        SystemName = "نظام التسعير الأساسي",
                        Description = "نظام التسعير الأساسي للخدمات",
                        BasePrice = 100.00m,
                        CreateDate = DateTime.Now.AddDays(-30),
                        UpdateDate = DateTime.Now.AddDays(-30),
                        Status = 1,
                        Notes = "للخدمات الأساسية"
                    },
                    new AutomatedPricingSystem
                    {
                        Id = 2,
                        SystemName = "نظام التسعير المتقدم",
                        Description = "نظام التسعير المتقدم مع خصومات",
                        BasePrice = 150.00m,
                        CreateDate = DateTime.Now.AddDays(-29),
                        UpdateDate = DateTime.Now.AddDays(-29),
                        Status = 1,
                        Notes = "للخدمات المتقدمة"
                    },
                    new AutomatedPricingSystem
                    {
                        Id = 3,
                        SystemName = "نظام التسعير الخاص",
                        Description = "نظام التسعير الخاص للعملاء الكبار",
                        BasePrice = 200.00m,
                        CreateDate = DateTime.Now.AddDays(-28),
                        UpdateDate = DateTime.Now.AddDays(-28),
                        Status = 1,
                        Notes = "للعملاء الكبار"
                    }
                }
            };

            return View(viewModel);
        }
    }
}