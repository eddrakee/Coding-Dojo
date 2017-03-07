app.controller('sessionController', function($scope, sessionFactory){
    $scope.errors = [];
    sessionFactory.checkUser(function(data){
        $scope.currentUser = data;
    });

    $scope.login = function(){
        $scope.errors =[];
        if(!$scope.logReg || !$scope.logReg.name){
            $scope.errors.push('Please enter a username!')
        }
        else if($scope.logReg.name.length < 3){
            $scope.errors.push('Username must be at least 3 characters long!')
        }
        else if($scope.logReg.name.length > 10){
            $scope.errors.push('Username cannot be longer than 10 characters!')
        }else{
            sessionFactory.login($scope.logReg)
        }
    }
})