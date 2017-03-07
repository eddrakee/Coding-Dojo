app.controller('commentController', function($scope, commentFactory){
    $scope.addComment = function(comment, user, question){
        comment._user = user;
        comment._question = question;
        commentFactory.addComment(comment, function(data){
            for(var q=0; q < $scope.questions.length; q++){
                if($scope.questions[q]._id == question){
                $scope.questions[q]._comments.push(data)
                }
            }
        })
        $scope.newComment = {}
    }
})
// get all questions
// 