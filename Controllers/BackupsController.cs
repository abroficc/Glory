using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inspinia.Models;

namespace Inspinia.Controllers
{
    [Authorize]
    public class BackupsController : Controller
    {
        // GET: Backups
        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new BackupsIndexVm
            {
                Backups = new List<Backup>
                {
                    new Backup
                    {
                        Id = 1,
                        BackupName = "النسخة الاحتياطية الأساسية",
                        Description = "تحديد الحد الأقصى للنسخة الاحتياطية الأساسية",
                        CreateDate = DateTime.Now.AddDays(-30),
                        UpdateDate = DateTime.Now.AddDays(-30),
                        Status = 1,
                        Notes = "نسخة احتياطية أساسية"
                    },
                    new Backup
                    {
                        Id = 2,
                        BackupName = "النسخة الاحتياطية المتقدمة",
                        Description = "تحديد الحد الأقصى للنسخة الاحتياطية المتقدمة",
                        CreateDate = DateTime.Now.AddDays(-29),
                        UpdateDate = DateTime.Now.AddDays(-29),
                        Status = 1,
                        Notes = "لنسخة احتياطية متقدمة"
                    },
                    new Backup
                    {
                        Id = 3,
                        BackupName = "النسخة الاحتياطية الخاصة",
                        Description = "تحديد الحد الأقصى للنسخة الاحتياطية الخاصة",
                        CreateDate = DateTime.Now.AddDays(-28),
                        UpdateDate = DateTime.Now.AddDays(-28),
                        Status = 1,
                        Notes = "للنسخة الاحتياطية المميزة"
                    }
                }
            };

            return View(viewModel);
        }
    }
}