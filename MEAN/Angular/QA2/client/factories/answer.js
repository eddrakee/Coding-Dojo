app.factory('answerFactory', function ($http) {
    var factory = {}

    factory.addAnswer = function (answer, callback) {
        $http.post('/answer/add', answer).then(function (output) {
            callback(output.data)
        })
    }
    factory.showOne = function (id) {
        $location.url('/answer/' + id)
    }
    factory.likeAnswer = function (answer, callback) {
        $http.post('/answer/like', answer).then(function (output) {
            callback(output.data)
        })
    }
    return factory
})

