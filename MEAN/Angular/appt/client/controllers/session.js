app.controller('sessionController', function($scope, sessionFactory){
  $scope.errors = []
  sessionFactory.checkUser(function(data){
    $scope.curUser = data
  })
  $scope.login = function(){
    $scope.errors = []
    if(!$scope.logReg || !$scope.logReg.name){
      $scope.errors.push("Please enter name")
    }
    else if($scope.logReg.name.length < 3){
      $scope.errors.push("name needs to be longer than 3 characters")
    }
    else{
      sessionFactory.login($scope.logReg)
    }
  }
})
