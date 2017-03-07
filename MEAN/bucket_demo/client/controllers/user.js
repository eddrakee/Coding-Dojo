app.controller('userController', function($scope, userFactory, $routeParams){
  userFactory.getAll(function(data){
    $scope.users = data;
    // console.log($scope.users);
  })
  if($routeParams.id){
    userFactory.getAll(function(data){
      $scope.users = data;
      $scope.showUser = null;
      for(user in $scope.users){
        // [user] is the user we are looking at currently. go in all the users and find that person
        if($scope.users[user]['_id'] == $routeParams.id){
          // set variable showUser to be that users[user]
          $scope.showUser = $scope.users[user];
        }
      }
      })
  }
})
