using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Inspinia.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            // For now, just return the view without any specific model data
            // The Categories page is primarily client-side rendered
            return View();
        }
    }
}