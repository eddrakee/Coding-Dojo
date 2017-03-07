app.controller ('userController', function($scope,userFactory){
  userFactory.getAll(function(data){
    $scope.users = data
  })
})
