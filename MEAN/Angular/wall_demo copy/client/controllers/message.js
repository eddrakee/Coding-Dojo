app.controller('messageController', function($scope, messageFactory){
    messageFactory.getAll(function(data){
        $scope.messages = data;
    })
    $scope.newMessage = {};
	$scope.addMessage = function(){
    console.log($scope.newMessage)
        // pass it the info submitted from form on html
        messageFactory.addMessage($scope.newMessage, function(){
        // will add to the page once submitted
            messageFactory.getAll(function(data){
            $scope.messages = data;
            $scope.newMessage = {}
            })
        })
   
    }

})