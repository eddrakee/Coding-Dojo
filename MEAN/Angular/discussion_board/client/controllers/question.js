app.controller('questionController', function ($scope, questionFactory, $routeParams) {

    if ($routeParams.id) {
        questionFactory.getAll(function (data) {
            $scope.questions = data
            for (question in $scope.questions) {
                if ($scope.questions[question]['_id'] == $routeParams.id) {
                    $scope.currentTopic = $scope.questions[question]

                }
            }
        })
    } else {
        questionFactory.getAll(function (data) {
            $scope.questions = data;
            // console.log($scope.questions)
        })
    }
    $scope.addQuestion = function (id) {
        // console.log($scope.newQuestion)
        $scope.newQuestion._id = id
        questionFactory.addQuestion($scope.newQuestion, function(){
            questionFactory.getAll(function (data) {
            $scope.questions = data;
        })
    })
            
        
    }

    $scope.showTopic = (function (id) {
        questionFactory.showTopic(id)
    })
})