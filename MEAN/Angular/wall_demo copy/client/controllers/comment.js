app.controller('commentController', function($scope, commentFactory, $route){
    $scope.addComment = function(comment, user, message){
        $scope.errors = [];
        if(!$scope.comment || !$scope.comment.content){
            $scope.errors.push("Please add in ")
        }



        comment._user = user;
        comment._message = message;
        commentFactory.addComment(comment, function(){
            getComments();
            $route.reload()
        })
    }

    $scope.allComments = [];
    function getComments(){
        commentFactory.getAll(function(data){
            $scope.allComments = data;
        })
    }
    getComments();

})