using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ASP.Net_Core_MVC.Full.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class BalanceDeductionVoucherController : Controller
    {
        public IActionResult Index()
        {
            // Create sample data for the balance deduction voucher
            var vm = new TrustedCustomersIndexVm
            {
                TreeData = new List<object>
                {
                    new { 
                        id = "1", 
                        parent = "#", 
                        text = "سندات الخصم", 
                        icon = "ti ti-file-dollar fs-lg text-primary",
                        state = new { opened = true }
                    },
                    new { 
                        id = "2", 
                        parent = "#", 
                        text = "العملاء", 
                        icon = "ti ti-users fs-lg text-primary",
                        state = new { opened = true }
                    },
                    new { 
                        id = "3", 
                        parent = "1", 
                        text = "سند خصم #001", 
                        icon = "ti ti-file-dollar fs-lg text-success"
                    },
                    new { 
                        id = "4", 
                        parent = "1", 
                        text = "سند خصم #002", 
                        icon = "ti ti-file-dollar fs-lg text-success"
                    },
                    new { 
                        id = "5", 
                        parent = "2", 
                        text = "شركة تقنية المعلومات", 
                        icon = "ti ti-user fs-lg text-warning"
                    },
                    new { 
                        id = "6", 
                        parent = "2", 
                        text = "مؤسسة البرمجيات", 
                        icon = "ti ti-user fs-lg text-warning"
                    }
                }
            };
            
            return View(vm);
        }
    }
}