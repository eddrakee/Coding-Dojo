app.factory('answerFactory', function($http){
    var factory = {}

    // factory.getAll = function(callback){
    //     $http.get('/answer/all').then(function(output){
    //         callback(output.data)
    //     })
    // }

    // factory.addAnswer = function(answer, callback){
    //     console.log(answer, "factory")
    // $http.post('/answer/add', answer).then(function(output){
    // callback()
    //     // callback(output.data)

    //     })
    // }
    factory.addAnswer = function(answer, callback){
        $http.post('/answer/add', answer).then(function(output){
            console.log(output.data)
            callback(output.data)
        })
    }
    factory.showOne = function(id){
        $location.url('/answer/'+id)
    }
    factory.likeAnswer = function(answer, callback){
        $http.post('/answer/like', answer).then(function(output){
            callback(output.data)
            console.log('lik fac', output.data)
        })
    }
    return factory
})