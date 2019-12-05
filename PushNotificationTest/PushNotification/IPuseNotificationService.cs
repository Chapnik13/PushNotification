using WebPush;

namespace PushNotificationTest.PushNotification
{
    public interface IPushNotificationService
    {
        void SendNotification(PushSubscription subscription, string payload);
    }
}