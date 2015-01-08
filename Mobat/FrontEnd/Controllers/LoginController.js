app.controller("LoginController", function ($scope, $http, $location, mobat) {


    if (mobat.checkLogin() == false) {
        $location.path('/');
    } else {
        $location.path('/game');
    }

    $scope.pageClass = 'Login';

    $scope.username = '';
    $scope.password = '';

    $scope.login = function () {
        $http({
            url: '/Token',
            method: 'POST',
            contentType: 'application/x-www-form-urlencoded',
            data: 'username=' + $scope.username + '&password=' + $scope.password + '&grant_type=password'
        }).success(function (data) {
            sessionStorage.setItem('token', data.access_token);
            mobat.checkin(true)
                $("#logout").removeClass("hidden");

            $location.path('/game');

            
        }).error(function () {
            alert("Sorry your information was incorrect.")
        });
    };


});