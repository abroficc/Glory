using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Inspinia.Controllers
{
    [Authorize]
    public class YemenMobilePackagesController : Controller
    {
        public IActionResult Index()
        {
            // For now, just return the view without any specific model data
            // The YemenMobilePackages page is primarily client-side rendered
            return View();
        }
    }
}