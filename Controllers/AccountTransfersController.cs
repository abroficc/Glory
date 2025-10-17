using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ASP.Net_Core_MVC.Full.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class AccountTransfersController : Controller
    {
        public IActionResult Index()
        {
            // Create sample data for the account transfers
            var vm = new TrustedCustomersIndexVm
            {
                TreeData = new List<object>
                {
                    new { 
                        id = "1", 
                        parent = "#", 
                        text = "التحويل بين الحسابات", 
                        icon = "ti ti-transfer-in fs-lg text-primary",
                        state = new { opened = true }
                    },
                    new { 
                        id = "2", 
                        parent = "#", 
                        text = "الحسابات", 
                        icon = "ti ti-chart-bar fs-lg text-primary",
                        state = new { opened = true }
                    },
                    new { 
                        id = "3", 
                        parent = "1", 
                        text = "تحويل بنكي #001", 
                        icon = "ti ti-transfer-in fs-lg text-success"
                    },
                    new { 
                        id = "4", 
                        parent = "1", 
                        text = "تحويل بنكي #002", 
                        icon = "ti ti-transfer-in fs-lg text-success"
                    },
                    new { 
                        id = "5", 
                        parent = "2", 
                        text = "حساب أصول", 
                        icon = "ti ti-chart-pie fs-lg text-warning"
                    },
                    new { 
                        id = "6", 
                        parent = "2", 
                        text = "حساب خصوم", 
                        icon = "ti ti-chart-pie fs-lg text-warning"
                    }
                }
            };
            
            return View(vm);
        }
    }
}