using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inspinia.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class ArchivesController : Controller
    {
        // GET: Archives
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new ArchivesIndexVm
            {
                Archives = new List<Archive>
                {
                    new Archive
                    {
                        Id = 1,
                        ArchiveName = "الأرشيف الأساسي",
                        Description = "تحديد الحد الأقصى للأرشيف الأساسي",
                        CreateDate = DateTime.Now.AddDays(-30),
                        UpdateDate = DateTime.Now.AddDays(-30),
                        Status = 1,
                        Notes = "أرشيف أساسي"
                    },
                    new Archive
                    {
                        Id = 2,
                        ArchiveName = "الأرشيف المتقدم",
                        Description = "تحديد الحد الأقصى للأرشيف المتقدم",
                        CreateDate = DateTime.Now.AddDays(-29),
                        UpdateDate = DateTime.Now.AddDays(-29),
                        Status = 1,
                        Notes = "لأرشيف متقدم"
                    },
                    new Archive
                    {
                        Id = 3,
                        ArchiveName = "الأرشيف الخاص",
                        Description = "تحديد الحد الأقصى للأرشيف الخاص",
                        CreateDate = DateTime.Now.AddDays(-28),
                        UpdateDate = DateTime.Now.AddDays(-28),
                        Status = 1,
                        Notes = "للأرشيف المميز"
                    }
                }
            };

            return View(viewModel);
        }
    }
}