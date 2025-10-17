using Microsoft.AspNetCore.Mvc;

namespace Inspinia.Controllers
{
    public class NetFlixPackagesController : Controller
    {
        // GET: NetFlixPackages
        public IActionResult Index()
        {
            return View();
        }
    }
}