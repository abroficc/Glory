using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inspinia.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class PaymentDistributionPrincipleController : Controller
    {
        // GET: PaymentDistributionPrinciple
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new PaymentDistributionPrincipleIndexVm
            {
                PaymentDistributionPrinciples = new List<PaymentDistributionPrinciple>
                {
                    new PaymentDistributionPrinciple
                    {
                        Id = 1,
                        PrincipleName = "التحقق من الرصيد",
                        Description = "التحقق من رصيد العميل قبل تنفيذ العملية",
                        CreateDate = DateTime.Now.AddDays(-30),
                        UpdateDate = DateTime.Now.AddDays(-30),
                        Status = 1,
                        Notes = "مبدأ أساسي"
                    },
                    new PaymentDistributionPrinciple
                    {
                        Id = 2,
                        PrincipleName = "الحد الأقصى للديون",
                        Description = "تحديد حد أقصى للديون المسموحة للعميل",
                        CreateDate = DateTime.Now.AddDays(-29),
                        UpdateDate = DateTime.Now.AddDays(-29),
                        Status = 1,
                        Notes = "لمنع الديون الكبيرة"
                    },
                    new PaymentDistributionPrinciple
                    {
                        Id = 3,
                        PrincipleName = "التحقق من الهوية",
                        Description = "التحقق من هوية العميل قبل تنفيذ العملية",
                        CreateDate = DateTime.Now.AddDays(-28),
                        UpdateDate = DateTime.Now.AddDays(-28),
                        Status = 1,
                        Notes = "للأمان"
                    }
                }
            };

            return View(viewModel);
        }
    }
}