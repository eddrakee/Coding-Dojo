// we have access to app (which is originally found in app.js) because we linked this controller underneath the app.js link.
app.controller('userController', function($scope, userFactory){
    $scope.addUser = function(){
        userFactory.addUser($scope.newUser);
    }
})