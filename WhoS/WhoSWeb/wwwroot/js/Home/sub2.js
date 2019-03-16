angular.module("myApp", []).controller("sub2", function ($scope, $http) {
    $scope.data = [];
    var cNoData = window.sessionStorage.getItem("cNo");

    $http({
        method: 'POST', url: '/Res/Select', data: $.param({ cNo: cNoData }),
        headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' }
    }).then(function (data) {
        $scope.data = data.data;
    });


    $scope.btn = function (data, index) {
        console.log(data, index, $scope.data[index]);
    } // 버튼 이벤트
});
