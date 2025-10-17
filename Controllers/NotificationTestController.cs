using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Glory77.Hubs;

namespace Glory77.Controllers
{
    public class NotificationTestController : Controller
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationTestController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendNotification(string message, string type = "info")
        {
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", new { 
                Message = message, 
                Type = type,
                Time = DateTime.Now.ToString("HH:mm")
            });
            
            return Json(new { success = true, message = "Notification sent successfully" });
        }
    }
}