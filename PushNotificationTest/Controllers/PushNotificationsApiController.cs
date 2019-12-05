using PushNotificationTest.PushNotification;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebPush;

namespace PushNotificationTest.Controllers
{
    public class PushNotificationsApiController : Controller
    {
        private static readonly IPushSubscriptionStore _subscriptionStore = new ListPushSubscriptionStore();
        private static readonly IPushNotificationService _notificationService = new WebPushPushNotificationService();

        // POST push-notifications-api/subscriptions
        [HttpPost]
        public async Task<ActionResult> StoreSubscription(Models.PushSubscriptionFromJS subscription)
        {

            await _subscriptionStore.StoreSubscriptionAsync(new PushSubscription(subscription.Endpoint, subscription.Keys["p256dh"], subscription.Keys["auth"]));

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpGet]
        public async Task<ActionResult> SendNotification()
        {
            await _subscriptionStore.ForEachSubscriptionAsync((subscription) => _notificationService.SendNotification(subscription, "Hello World"));

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}