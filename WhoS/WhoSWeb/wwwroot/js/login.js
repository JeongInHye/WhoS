$(document).ready(function () {
    $("form").submit(function (e) {
        e.preventDefault();
        var inputid = $("input[name=id]").val();
        var inputpw = $("input[name=pw]").val();

        $.post("/User/Login", { id: inputid, pw: inputpw }).done(function (data) {
            var cNo = data[0].cNo;
            var cName = data[0].cName;
            var cPName = data[0].cPName;  

            if (cName != "") {
                if (window.sessionStorage) {
                    sessionStorage.setItem("cNo", cNo);
                    sessionStorage.setItem("cName", cName);
                    sessionStorage.setItem("cPName", cPName);
                }
                location.href = "/Home/Sub1";
            }
            else {
                $("#id").val("");
                $("#pw").val("");
                alert("거래처를 등록해 주세요");
            }
        });
    });
});