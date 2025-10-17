using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Inspinia.Models;
using Microsoft.AspNetCore.Authorization;

namespace Inspinia.Controllers
{
    [Authorize]
    public class WhatsAppMarketingController : Controller
    {
        // GET: WhatsAppMarketing
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new WhatsAppMarketingIndexVm
            {
                WhatsAppMarketingCampaigns = new List<WhatsAppMarketingCampaign>
                {
                    new WhatsAppMarketingCampaign
                    {
                        Id = 1,
                        CampaignName = "عرض العيد",
                        Message = "خصم خاص بمناسبة العيد على جميع الخدمات حتى 30% OFF",
                        TargetGroup = "جميع العملاء",
                        ScheduleDate = DateTime.Now.AddDays(1),
                        Status = 1,
                        Notes = "عرض العيد السنوي"
                    },
                    new WhatsAppMarketingCampaign
                    {
                        Id = 2,
                        CampaignName = "عروض نهاية الأسبوع",
                        Message = "عروض خاصة في عطلة نهاية الأسبوع، اكتشف المزيد الآن",
                        TargetGroup = "العملاء النشطين",
                        ScheduleDate = DateTime.Now.AddDays(2),
                        Status = 1,
                        Notes = "عروض نهاية الأسبوع"
                    },
                    new WhatsAppMarketingCampaign
                    {
                        Id = 3,
                        CampaignName = "ترحيب بالعملاء الجدد",
                        Message = "مرحباً بك في خدماتنا! احصل على خصم 20% على أول عملية",
                        TargetGroup = "العملاء الجدد",
                        ScheduleDate = DateTime.Now.AddDays(3),
                        Status = 1,
                        Notes = "رسالة ترحيب للعملاء الجدد"
                    }
                }
            };

            return View(viewModel);
        }
    }
}