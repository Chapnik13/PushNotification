let pushServiceWorkerRegistration;

$(document).ready(function () {
    if ('serviceWorker' in navigator) {
        registerPushServiceWorker('/serviceworker.js');
        setTimeout(() => { subscribeForPushNotifications(); }, 5000); 
    }
});

function registerPushServiceWorker(serviceWorkerPath) {
    navigator.serviceWorker.register(serviceWorkerPath)
        .then(function (serviceWorkerRegistration) {
            pushServiceWorkerRegistration = serviceWorkerRegistration;
            console.log('Push Service Worker has been registered successfully');
        }).catch(function (error) {
            console.log('Push Service Worker registration has failed: ' + error);
        });
};

function subscribeForPushNotifications() {
    let applicationServerPublicKey = 'BNDpAEC0aT_i2ErU9Jte5zGGj3C4vCw5oTBh1AAtIT-nBplH_wLPdJ2V7DdsjWkeQL4q8afSn675smtQMDSCgTM';

    pushServiceWorkerRegistration.pushManager.subscribe({
        userVisibleOnly: true,
        applicationServerKey: applicationServerPublicKey
    }).then(function(pushSubscription) {
        fetch('PushNotificationsApi/StoreSubscription', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(pushSubscription)
        }).then(function (response) {
            if (response.ok) {
                console.log('Successfully subscribed for Push Notifications');
            } else {
                console.log('Failed to store the Push Notifications subscription on server');
            }
        }).catch(function (error) {
            console.log('Failed to store the Push Notifications subscription on server: ' + error);
        });
    }).catch(function (error) {
        if (Notification.permission === 'denied') {
        } else {
            console.log('Failed to subscribe for Push Notifications: ' + error);
        }
    });
};