using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inspinia.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class MonthlyTransfersController : Controller
    {
        // GET: MonthlyTransfers
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new MonthlyTransfersIndexVm
            {
                MonthlyTransfers = new List<MonthlyTransfer>
                {
                    new MonthlyTransfer
                    {
                        Id = 1,
                        TransferName = "الترحيل الشهري الأساسي",
                        Description = "تحديد الحد الأقصى للترحيل الشهري الأساسي",
                        CreateDate = DateTime.Now.AddDays(-30),
                        UpdateDate = DateTime.Now.AddDays(-30),
                        Status = 1,
                        Notes = "ترحيل أساسي شهري"
                    },
                    new MonthlyTransfer
                    {
                        Id = 2,
                        TransferName = "الترحيل الشهري المتقدم",
                        Description = "تحديد الحد الأقصى للترحيل الشهري المتقدم",
                        CreateDate = DateTime.Now.AddDays(-29),
                        UpdateDate = DateTime.Now.AddDays(-29),
                        Status = 1,
                        Notes = "لترحيل متقدم شهري"
                    },
                    new MonthlyTransfer
                    {
                        Id = 3,
                        TransferName = "الترحيل الشهري الخاص",
                        Description = "تحديد الحد الأقصى للترحيل الشهري الخاص",
                        CreateDate = DateTime.Now.AddDays(-28),
                        UpdateDate = DateTime.Now.AddDays(-28),
                        Status = 1,
                        Notes = "للترحيل المميز الشهري"
                    }
                }
            };

            return View(viewModel);
        }
    }
}