app.controller('sessionController', function($scope, sessionFactory){
//    build an errors factory for more controllers
    $scope.errors = [];
    $scope.login = function(){
        // this resets our errors array to empty so you won't get multple errors when repressing button
        $scope.errors = [];
        if(!$scope.logReg || !$scope.logReg.name){
            $scope.errors.push('Please enter a name!')
        }
        else if($scope.logReg.name.length < 2){
            $scope.errors.push('Name must be at least 2 characters long!')
        }
        else{
            sessionFactory.login($scope.logReg)
        }
    }
})