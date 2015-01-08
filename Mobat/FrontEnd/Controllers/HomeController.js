app.controller('HomeController', function ($scope, $http, $location, $route, mobat) {
    var timePlayedValue;
    var commentValue;
    var radioValue;
    var radioBool;


    $scope.pageClass = 'Home';

    var check = mobat.checkLogin();
    $scope.log;
    $scope.logInfo = {};
    $scope.gameArray = [];
    $scope.formInfo = {};
    $scope.formData = {};
    $scope.alert = function (id) { alert(id); };
    //$scope.formInfo = null;
    //$scope.winLoss = '';
    //$scope.timePlayed = '';
    //$scope.comment = '';

    $scope.addLog = function (GameId, x) {
        //don't touch this
        $scope.logInfo.GameId = GameId;
        

        //test field
        var test = "timePlayed" + GameId;
        var test1 = "comment" + GameId;
        var test3 = "radioCheck" + GameId;
        //

        

        timePlayedValue = document.getElementById(test);
        commentValue = document.getElementById(test1);
        //radioValue = $('input[name="radioCheck"]:checked').val();
        radioValue = document.getElementsByName(test3);
        for (i = 0; i < radioValue.length; i++){
            if(radioValue[i].checked)
            {
                radioBool = radioValue[i].checked;
            }
        }



        $scope.logInfo.timePlayed = timePlayedValue.value;
        $scope.logInfo.comment = commentValue.value;
        $scope.logInfo.victory = radioBool;
        $http({
            headers: { Authorization: 'Bearer ' + sessionStorage.getItem('token') },
            url: 'api/Log', 
            method: 'POST',
            data: $scope.logInfo,
        }).success(function (data) {
            mobat.saveGame(x);
            $location.path('/logs');
        }).error(function () {
            alert("you need to fill in all forms please.");
        })
    }


    $scope.loadGames = function () { //Dexter: This function is called when the page loads and retrieves all games & URL's from the database.
        $http({
            headers: { Authorization: 'Bearer ' + sessionStorage.getItem('token') },
            url: '/api/Game',
            method: 'GET'
        }).success(function (data) {
            $scope.gameArray.splice(0);
            for(var i in data){
                $scope.gameArray.push(data[i]);
            }

            //$scope.gameArray.push(data);  
            //console.log($scope.gameArray);
            $scope.errorMessage = 'The data did not come back from the compiler';

        }).error(function () {
            $scope.errorMessage = "Error getting logs from server";
        })
    }




    $scope.addGame = function () {
        $http({
            headers: { Authorization: 'Bearer ' + sessionStorage.getItem('token') },
            url: '/api/Game/', //added an ending slash
            method: 'POST',
            data: $scope.formInfo,         //Dexter: "This is the data being posted from the addGame function in the form"
        }).success(function () {
            $route.reload();
        }).error(function () {
            alert("you need to fill in all forms please.");
        })
    }

    
    $scope.editGame = function (g) {
        $http({
            headers: { Authorization: 'Bearer ' + sessionStorage.getItem('token') },
            url: 'api/Game/', 
            method: 'PUT',
            data: g,       
        }).success(function () {
            $route.reload();

        }).error(function () {
            alert("you need to fill in all forms please.");
        })
    }

    $scope.removeGame = function (g) { //This is the delete controller function
        $http({
            headers: { Authorization: 'Bearer ' + sessionStorage.getItem('token') },
            url: 'api/Game/' + g.id, //Unsupported media type if you use data: g.id
            method: 'DELETE',
        }).success(function () {
            $location.path('/home');

        }).error(function () {
            alert("you need to fill in all forms please.");
        })
    }


    // This function will redirect to Logs.html page and send the game.id to factory.
    $scope.viewLog = function (data) {
        mobat.saveGame(data);
        $location.path('/logs');
    }



    if(check == false)
    {
        $location.path('/');
    } else {
        $scope.loadGames();

       
    }

})