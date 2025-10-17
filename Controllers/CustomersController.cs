using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ASP.Net_Core_MVC.Full.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            // Create sample data to prevent NullReferenceException
            var customers = new List<CustomerAgentModel>
            {
                new CustomerAgentModel
                {
                    Id = 1,
                    Number = "001",
                    Name = "أحمد محمد",
                    StoreName = "محل أحمد",
                    PhoneNumber = "0501234567",
                    Address = "الرياض",
                    Status = "نشط",
                    GroupName = "مجموعة 1",
                    GroupType = "عمولة 1",
                    Device = "mobile",
                    Operations = "بيع",
                    SalesAmount = 5000,
                    AmountToPay = 1000,
                    Agent = "الوكيل 1",
                    Balance = 4000,
                    Connected = true,
                    AccountType = "ريال سعودي",
                    AccountBalance = 4000
                },
                new CustomerAgentModel
                {
                    Id = 2,
                    Number = "002",
                    Name = "سارة عبدالله",
                    StoreName = "محل سارة",
                    PhoneNumber = "0509876543",
                    Address = "جدة",
                    Status = "نشط",
                    GroupName = "مجموعة 2",
                    GroupType = "عمولة 2",
                    Device = "desktop",
                    Operations = "شراء",
                    SalesAmount = 3000,
                    AmountToPay = 500,
                    Agent = "الوكيل 2",
                    Balance = 2500,
                    Connected = false,
                    AccountType = "دولار أمريكي",
                    AccountBalance = 2500
                }
            };
            
            return View(customers);
        }
        
        public IActionResult Details() => View();
        public IActionResult Edit() => View();
        public IActionResult Add() => View();
        
        [HttpPost]
        public IActionResult Add(CustomerAgentModel model)
        {
            // In a real application, you would save the customer to a database
            // For demo purposes, we'll just return success
            return Json(new { success = true, message = "تم إضافة العميل بنجاح" });
        }
    }
}