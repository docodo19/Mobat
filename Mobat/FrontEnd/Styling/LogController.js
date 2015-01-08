app.controller('LogController', function ($scope, $http, $route, $location, $window, mobat) {

    $scope.pageClass = 'Logs';

    var game = mobat.getGame();
    $scope.url = game.gameImageUrl;
    var check = mobat.checkLogin();
    $scope.Logs = [];
    $scope.totalTimePlayed = 0;
    
    //$scope.statArray = [];
    //$scope.stat = {}
    //$scope.stat.win = 0;
    //$scope.stat.loss = 0;
    //$scope.stat.ratio = 0;


    $scope.getLogs = function () {
        $http({
            headers: { Authorization: 'Bearer ' + sessionStorage.getItem('token') },
            url: '/api/Log/' + game.id,
            method: 'PATCH',
           
        }).success(function (data) {
            for (var l in data) {
                //$scope.totalTimePlayed += data[l].timePlayed;

                $scope.Logs.push(data[l]);
                var total = data[l].timePlayed + $scope.totalTimePlayed;
                $scope.totalTimePlayed = total;
            };
            $scope.errorMessage = '';
        }).error(function () {
            $scope.errorMessage = "Error getting logs from server";
        });
    }
    $scope.getLogs();

    $scope.removeLog = function (Id) {
        $http({
            headers: { Authorization: 'Bearer ' + sessionStorage.getItem('token') },
            url: 'api/Log/' + Id,
            method: 'DELETE',
        }).success(function () {
            $route.reload();
        }).error(function () {
            alert("You suck at this mang!!")
        })
    }

    if (check == false) {
        $location.path('/');
    }
    

});