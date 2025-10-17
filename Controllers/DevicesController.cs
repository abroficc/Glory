using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inspinia.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class DevicesController : Controller
    {
        // GET: Devices
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new DevicesIndexVm
            {
                Devices = new List<Device>
                {
                    new Device
                    {
                        Id = 1,
                        DeviceName = "جهاز كمبيوتر محمول",
                        MobileNumber = "777123456",
                        DeviceNumber = "SN123456789",
                        SerialNumber = "SN123456789",
                        DeviceType = "كمبيوتر محمول",
                        IsWorking = true,
                        QueueNumber = 101,
                        Balance = 1500.50m,
                        Account = "حساب 1",
                        IsBusy = false,
                        Network = "شبكة 1",
                        SimCode = "SIM001",
                        MinAmount = 100.00m,
                        Coverage = "تغطية كاملة",
                        PurchaseDate = DateTime.Now.AddDays(-30),
                        WarrantyExpiryDate = DateTime.Now.AddMonths(12),
                        Status = 1,
                        Notes = "جهاز جديد"
                    },
                    new Device
                    {
                        Id = 2,
                        DeviceName = "جهاز كمبيوتر مكتبي",
                        MobileNumber = "777987654",
                        DeviceNumber = "SN987654321",
                        SerialNumber = "SN987654321",
                        DeviceType = "كمبيوتر مكتبي",
                        IsWorking = true,
                        QueueNumber = 102,
                        Balance = 2500.75m,
                        Account = "حساب 2",
                        IsBusy = true,
                        Network = "شبكة 2",
                        SimCode = "SIM002",
                        MinAmount = 200.00m,
                        Coverage = "تغطية جزئية",
                        PurchaseDate = DateTime.Now.AddDays(-60),
                        WarrantyExpiryDate = DateTime.Now.AddMonths(6),
                        Status = 1,
                        Notes = "جهاز مستعمل"
                    },
                    new Device
                    {
                        Id = 3,
                        DeviceName = "جهاز طباعة",
                        MobileNumber = "777456789",
                        DeviceNumber = "SN456789123",
                        SerialNumber = "SN456789123",
                        DeviceType = "طابعة",
                        IsWorking = false,
                        QueueNumber = 103,
                        Balance = 500.00m,
                        Account = "حساب 3",
                        IsBusy = false,
                        Network = "شبكة 3",
                        SimCode = "SIM003",
                        MinAmount = 50.00m,
                        Coverage = "بدون تغطية",
                        PurchaseDate = DateTime.Now.AddDays(-90),
                        WarrantyExpiryDate = DateTime.Now.AddMonths(3),
                        Status = 0,
                        Notes = "جهاز معطل"
                    }
                }
            };

            return View(viewModel);
        }
    }
}