using System.Collections.Generic;

namespace PushNotificationTest.Models
{
    public class PushSubscriptionFromJS
    {
        public string Endpoint { get; set; }

        public IDictionary<string, string> Keys { get; set; }
    }
}