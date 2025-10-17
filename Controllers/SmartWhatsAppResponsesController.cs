using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Inspinia.Models;
using Microsoft.AspNetCore.Authorization;

namespace Inspinia.Controllers
{
    [Authorize]
    public class SmartWhatsAppResponsesController : Controller
    {
        // GET: SmartWhatsAppResponses
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new SmartWhatsAppResponsesIndexVm
            {
                SmartWhatsAppResponses = new List<SmartWhatsAppResponse>
                {
                    new SmartWhatsAppResponse
                    {
                        Id = 1,
                        Keyword = "السعر",
                        Response = "أسعارنا تنافسية وتحتاج للاستعلام المباشر",
                        Category = "استفسار",
                        CreateDate = DateTime.Now.AddDays(-30),
                        UpdateDate = DateTime.Now.AddDays(-30),
                        Status = 1,
                        Notes = "رد تلقائي عند استفسار عن الأسعار"
                    },
                    new SmartWhatsAppResponse
                    {
                        Id = 2,
                        Keyword = "العنوان",
                        Response = "موقعنا في شارع الحرية، أمام البنك التجاري",
                        Category = "معلومات",
                        CreateDate = DateTime.Now.AddDays(-29),
                        UpdateDate = DateTime.Now.AddDays(-29),
                        Status = 1,
                        Notes = "رد تلقائي عند سؤال عن العنوان"
                    },
                    new SmartWhatsAppResponse
                    {
                        Id = 3,
                        Keyword = "السلام عليكم",
                        Response = "وعليكم السلام ورحمة الله وبركاته، كيف يمكنني مساعدتك؟",
                        Category = "تحية",
                        CreateDate = DateTime.Now.AddDays(-28),
                        UpdateDate = DateTime.Now.AddDays(-28),
                        Status = 1,
                        Notes = "رد تلقائي على التحية"
                    }
                }
            };

            return View(viewModel);
        }
    }
}