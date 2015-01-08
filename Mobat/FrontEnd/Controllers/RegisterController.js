app.controller("RegisterController", function ($scope, $http, $location) {

    $scope.pageClass = 'Register';

    $scope.formInfo = {};
    



    $scope.submit = function () {

        $http.post("/api/register", $scope.formInfo)
        .success(function () {
            $location.path('/');
        })
        .error(function () {
            alert("There was an error on sending " + $scope.userInfo + ".");
        })
    }

});