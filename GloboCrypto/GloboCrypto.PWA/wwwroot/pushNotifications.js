﻿(function () {
    // Note: Replace with your own key pair before deploying
    const applicationServerPublicKey = 'BKZhL0IKZcU-32GNJa9v0xBjk7Ea6elP7vIj6IW5mw4tbLIqif7OHP6gE2Nv97Z-4lApKp7R7ii7T85SvcGkhtE';

    window.blazorPushNotifications = {
        requestSubscription: async () => {
            const worker = await navigator.serviceWorker.getRegistration();
            const existingSubscription = await worker.pushManager.getSubscription();
            if (!existingSubscription) {
                const newSubscription = await subscribe(worker);
                if (newSubscription) {
                    console.log("new-subscription");
                    return {
                        url: newSubscription.endpoint,
                        p256dh: arrayBufferToBase64(newSubscription.getKey('p256dh')),
                        auth: arrayBufferToBase64(newSubscription.getKey('auth'))
                    };
                }
            } else {
                console.log("existing subscription");
            }
        },
        removeSubscription: async () => {
            const worker = await navigator.serviceWorker.getRegistration();
            const existingSubscription = await worker.pushManager.getSubscription();
            if (existingSubscription) {
                await existingSubscription.unsubscribe().then(function (successful) {
                    console.log("unsubscribe success");
                }).catch(function (e) {
                    console.log("unsubscribe failed");
                })
            }
        }
    };

    async function subscribe(worker) {
        try {
            return await worker.pushManager.subscribe({
                userVisibleOnly: true,
                applicationServerKey: applicationServerPublicKey
            });
        } catch (error) {
            if (error.name === 'NotAllowedError') {
                return null;
            }
            throw error;
        }
    }

    function arrayBufferToBase64(buffer) {
        var binary = '';
        var bytes = new Uint8Array(buffer);
        var len = bytes.byteLength;
        for (var i = 0; i < len; i++) {
            binary += String.fromCharCode(bytes[i]);
        }
        return window.btoa(binary);
    }
})();