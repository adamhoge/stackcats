$(() => {
    $('#submit-request-release-notification').click(function (e) {
        e.preventDefault();

        grecaptcha.ready(function () {
            grecaptcha.execute($('#recaptcha-client-key').val(), { action: 'homepage' }).then(function (token) {
                $.ajax({
                    url: "Home/RequestReleaseNotification",
                    data: {
                        emailAddress: $('#email-address').val(),
                        reCaptchaResponse: token
                    },
                    type: "post",
                    success: function (result) {
                        $('#email-address').val('');
                        $('#modal-notify-me').modal('hide');
                    }
                });
            });
        });
    });
});