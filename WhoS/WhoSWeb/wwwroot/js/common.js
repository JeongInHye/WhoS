$(document).ready(function () {
    $(".tablink").click(function () {
        var index = $(".tablink").index(this);
        location.href = "/Home/sub" + (index + 1);
    });
});