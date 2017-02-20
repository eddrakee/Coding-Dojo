// we have access to app (which is originally found in app.js) because we linked this controller underneath the app.js link.
app.controller('userController', function($scope, userFactory){
    // run a callback to view all users that will run automatically
    userFactory.allUsers(function(data){
        // we just created the term "users"
        $scope.users = data
    })
    $scope.addUser = function(){
        userFactory.addUser($scope.newUser);
    }
    
})