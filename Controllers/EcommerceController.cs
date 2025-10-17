using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Inspinia.Controllers
{
    [Authorize]
    public class EcommerceController : Controller
    {
        public IActionResult Products() => View();
        public IActionResult ProductDetails() => View();
        public IActionResult Cart() => View();
        public IActionResult Checkout() => View();
        public IActionResult Orders() => View();
        public IActionResult OrderDetails() => View();
        public IActionResult Sellers() => View();
        public IActionResult SellerDetails() => View();
    }
}