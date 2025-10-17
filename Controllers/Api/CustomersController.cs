using Microsoft.AspNetCore.Mvc;
using Glory77.Models;

namespace Inspinia.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        // GET: api/customers
        [HttpGet]
        public IActionResult GetCustomers(string term = "")
        {
            // Sample data - in a real application, this would come from a database
            var customers = new[]
            {
                new Customer { Id = 1, Name = "متجر جوجل بلاي - Google play" },
                new Customer { Id = 2, Name = "ايمن احمد قاسم طافر - متداول" },
                new Customer { Id = 3, Name = "محمد عبدالرحمن الوائلي - طبيب" },
                new Customer { Id = 4, Name = "مازن احمد صبر الوائلي - المدير" },
                new Customer { Id = 5, Name = "شهاب عبدالرحمن يحيى الوائلي - مره المدير" },
                new Customer { Id = 6, Name = "بشائر رجب محمد حذاف - خاص" },
                new Customer { Id = 7, Name = "محمد ابراهيم علي فضائل - تجارات" },
                new Customer { Id = 8, Name = "عبدالغفار ضيف الله الهادي صالح شركة HD للتصوير" }
            };

            // Filter based on search term if provided
            if (!string.IsNullOrEmpty(term))
            {
                var filtered = customers.Where(c => c.Name.Contains(term, StringComparison.OrdinalIgnoreCase)).ToArray();
                return Ok(filtered);
            }

            return Ok(customers);
        }
    }
}