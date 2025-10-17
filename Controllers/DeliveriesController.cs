using Microsoft.AspNetCore.Mvc;
using Inspinia.Models;
using System;
using System.Collections.Generic;

namespace Inspinia.Controllers
{
    [Route("[controller]/[action]")]
    public class DeliveriesController : Controller
    {
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new DeliveriesIndexVm
            {
                Deliveries = new List<Delivery>
                {
                    new Delivery
                    {
                        Id = 1,
                        CustomerName = "أحمد محمد",
                        DeliveryDate = DateTime.Now.AddDays(-5),
                        Status = 1,
                        Notes = "توصيل إلى المنزل"
                    },
                    new Delivery
                    {
                        Id = 2,
                        CustomerName = "محمد علي",
                        DeliveryDate = DateTime.Now.AddDays(-3),
                        Status = 1,
                        Notes = "توصيل إلى العمل"
                    },
                    new Delivery
                    {
                        Id = 3,
                        CustomerName = "خالد عبدالله",
                        DeliveryDate = DateTime.Now.AddDays(-1),
                        Status = 0,
                        Notes = "توصيل معلق"
                    }
                }
            };

            return View(viewModel);
        }
    }
}
