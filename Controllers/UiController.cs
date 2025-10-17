using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Inspinia.Controllers
{
    [Authorize]
    public class UiController : Controller
    {
        public IActionResult Alerts() => View();
        public IActionResult Badges() => View();
        public IActionResult Breadcrumb() => View();
        public IActionResult Buttons() => View();
        public IActionResult Cards() => View();
        public IActionResult Carousel() => View();
        public IActionResult Collapse() => View();
        public IActionResult Dropdowns() => View();
        public IActionResult Embed() => View();
        public IActionResult Grid() => View();
        public IActionResult ListGroup() => View();
        public IActionResult Media() => View();
        public IActionResult Modal() => View();
        public IActionResult Notifications() => View();
        public IActionResult Offcanvas() => View();
        public IActionResult Pagination() => View();
        public IActionResult Popovers() => View();
        public IActionResult Progress() => View();
        public IActionResult Spinners() => View();
        public IActionResult Tabs() => View();
        public IActionResult Tooltips() => View();
        public IActionResult Typography() => View();
    }
}