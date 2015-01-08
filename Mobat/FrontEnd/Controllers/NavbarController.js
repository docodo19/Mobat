app.controller('NavbarController', function ($scope, $window, $location, mobat) {
    
    
    $scope.isLoggedIn = mobat.checkLogin();
    $scope.logout = function () {
        $window.sessionStorage.removeItem("token");
        $('#logout').addClass('hidden');
        $location.path("/");
        mobat.checkin(false);
    }

});