using Microsoft.AspNetCore.Mvc;

namespace Inspinia.Controllers.DesignPreviews
{
    [Route("DesignPreviews")]
    public class DesignPreviewsController : Controller
    {
        [Route("Design{designNumber}")]
        public IActionResult Index(string designNumber)
        {
            // Validate design number
            if (string.IsNullOrEmpty(designNumber) || !new[] { "0", "1", "2", "3" }.Contains(designNumber))
            {
                return NotFound();
            }

            // Return the corresponding design preview view
            return View($"~/Views/DesignPreviews/Design{designNumber}.cshtml");
        }
    }
}