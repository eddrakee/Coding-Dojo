app.controller('messageController', function($scope, messageFactory){
    $scope.errors = [];

    messageFactory.checkUser(function(data){
        $scope.currentUser = data;
    })

