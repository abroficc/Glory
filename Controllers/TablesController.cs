using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Inspinia.Controllers
{
    [Authorize]
    public class TablesController : Controller
    {
        public IActionResult Basic() => View();
        public IActionResult Datatables() => View();
        public IActionResult Editable() => View();
        public IActionResult Responsive() => View();
    }
}