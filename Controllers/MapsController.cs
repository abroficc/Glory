using Microsoft.AspNetCore.Mvc;

namespace Inspinia.Controllers
{
    //[Authorize]
    public class MapsController : Controller
    {
        public IActionResult Google() => View();
        public IActionResult Leaflet() => View();
        public IActionResult Vector() => View();
    }
}