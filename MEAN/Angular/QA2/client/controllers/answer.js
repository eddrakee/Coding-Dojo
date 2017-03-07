app.controller('answerController', function ($scope, answerFactory, $route, $location) {
    $scope.errors = []

    $scope.addAnswer = function (answer, user, question) {
        $scope.errors = []
        if (!$scope.newAnswer) {
            $scope.errors.push('Please enter content!')
        }
        else if (!$scope.newAnswer.content || $scope.newAnswer.content.length < 5) {
            $scope.errors.push("Answer must be at least 5 characters long")
        } else {
            answer._user = user
            answer._question = question
            answerFactory.addAnswer(answer, function () {
                $scope.newAnswer = {}
                $location.url('/dashboard')
            })
        }
    }
    $scope.likeAnswer = function (answer) {
        answerFactory.likeAnswer(answer, function (data) {
            $route.reload()
        })
    }

})