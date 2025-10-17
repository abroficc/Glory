using Microsoft.AspNetCore.Mvc;

namespace Inspinia.Controllers
{
    public class ElectricityCompaniesController : Controller
    {
        // GET: ElectricityCompanies
        public IActionResult Index()
        {
            return View();
        }
    }
}