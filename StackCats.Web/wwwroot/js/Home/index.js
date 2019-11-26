$(() => {
    $('#submit-request-release-notification').click(function (e) {
        e.preventDefault();

        $.ajax({
            url: "Home/RequestReleaseNotification",
            data: { emailAddress: $('#email-address').val() },
            type: "post",
            success: function (result) {
                $('#modal-notify-me').modal('hide');
                $('')
            }
        });
    });
});