self.addEventListener('push', function(event) {
    event.waitUntil(self.registration.showNotification('Demo.AspNetCore.PushNotifications', {
        body: event.data.text(),
    }));
});