using Microsoft.AspNetCore.Mvc;

namespace Inspinia.Controllers
{
    public class RemittanceCommissionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}