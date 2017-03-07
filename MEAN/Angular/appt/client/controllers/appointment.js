app.controller ('apptController',function($scope,apptFactory){
  apptFactory.getAll(function(data){
    $scope.appts = data
  })
  $scope.add = function(curUser){
    $scope.newAppt._createdBy = curUser
    apptFactory.add($scope.newAppt);
    console.log($scope.newAppt);
  }
})
