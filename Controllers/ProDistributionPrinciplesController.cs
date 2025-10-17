using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inspinia.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class ProDistributionPrinciplesController : Controller
    {
        // GET: ProDistributionPrinciples
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new ProDistributionPrinciplesIndexVm
            {
                ProDistributionPrinciples = new List<ProDistributionPrinciple>
                {
                    new ProDistributionPrinciple
                    {
                        Id = 1,
                        PrincipleName = "مبدأ التوزيع الأساسي",
                        Description = "توزيع الأرباح حسب النسبة المحددة",
                        DistributionRules = "توزيع 70% للأرباح الشهرية",
                        CreateDate = DateTime.Now.AddDays(-30),
                        UpdateDate = DateTime.Now.AddDays(-30),
                        Status = 1,
                        Notes = "للتوزيع العادي"
                    },
                    new ProDistributionPrinciple
                    {
                        Id = 2,
                        PrincipleName = "مبدأ التوزيع المتقدم",
                        Description = "توزيع الأرباح حسب الأداء",
                        DistributionRules = "توزيع 80% للأرباح مع مكافآت الأداء",
                        CreateDate = DateTime.Now.AddDays(-29),
                        UpdateDate = DateTime.Now.AddDays(-29),
                        Status = 1,
                        Notes = "للتوزيع المتقدم"
                    },
                    new ProDistributionPrinciple
                    {
                        Id = 3,
                        PrincipleName = "مبدأ التوزيع الخاص",
                        Description = "توزيع الأرباح حسب المساهمة",
                        DistributionRules = "توزيع 90% للأرباح مع مشاركة في القرار",
                        CreateDate = DateTime.Now.AddDays(-28),
                        UpdateDate = DateTime.Now.AddDays(-28),
                        Status = 1,
                        Notes = "للتوزيع الخاص"
                    }
                }
            };

            return View(viewModel);
        }
    }
}