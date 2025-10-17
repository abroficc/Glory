using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Inspinia.Controllers
{
    [Authorize]
    public class DashboardsController : Controller
    {
        public IActionResult Index1() => View();
        public IActionResult Index2() => View();
        public IActionResult Index3() => View();
    }
}