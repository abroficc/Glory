using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Glory77.Models;
using Glory77.Data;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Inspinia.Models;
using Microsoft.AspNetCore.Authorization;

namespace Glory77.Controllers
{
    [Authorize]
    public class PaymentDistributionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentDistributionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Create sample data for demonstration
            var viewModel = new PaymentDistributionIndexVm
            {
                PaymentDistributions = new List<PaymentDistribution>
                {
                    new PaymentDistribution
                    {
                        Id = 1,
                        PrincipleName = "توزيع مبدئي للتسديدات",
                        Description = "توزيع التسديدات حسب أولوية العميل",
                        CreateDate = DateTime.Now.AddDays(-30),
                        UpdateDate = DateTime.Now.AddDays(-30),
                        Status = 1,
                        Notes = "مبدأ أساسي"
                    },
                    new PaymentDistribution
                    {
                        Id = 2,
                        PrincipleName = "توزيع متقدم للتسديدات",
                        Description = "توزيع التسديدات حسب قيمة الدين",
                        CreateDate = DateTime.Now.AddDays(-29),
                        UpdateDate = DateTime.Now.AddDays(-29),
                        Status = 1,
                        Notes = "للحالات الخاصة"
                    },
                    new PaymentDistribution
                    {
                        Id = 3,
                        PrincipleName = "توزيع خاص للتسديدات",
                        Description = "توزيع التسديدات حسب تاريخ الدين",
                        CreateDate = DateTime.Now.AddDays(-28),
                        UpdateDate = DateTime.Now.AddDays(-28),
                        Status = 1,
                        Notes = "للعملاء المميزين"
                    }
                }
            };

            return View(viewModel);
        }

        // Settings page action
        public IActionResult Settings()
        {
            var vm = new object(); // Placeholder, replace with appropriate view model

            return View(vm);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                // Return sample data
                var paymentDistributions = new List<PaymentDistribution>
                {
                    new PaymentDistribution
                    {
                        Id = 1,
                        PrincipleName = "توزيع مبدئي للتسديدات",
                        Description = "توزيع التسديدات حسب أولوية العميل",
                        CreateDate = DateTime.Now.AddDays(-30),
                        UpdateDate = DateTime.Now.AddDays(-30),
                        Status = 1,
                        Notes = "مبدأ أساسي"
                    },
                    new PaymentDistribution
                    {
                        Id = 2,
                        PrincipleName = "توزيع متقدم للتسديدات",
                        Description = "توزيع التسديدات حسب قيمة الدين",
                        CreateDate = DateTime.Now.AddDays(-29),
                        UpdateDate = DateTime.Now.AddDays(-29),
                        Status = 1,
                        Notes = "للحالات الخاصة"
                    },
                    new PaymentDistribution
                    {
                        Id = 3,
                        PrincipleName = "توزيع خاص للتسديدات",
                        Description = "توزيع التسديدات حسب تاريخ الدين",
                        CreateDate = DateTime.Now.AddDays(-28),
                        UpdateDate = DateTime.Now.AddDays(-28),
                        Status = 1,
                        Notes = "للعملاء المميزين"
                    }
                };

                return Json(new { data = paymentDistributions });
            }
            catch (Exception)
            {
                // Return empty data for any exception
                return Json(new { data = new List<PaymentDistribution>() });
            }
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                // Return sample data
                var paymentDistribution = new PaymentDistribution
                {
                    Id = id,
                    PrincipleName = "توزيع مبدئي للتسديدات",
                    Description = "توزيع التسديدات حسب أولوية العميل",
                    CreateDate = DateTime.Now.AddDays(-30),
                    UpdateDate = DateTime.Now.AddDays(-30),
                    Status = 1,
                    Notes = "مبدأ أساسي"
                };

                return Json(new { success = true, data = paymentDistribution });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "حدث خطأ أثناء جلب مبدأ التوزيع" });
            }
        }
    }
}