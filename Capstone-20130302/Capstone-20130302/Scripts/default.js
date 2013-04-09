function notify(message) {
    var havePermission = window.webkitNotifications.checkPermission();
    if (havePermission == 0) {
        // 0 is PERMISSION_ALLOWED
        var notification = window.webkitNotifications.createNotification(
          message.image, message.title, message.content
        );

        notification.onclick = function () {
            if (message.url != undefined)
                window.open(message.url);
            notification.close();
        }
        notification.ondisplay = function () {
            setTimeout(function () { notification.close() }, 4000);
        }
        notification.show();
    } else {
        window.webkitNotifications.requestPermission();
    }
}