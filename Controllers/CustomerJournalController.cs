using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ASP.Net_Core_MVC.Full.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class CustomerJournalController : Controller
    {
        public IActionResult Index()
        {
            // Create sample data for the customer journal
            var vm = new TrustedCustomersIndexVm
            {
                TreeData = new List<object>
                {
                    new { 
                        id = "1", 
                        parent = "#", 
                        text = "يوميات العملاء", 
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
                        text = "يومية العميل #001", 
                        icon = "ti ti-file-dollar fs-lg text-success"
                    },
                    new { 
                        id = "4", 
                        parent = "1", 
                        text = "يومية العميل #002", 
                        icon = "ti ti-file-dollar fs-lg text-success"
                    },
                    new { 
                        id = "5", 
                        parent = "2", 
                        text = "أحمد محمد", 
                        icon = "ti ti-user fs-lg text-warning"
                    },
                    new { 
                        id = "6", 
                        parent = "2", 
                        text = "سارة عبدالله", 
                        icon = "ti ti-user fs-lg text-warning"
                    }
                }
            };
            
            return View(vm);
        }
    }
}