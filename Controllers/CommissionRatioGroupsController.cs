using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inspinia.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class CommissionRatioGroupsController : Controller
    {
        // GET: CommissionRatioGroups
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new CommissionRatioGroupsIndexVm
            {
                CommissionRatioGroups = new List<CommissionRatioGroup>
                {
                    new CommissionRatioGroup
                    {
                        Id = 1,
                        GroupName = "مجموعة العمولة الأساسية",
                        Description = "نسبة العمولة الأساسية للوكلاء",
                        RatioPercentage = 5.5m,
                        CreateDate = DateTime.Now.AddDays(-30),
                        UpdateDate = DateTime.Now.AddDays(-30),
                        Status = 1,
                        Notes = "لكل الوكلاء الجدد"
                    },
                    new CommissionRatioGroup
                    {
                        Id = 2,
                        GroupName = "مجموعة العمولة المتقدمة",
                        Description = "نسبة العمولة المتقدمة للوكلاء المميزين",
                        RatioPercentage = 7.25m,
                        CreateDate = DateTime.Now.AddDays(-29),
                        UpdateDate = DateTime.Now.AddDays(-29),
                        Status = 1,
                        Notes = "للوكلاء المميزين"
                    },
                    new CommissionRatioGroup
                    {
                        Id = 3,
                        GroupName = "مجموعة العمولة الخاصة",
                        Description = "نسبة العمولة الخاصة للوكلاء الكبار",
                        RatioPercentage = 10.0m,
                        CreateDate = DateTime.Now.AddDays(-28),
                        UpdateDate = DateTime.Now.AddDays(-28),
                        Status = 1,
                        Notes = "للوكلاء الكبار فقط"
                    }
                }
            };

            return View(viewModel);
        }
    }
}