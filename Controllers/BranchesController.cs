using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ASP.Net_Core_MVC.Full.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class BranchesController : Controller
    {
        public IActionResult Index()
        {
            // Create sample data for the branches tree
            var vm = new BranchesIndexVm
            {
                TreeData = new List<object>
                {
                    new { 
                        id = "1", 
                        parent = "#", 
                        text = "فرع صنعاء", 
                        icon = "ti ti-building fs-lg text-primary",
                        state = new { opened = true }
                    },
                    new { 
                        id = "2", 
                        parent = "#", 
                        text = "فرع عدن", 
                        icon = "ti ti-building fs-lg text-primary",
                        state = new { opened = true }
                    },
                    new { 
                        id = "3", 
                        parent = "#", 
                        text = "فرع تعز", 
                        icon = "ti ti-building fs-lg text-primary",
                        state = new { opened = true }
                    },
                    new { 
                        id = "4", 
                        parent = "#", 
                        text = "فرع حضرموت", 
                        icon = "ti ti-building fs-lg text-primary",
                        state = new { opened = true }
                    }
                }
            };
            
            return View(vm);
        }
    }
}