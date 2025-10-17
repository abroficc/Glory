using Microsoft.AspNetCore.Mvc;

namespace Inspinia.Controllers
{
    public class CardCurrenciesController : Controller
    {
        // GET: CardCurrencies
        public IActionResult Index()
        {
            return View();
        }
    }
}