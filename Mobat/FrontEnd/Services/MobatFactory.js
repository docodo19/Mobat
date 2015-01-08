app.factory('mobat', function ($http, $window) {
    // Login Check

    var isLoggedin = false;
    var checkLogin = function () {
        if ($window.sessionStorage.getItem('token') !== null && $window.sessionStorage.getItem('token') !== "") {
            isLoggedin = true;
        } else {
            isLoggedin = false;
        }
        return isLoggedin;
    }
    var checkin = function (data) {
        isLoggedin = data;
    }


    // GameId tracker
    var game = null;
    var getGame = function () {
        return game;
    }
    var saveGame = function (data) {
        game = data;
    }





    // RETURNS
    return {
        // Login Check
        checkLogin: checkLogin,
        checkin: checkin,
        // GameId tracker
        getGame: getGame,
        saveGame: saveGame,
        isLoggedin: isLoggedin,
    };


});