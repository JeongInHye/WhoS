$(document).ready(function () {
    var cName = window.sessionStorage.getItem("cName");
    var cNo = window.sessionStorage.getItem("cNo");
    var cPName = window.sessionStorage.getItem("cPName");

    $("label#cName.cName").empty();
    $("label#cName.cName").text(cName);

    $("label#cPName.cPName").empty();
    $("label#cPName.cPName").text(cPName);

    var d = new Date().toISOString().substring(0, 10);
    $("#EnterDate").val(d); // 기본 날짜 세팅
    $("#OutDate").val(d);

    $("form").submit(function (e) {
        e.preventDefault();
        var params = {
            "cNo": cNo,
            "pName": $("#pName").val(),
            "pWeight": $("#pWeight").val(),
            "EnterDate": $("#EnterDate").val(),
            "OutDate": $("#OutDate").val()
        }
        $.post("/Res/Insert", params).done(function (d) {
            var status = d;
            if (d == "1") {
                location.href = "Sub2"
            }
        });
    });
});