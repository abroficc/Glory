using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ASP.Net_Core_MVC.Full.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class AccountTreeController : Controller
    {
        public IActionResult Index()
        {
            // Create sample data for the account tree
            var vm = new AccountTreeIndexVm
            {
                TreeData = new List<object>
                {
                    new { 
                        id = "1", 
                        parent = "#", 
                        text = "الأصول", 
                        icon = "ti ti-folder-filled fs-lg text-warning",
                        state = new { opened = true }
                    },
                    new { 
                        id = "2", 
                        parent = "#", 
                        text = "الخصوم", 
                        icon = "ti ti-folder-filled fs-lg text-warning",
                        state = new { opened = true }
                    },
                    new { 
                        id = "3", 
                        parent = "#", 
                        text = "حقوق الملكية", 
                        icon = "ti ti-folder-filled fs-lg text-warning",
                        state = new { opened = true }
                    },
                    new { 
                        id = "4", 
                        parent = "1", 
                        text = "الأصول المتداولة", 
                        icon = "ti ti-folder-filled fs-lg text-warning"
                    },
                    new { 
                        id = "5", 
                        parent = "1", 
                        text = "الأصول الثابتة", 
                        icon = "ti ti-folder-filled fs-lg text-warning"
                    },
                    new { 
                        id = "6", 
                        parent = "4", 
                        text = "النقد والبنوك", 
                        icon = "ti ti-file-text fs-lg text-primary"
                    },
                    new { 
                        id = "7", 
                        parent = "4", 
                        text = "العملاء", 
                        icon = "ti ti-file-text fs-lg text-primary"
                    },
                    new { 
                        id = "8", 
                        parent = "2", 
                        text = "الخصوم المتداولة", 
                        icon = "ti ti-folder-filled fs-lg text-warning"
                    },
                    new { 
                        id = "9", 
                        parent = "2", 
                        text = "الخصوم الثابتة", 
                        icon = "ti ti-folder-filled fs-lg text-warning"
                    },
                    new { 
                        id = "10", 
                        parent = "3", 
                        text = "رأس المال", 
                        icon = "ti ti-file-text fs-lg text-primary"
                    }
                }
            };
            
            return View(vm);
        }
    }
}