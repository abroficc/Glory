using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Glory77.Models;  // Changed from Inspinia.Models to Glory77.Models
using Microsoft.AspNetCore.Authorization;

namespace Glory77.Controllers  // Changed from Inspinia.Controllers to Glory77.Controllers
{
    [Authorize]
    public class SuppliesDiscountsController : Controller
    {
        // GET: SuppliesDiscounts
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new SuppliesDiscountsIndexVm
            {
                SuppliesDiscounts = new List<SuppliesDiscount>
                {
                    new SuppliesDiscount
                    {
                        Id = 1,
                        Name = "خصميات أساسية",
                        Description = "خصومات أساسية للعملاء المنتظمين",
                        DiscountPercentage = 5.0m,
                        FixedDiscount = 100.00m,
                        CreateDate = DateTime.Now.AddDays(-30),
                        UpdateDate = DateTime.Now.AddDays(-30),
                        Status = 1,
                        Notes = "للعملاء الجدد"
                    },
                    new SuppliesDiscount
                    {
                        Id = 2,
                        Name = "خصميات متقدمة",
                        Description = "خصومات متقدمة للعملاء المميزين",
                        DiscountPercentage = 10.0m,
                        FixedDiscount = 250.00m,
                        CreateDate = DateTime.Now.AddDays(-29),
                        UpdateDate = DateTime.Now.AddDays(-29),
                        Status = 1,
                        Notes = "للعملاء المميزين"
                    },
                    new SuppliesDiscount
                    {
                        Id = 3,
                        Name = "توريدات أساسية",
                        Description = "توريدات أساسية للموردين",
                        DiscountPercentage = 2.5m,
                        FixedDiscount = 50.00m,
                        CreateDate = DateTime.Now.AddDays(-28),
                        UpdateDate = DateTime.Now.AddDays(-28),
                        Status = 1,
                        Notes = "للموردين الجدد"
                    }
                }
            };

            return View(viewModel);
        }
    }
}