using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Inspinia.Controllers
{
    [Authorize]
    public class FormController : Controller
    {
        public IActionResult Elements() => View();
        public IActionResult Advanced() => View();
        public IActionResult Validation() => View();
        public IActionResult Pickers() => View();
        public IActionResult Editors() => View();
        public IActionResult Upload() => View();
        public IActionResult Wizard() => View();
        public IActionResult Mask() => View();
        public IActionResult Layouts() => View();
        public IActionResult Select2() => View();
    }
}