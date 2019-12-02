$(() => {
    $('#submit-request-release-notification').click(function(e) {
        let $emailAddress = $('#email-address').val();

        e.preventDefault();

        if (!isValidEmailAddress($emailAddress)) {
            toastr["warning"]("Whoops. The email address entered doesn't appear to be valid.");

            return;
        }

        grecaptcha.ready(function () {
            $('#cancel-request-release-notification').prop("disabled", true);
            $('#submit-request-release-notification').prop("disabled", true);
            $('#request-release-notification-spinner').show();

            grecaptcha.execute($('#recaptcha-client-key').val(), { action: 'homepage' }).then(function(token) {
                $.ajax({
                    url: "Home/RequestReleaseNotification",
                    data: {
                        emailAddress: $emailAddress,
                        reCaptchaResponse: token
                    },
                    type: "post",
                    success: function(result) {
                        if (result == true) {
                            toastr["success"]("Great! We'll let you know when Stack Cats is released. Thank you for your support!");
                        }
                        else {
                            toastr["error"]("Yikes! Something went wrong and we weren't able to add you to the mailing list.");
                        }

                        $('#cancel-request-release-notification').prop("disabled", false);
                        $('#submit-request-release-notification').prop("disabled", false);
                        $('#request-release-notification-spinner').hide();
                        $('#email-address').val('');
                        $('#modal-notify-me').modal('hide');
                    }
                });
            });
        });
    });
});

function isValidEmailAddress(emailAddress) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(emailAddress).toLowerCase());
}