$(document).ready(function () {
    var d = new Date().toISOString().substring(0, 10);
    $("#enter").val(d); // 기본 날짜 세팅
    $("#outer").val(d);

    $("form").submit(function (e) {
        e.preventDefault();
        var params = {
            "name": $("#name").val(),
            "t": $("#t").val(),
            "enter": $("#enter").val(),
            "outer": $("#outer").val(),
            "email": $("#email").val()
        }
        $.post("/Res/Insert",params).done(function (d) {
            console.log(d);
            location.href = "Sub2"
        });
    });
});