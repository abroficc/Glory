using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Inspinia.Controllers
{
    [Authorize]
    public class ChartsController : Controller
    {
        public IActionResult Apex() => View();
        public IActionResult Chartjs() => View();
        public IActionResult Echarts() => View();
    }
}
