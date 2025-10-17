using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inspinia.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class PaymentSuspensionRescuePrinciplesController : Controller
    {
        // GET: PaymentSuspensionRescuePrinciples
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new PaymentSuspensionRescuePrinciplesIndexVm
            {
                PaymentSuspensionRescuePrinciples = new List<PaymentSuspensionRescuePrinciple>
                {
                    new PaymentSuspensionRescuePrinciple
                    {
                        Id = 1,
                        PrincipleName = "مبدأ الإنقاذ الأساسي",
                        Description = "إعادة تفعيل الحسابات المعلقة بسبب عدم التسديد",
                        Conditions = "عدم التسديد لأكثر من 30 يوم",
                        CreateDate = DateTime.Now.AddDays(-30),
                        UpdateDate = DateTime.Now.AddDays(-30),
                        Status = 1,
                        Notes = "للحالات العادية"
                    },
                    new PaymentSuspensionRescuePrinciple
                    {
                        Id = 2,
                        PrincipleName = "مبدأ الإنقاذ المتقدم",
                        Description = "إعادة تفعيل الحسابات المعلقة مع شروط خاصة",
                        Conditions = "عدم التسديد لأكثر من 45 يوم مع دفع جزء من المبلغ",
                        CreateDate = DateTime.Now.AddDays(-29),
                        UpdateDate = DateTime.Now.AddDays(-29),
                        Status = 1,
                        Notes = "للعملاء المميزين"
                    },
                    new PaymentSuspensionRescuePrinciple
                    {
                        Id = 3,
                        PrincipleName = "مبدأ الإنقاذ الخاص",
                        Description = "إعادة تفعيل الحسابات المعلقة مع تخفيضات",
                        Conditions = "عدم التسديد لأكثر من 60 يوم مع تخفيض 20% من المبلغ",
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