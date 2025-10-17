using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inspinia.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class EmployeeDevicesController : Controller
    {
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new EmployeeDevicesIndexVm
            {
                EmployeeDevices = new List<EmployeeDevice>
                {
                    new EmployeeDevice
                    {
                        Id = 1,
                        EmployeeId = 1,
                        EmployeeName = "أحمد محمد",
                        DeviceTypeId = 1,
                        DeviceType = "لابتوب",
                        SerialNumber = "LAP123456",
                        DeliveryDate = DateTime.Now.AddDays(-30),
                        Status = 1,
                        Notes = "جهاز تم تسليمه في يناير"
                    },
                    new EmployeeDevice
                    {
                        Id = 2,
                        EmployeeId = 2,
                        EmployeeName = "محمد علي",
                        DeviceTypeId = 2,
                        DeviceType = "هاتف ذكي",
                        SerialNumber = "PHN789012",
                        DeliveryDate = DateTime.Now.AddDays(-29),
                        Status = 1,
                        Notes = "هاتف شركة"
                    },
                    new EmployeeDevice
                    {
                        Id = 3,
                        EmployeeId = 3,
                        EmployeeName = "خالد عبدالله",
                        DeviceTypeId = 3,
                        DeviceType = "تابلت",
                        SerialNumber = "TAB345678",
                        DeliveryDate = DateTime.Now.AddDays(-28),
                        Status = 0,
                        Notes = "جهاز معطل"
                    }
                }
            };

            return View(viewModel);
        }
    }
}