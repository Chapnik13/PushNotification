using PushNotificationTest.Models;
using WebPush;

namespace PushNotificationTest.PushNotification
{
    public class WebPushPushNotificationService : IPushNotificationService
    {
        private readonly PushNotificationServiceOptions _options;
        private readonly WebPushClient _pushClient;

        public string PublicKey { get { return _options.PublicKey; } }

        public WebPushPushNotificationService()
        {
            _pushClient = new WebPushClient();
        }

        public void SendNotification(PushSubscription subscription, string payload)
        {
            var vapid = new VapidDetails("https://localhost:44380",
                "BNDpAEC0aT_i2ErU9Jte5zGGj3C4vCw5oTBh1AAtIT-nBplH_wLPdJ2V7DdsjWkeQL4q8afSn675smtQMDSCgTM",
                "5Q0aw9zUPm_-f0bXP_q5aPpRVAJnjrG692pgxabYLmw");

            _pushClient.SendNotification(subscription,payload, vapid);

            /*var options = new Dictionary<string, object>();
            options.Add("gcmAPIKey", "835498889135");
            options.Add("headers", new Dictionary<string, object> { { "Authorization", "bearer AIzaSyB_X5yTkPRL7KWMeDVy30ynoOlyYn5WGmI" } });
            _pushClient.SendNotification(subscription, payload, options);*/
        }
    }
}