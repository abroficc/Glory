using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Inspinia.Models;
using Microsoft.AspNetCore.Authorization;

namespace Inspinia.Controllers
{
    [Authorize]
    public class WhatsAppMessageFormattingsController : Controller
    {
        // GET: WhatsAppMessageFormattings
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new WhatsAppMessageFormattingsIndexVm
            {
                WhatsAppMessageFormattings = new List<WhatsAppMessageFormatting>
                {
                    new WhatsAppMessageFormatting
                    {
                        Id = 1,
                        MessageTitle = "رسالة ترحيب واتساب",
                        MessageContent = "مرحباً بك في نظام واتساب لدينا",
                        MessageType = "ترحيب",
                        CreateDate = DateTime.Now.AddDays(-30),
                        UpdateDate = DateTime.Now.AddDays(-30),
                        Status = 1,
                        Notes = "رسالة ترحيب أساسية لواتساب"
                    },
                    new WhatsAppMessageFormatting
                    {
                        Id = 2,
                        MessageTitle = "رسالة تنبيه واتساب",
                        MessageContent = "تنبيه هام: يوجد تحديث في نظام واتساب",
                        MessageType = "تنبيه",
                        CreateDate = DateTime.Now.AddDays(-29),
                        UpdateDate = DateTime.Now.AddDays(-29),
                        Status = 1,
                        Notes = "للاستخدام عند التحديثات في واتساب"
                    },
                    new WhatsAppMessageFormatting
                    {
                        Id = 3,
                        MessageTitle = "رسالة إشعار واتساب",
                        MessageContent = "تم إتمام العملية بنجاح في واتساب",
                        MessageType = "إشعار",
                        CreateDate = DateTime.Now.AddDays(-28),
                        UpdateDate = DateTime.Now.AddDays(-28),
                        Status = 1,
                        Notes = "للإشعارات العامة في واتساب"
                    }
                }
            };

            return View(viewModel);
        }
    }
}