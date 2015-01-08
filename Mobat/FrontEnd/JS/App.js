var app = angular.module('mobat', ['ngRoute' ,'ngAnimate']);

app.config(["$routeProvider", function ($routeProvider) {

    $routeProvider.when('/', {
        templateUrl: '/FrontEnd/Templates/Login.html',
        controller: 'LoginController'
    })
    .when('/game', {
        templateUrl: "FrontEnd/Templates/Home.html",
        controller: 'HomeController'
    })
    .when('/logs', {
        templateUrl: "Frontend/Templates/Logs.html",
        controller: 'LogController'
    })
    .when('/profile', {
        templateUrl: "/FrontEnd/Templates/Profile.html",
        controller: 'ProfileController'
    })
    .when('/register', {
        templateUrl: "FrontEnd/Templates/Register.html",
        controller: "RegisterController"
    })
    .otherwise({
        redirectTo: '/'
    });


}]);