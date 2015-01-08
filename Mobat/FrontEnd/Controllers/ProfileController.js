app.controller("ProfileController", function ($scope, $http, $location, mobat) {

    $scope.pageClass = 'Profile';

    $scope.profile = [];
    $scope.errorMessage = '';
    $scope.editMode = true;
    
    var check = mobat.checkLogin();

    $scope.getProfile = function () {
        $http({
            headers: { Authorization: 'Bearer ' + sessionStorage.getItem('token') },
            url: '/api/Profile/',
            method: 'GET',
        }).success(function (data) {
            $scope.profile.push(data);
            $scope.errorMessage = "";
        }).error(function () {
            $scope.errorMessage = "Sorry, some error occured or you're not authorized to eat peanut butter.";
        });
    }

    $scope.submit = function () {
        $http({
            headers: { Authorization: 'Bearer ' + sessionStorage.getItem('token') },
            url: '/api/Profile/',
            method: 'PUT',
            data: $scope.profile[0]
        }).success(function (data) {
            $location.path('/profile');
            $scope.editMode = true;
            mobat.checkIn(true);
        }).error(function () {
            alert("Edit did not work");
        });
    }

    if (check == true) {
        $scope.getProfile();
    } else {
        $location.path('/');
    }

});


