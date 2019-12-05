using System;
using System.Threading.Tasks;
using WebPush;

namespace PushNotificationTest.PushNotification
{
    public interface IPushSubscriptionStore
    {
        Task StoreSubscriptionAsync(PushSubscription subscription);

        Task ForEachSubscriptionAsync(Action<PushSubscription> action);
    }
}
