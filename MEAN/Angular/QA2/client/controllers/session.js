app.controller('sessionController', function($scope, sessionFactory){
$scope.errors = [];

sessionFactory.checkUser(function(data){
    $scope.currentUser = data;
})

$scope.login = function(){
    $scope.errors = []
    if(!$scope.logReg || !$scope.logReg.name){
        $scope.errors.push('Please enter a name!')
    }
    else if($scope.logReg.name.length < 3){
        $scope.errors.push('Name must be at least 3 characters long!')
    }else{
        sessionFactory.login($scope.logReg)
    }
}
})