using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Inspinia.Models;
using Microsoft.AspNetCore.Authorization;

namespace Inspinia.Controllers
{
    [Authorize]
    public class SmsMessagesController : Controller
    {
        // GET: SmsMessages
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new object(); // Placeholder, replace with appropriate view model

            return View(viewModel);
        }
    }
}