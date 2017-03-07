app.controller('answerController', function($scope, answerFactory, $route, $location){
    // $scope.addAnswer = function(answer, user, question){
    //     $scope.errors = [];
    //     if(!$scope.newAnswer || !$Scope.newAnswer.content){
    //         $scope.errors.push('Please add a answer!')
    //     }

    //     answer._user = user;
    //     answer._question = question;
    //     answerFactory.addAnswer(answer, function(){
    //         getAnswers();
    //         $route.reload()
    //     }) 
    // }
    // $scope.allAnswers = [];
    // function getAnswers(){
    //     answerFactory.getAll(function(data){
    //         $scope.allAnswers = data
    //     })
    // }
    // getAnswers();

    $scope.errors = []

    $scope.addAnswer = function(answer, user, question){
        $scope.errors= []
        if(!$scope.newAnswer){
            $scope.errors.push('Please enter content!')
        }
        else if(!$scope.newAnswer.content || $scope.newAnswer.content.length < 5){
            $scope.errors.push("Answer must be at least 5 characters long")
        }else{
        answer._user = user
        answer._question = question
        console.log(answer, "answer")
        answerFactory.addAnswer(answer, function(){
            $scope.newAnswer = {}
             $location.url('/dashboard')
            })
        }
    }
    $scope.likeAnswer = function(answer){
        console.log(answer, "andsw")
        answerFactory.likeAnswer(answer, function(data){
            console.log('lik contr',data)
            $route.reload()
        })
    }
})