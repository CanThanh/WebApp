var loginController = {
    init: function () {
        loginController.registerEvent();
    },

    registerEvent: function () {
       
        $('#btnLogin').off('click').on('click', function () {
            loginController.login();
        });

        $('input').iCheck({
            checkboxClass: 'icheckbox_square-blue',
            radioClass: 'iradio_square-blue',
            increaseArea: '20%' // optional
        })
    },

    login: function () {
        var fileData = new FormData($('#frmLogin')[0]);
        if ($('#frmLogin').valid()) {
            $.ajax({
                url: '/Account/Login',
                type: "POST",
                data: fileData,
                contentType: false, // Not to set any content header
                processData: false, // Not to process data
                success: function (response) {
                    if (response.IsError) {
                        alert(response.Message);
                    } else {
                        window.location.href = response.Url;
                    }
                },
                error: function () {
                    alert("error");
                }
            });
        }
    },
}

loginController.init();