app.controller('questionController', function ($scope, questionFactory, $location, $routeParams, $route) {
    $scope.errors = []

    if ($routeParams.id) {
        questionFactory.getAll(function (data) {
            $scope.questions = data
            for (question in $scope.questions) {
                if ($scope.questions[question]['_id'] == $routeParams.id) {
                    $scope.currentQuestion = $scope.questions[question]
                }
            }
        })
    } else {
        questionFactory.getAll(function (data) {
            $scope.questions = data
        })
    }
    $scope.addQuestion = function (id) {
        $scope.errors = [];
        if (!$scope.newQuestion) {
            $scope.errors.push('Please enter content!')
        }
        else if (!$scope.newQuestion.topic || $scope.newQuestion.topic.length < 10) {
            $scope.errors.push("Topic must be at least 10 characters long")
        }
        else if (!$scope.newQuestion.description || $scope.newQuestion.description.length < 10) {
            $scope.errors.push("Description must be at least 5 characters long")
        }
        else {
            $scope.newQuestion._id = id
            questionFactory.addQuestion($scope.newQuestion, function () {
                questionFactory.getAll(function (data) {
                    $scope.questions = data;
                    $scope.newQuestion = {}
                    $location.url('/dashboard')
                })
            })
        }
    }
})
