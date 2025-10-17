using Microsoft.AspNetCore.Mvc;

namespace Inspinia.Controllers
{
    //[Authorize]
    public class ProjectController : Controller
    {
        public IActionResult List() => View();
        public IActionResult Index() => View();
        public IActionResult Kanban() => View();
        public IActionResult TeamBoard() => View();
        public IActionResult Activity() => View();
        public IActionResult Details() => View();
    }
}