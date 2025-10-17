using Microsoft.AspNetCore.Mvc;

namespace Inspinia.Controllers
{
    public class CitiesController : Controller
    {
        // GET: Cities
        public IActionResult Index()
        {
            return View();
        }
    }
}