using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using SignalRPushNotification.Hubs;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRPushNotification
{
    public class NotificationService : BackgroundService
    {
        private readonly IHubContext<NotificationHub, INotificationClient> hubContext;

        public NotificationService(IHubContext<NotificationHub, INotificationClient> hubContext)
        {
            this.hubContext = hubContext;
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    await hubContext.Clients.All.GetNotification("Hello World");
                    await Task.Delay(10000);
                }
            });
        }
    }
}
