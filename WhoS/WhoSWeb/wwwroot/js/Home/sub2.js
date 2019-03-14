angular.module("myApp", []).controller("sub2", function ($scope, $http) {
    
    $scope.data = [];
    $http.post("/Res/Select").then(function (d) { console.log(d.data); $scope.data = d.data; }, function (d) { console.log(d); });

    $scope.btn = function (data, index) {
        console.log(data, index, $scope.data[index]);
    }

});
