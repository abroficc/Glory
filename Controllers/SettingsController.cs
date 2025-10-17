using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Glory77.Models;
using Glory77.Data;
using Microsoft.EntityFrameworkCore;

namespace Inspinia.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SettingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Get the first basic setting or create a new one if none exists
            var basicSetting = _context.BasicSettings.FirstOrDefault() ?? new BasicSetting();

            var vm = new BasicSettingsIndexVm
            {
                BasicSetting = basicSetting,
                TreeData = new List<object>
                {
                    new { 
                        id = "1", 
                        parent = "#", 
                        text = "الإعدادات", 
                        icon = "ti ti-settings fs-lg text-primary",
                        state = new { opened = true }
                    },
                    new { 
                        id = "2", 
                        parent = "1", 
                        text = "الإعدادات الأساسية", 
                        icon = "ti ti-tool fs-lg text-success"
                    },
                    new { 
                        id = "3", 
                        parent = "1", 
                        text = "إعدادات الأمان", 
                        icon = "ti ti-shield fs-lg text-warning"
                    },
                    new { 
                        id = "4", 
                        parent = "1", 
                        text = "إعدادات الشبكة", 
                        icon = "ti ti-network fs-lg text-info"
                    }
                }
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult GetBasicSetting(int id)
        {
            var setting = _context.BasicSettings.FirstOrDefault(s => s.Id == id);
            if (setting == null)
            {
                return Json(new { success = false, message = "الإعدادات غير موجودة" });
            }

            return Json(new { success = true, data = setting });
        }

        [HttpPost]
        public IActionResult SaveBasicSettings(BasicSetting model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    // New setting
                    model.CreatedAt = DateTime.Now;
                    _context.BasicSettings.Add(model);
                }
                else
                {
                    // Update existing setting
                    var existingSetting = _context.BasicSettings.FirstOrDefault(s => s.Id == model.Id);
                    if (existingSetting != null)
                    {
                        // Update properties
                        _context.Entry(existingSetting).CurrentValues.SetValues(model);
                        existingSetting.UpdatedAt = DateTime.Now;
                    }
                }

                _context.SaveChanges();
                return Json(new { success = true, message = "تم حفظ الإعدادات بنجاح" });
            }

            return Json(new { success = false, message = "حدث خطأ في التحقق من البيانات" });
        }
    }
}