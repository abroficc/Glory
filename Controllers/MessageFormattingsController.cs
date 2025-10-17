using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inspinia.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class MessageFormattingsController : Controller
    {
        // GET: MessageFormattings
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new MessageFormattingsIndexVm
            {
                MessageFormattings = new List<MessageFormatting>
                {
                    new MessageFormatting
                    {
                        Id = 1,
                        MessageTitle = "رسالة ترحيب",
                        MessageContent = "مرحباً بك في نظامنا",
                        MessageType = "ترحيب",
                        CreateDate = DateTime.Now.AddDays(-30),
                        UpdateDate = DateTime.Now.AddDays(-30),
                        Status = 1,
                        Notes = "رسالة ترحيب أساسية"
                    },
                    new MessageFormatting
                    {
                        Id = 2,
                        MessageTitle = "رسالة تنبيه",
                        MessageContent = "تنبيه هام: يوجد تحديث في النظام",
                        MessageType = "تنبيه",
                        CreateDate = DateTime.Now.AddDays(-29),
                        UpdateDate = DateTime.Now.AddDays(-29),
                        Status = 1,
                        Notes = "للاستخدام عند التحديثات"
                    },
                    new MessageFormatting
                    {
                        Id = 3,
                        MessageTitle = "رسالة إشعار",
                        MessageContent = "تم إتمام العملية بنجاح",
                        MessageType = "إشعار",
                        CreateDate = DateTime.Now.AddDays(-28),
                        UpdateDate = DateTime.Now.AddDays(-28),
                        Status = 1,
                        Notes = "للإشعارات العامة"
                    }
                }
            };

            return View(viewModel);
        }
    }
}