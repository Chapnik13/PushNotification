using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRPushNotification.Hubs
{
    public class NotificationHub : Hub<INotificationClient>
    {
        public async Task SendNotification(string message)
        {
            await Clients.All.GetNotification(message);
        }
    }
}