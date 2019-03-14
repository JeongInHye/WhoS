$(document).ready(function () {
    $("form").submit(function (e) {
        e.preventDefault();
        var loginData = {
            id: $("#id").val(),
            password: $("#password").val()
        };

        $.post("User/Login", loginData).done(function (d) {
            if (d.state == 1) {
                location.href = "/Home/Sub1";
            } else if (d.state == 2) {
                location.href = "/Home/Sub2";
            } else {
                $("#id").val("");
                $("#password").val("");
                alert("사용자가 없습니다.");
            }
        });
    });
});
