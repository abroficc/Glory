using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Inspinia.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        public IActionResult Permissions() => View();
        public IActionResult Contacts() => View();
        public IActionResult Roles() => View();
    }
}