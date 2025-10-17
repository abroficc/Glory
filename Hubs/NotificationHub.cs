using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Glory77.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendNotification(string message, string type = "info")
        {
            await Clients.All.SendAsync("ReceiveNotification", new { 
                Message = message, 
                Type = type,
                Time = DateTime.Now.ToString("HH:mm")
            });
        }

        public async Task SendNotificationToUser(string userId, string message, string type = "info")
        {
            await Clients.User(userId).SendAsync("ReceiveNotification", new { 
                Message = message, 
                Type = type,
                Time = DateTime.Now.ToString("HH:mm")
            });
        }

        public async Task SendNotificationToGroup(string groupName, string message, string type = "info")
        {
            await Clients.Group(groupName).SendAsync("ReceiveNotification", new { 
                Message = message, 
                Type = type,
                Time = DateTime.Now.ToString("HH:mm")
            });
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
        
        public override async Task OnConnectedAsync()
        {
            // Log connection or perform other actions when a client connects
            await base.OnConnectedAsync();
        }
        
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            // Log disconnection or perform other actions when a client disconnects
            await base.OnDisconnectedAsync(exception);
        }
    }
}