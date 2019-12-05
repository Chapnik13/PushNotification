using System.Threading.Tasks;

namespace SignalRPushNotification.Hubs
{
    public interface INotificationClient
    {
        Task GetNotification(string message);
    }
}