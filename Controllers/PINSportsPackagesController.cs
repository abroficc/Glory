using Microsoft.AspNetCore.Mvc;

namespace Inspinia.Controllers
{
    public class PINSportsPackagesController : Controller
    {
        // GET: PINSportsPackages
        public IActionResult Index()
        {
            return View();
        }
    }
}