
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebPush;

namespace PushNotificationTest.PushNotification
{
    public class ListPushSubscriptionStore : IPushSubscriptionStore
    {
        private List<PushSubscription> subscribers = new List<PushSubscription>();
        public async Task ForEachSubscriptionAsync(Action<PushSubscription> action)
        {
            await Task.Run(() => subscribers.ForEach(action));
        }

        public async Task StoreSubscriptionAsync(PushSubscription subscription)
        {
            await Task.Run(() => subscribers.Add(subscription));
        }
    }
}