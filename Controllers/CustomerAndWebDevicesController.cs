using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inspinia.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class CustomerAndWebDevicesController : Controller
    {
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new CustomerAndWebDevicesIndexVm
            {
                CustomerDevices = new List<CustomerDevice>
                {
                    new CustomerDevice
                    {
                        Id = 1,
                        CustomerId = 1,
                        CustomerName = "شركة التكنولوجيا المتقدمة",
                        DeviceTypeId = 1,
                        DeviceType = "خادم",
                        SerialNumber = "SRV123456",
                        DeliveryDate = DateTime.Now.AddDays(-30),
                        Status = 1,
                        Notes = "خادم تم تسليمه في يناير"
                    },
                    new CustomerDevice
                    {
                        Id = 2,
                        CustomerId = 2,
                        CustomerName = "مجموعة الاتصالات الحديثة",
                        DeviceTypeId = 2,
                        DeviceType = "جهاز شبكة",
                        SerialNumber = "NET789012",
                        DeliveryDate = DateTime.Now.AddDays(-29),
                        Status = 1,
                        Notes = "جهاز شبكة شركة"
                    },
                    new CustomerDevice
                    {
                        Id = 3,
                        CustomerId = 3,
                        CustomerName = "مؤسسة البرمجيات الرقمية",
                        DeviceTypeId = 3,
                        DeviceType = "جهاز تخزين",
                        SerialNumber = "STO345678",
                        DeliveryDate = DateTime.Now.AddDays(-28),
                        Status = 0,
                        Notes = "جهاز معطل"
                    }
                },
                WebDevices = new List<WebDevice>
                {
                    new WebDevice
                    {
                        Id = 1,
                        DeviceTypeId = 1,
                        DeviceType = "خادم ويب",
                        SerialNumber = "WEB123456",
                        PurchaseDate = DateTime.Now.AddYears(-2),
                        WarrantyExpiryDate = DateTime.Now.AddMonths(6),
                        Status = 1,
                        Notes = "خادم ويب رئيسي"
                    },
                    new WebDevice
                    {
                        Id = 2,
                        DeviceTypeId = 2,
                        DeviceType = "جهاز شبكة",
                        SerialNumber = "NET789012",
                        PurchaseDate = DateTime.Now.AddYears(-1),
                        WarrantyExpiryDate = DateTime.Now.AddMonths(12),
                        Status = 1,
                        Notes = "جهاز شبكة للويب"
                    },
                    new WebDevice
                    {
                        Id = 3,
                        DeviceTypeId = 3,
                        DeviceType = "جهاز أمان",
                        SerialNumber = "SEC345678",
                        PurchaseDate = DateTime.Now.AddMonths(-6),
                        WarrantyExpiryDate = DateTime.Now.AddMonths(18),
                        Status = 0,
                        Notes = "جهاز أمان معطل"
                    }
                }
            };

            return View(viewModel);
        }
    }
}