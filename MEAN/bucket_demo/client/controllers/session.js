app.controller('sessionController', function($scope, sessionFactory){
  $scope.errors = [];

  sessionFactory.checkUser(function(data){
    $scope.curUser = data;
    
  })

  $scope.login = function(){
    $scope.errors = []
    // line 4 resets and not let errors pile on top of each other
    if(!$scope.logReg || !$scope.logReg.name){
      $scope.errors.push('Please enter a name.')
    }
    else if($scope.logReg.name.length <3){
      $scope.errors.push('Name must be at least 3 characters')
    }
    else{
      sessionFactory.login($scope.logReg)
    }
  }
})
