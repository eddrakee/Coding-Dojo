app.factory('questionFactory', function($http, $location, $route){
    var factory = {};
    // factory.questions = []

    factory.addQuestion = function(question, callback){
    $http.post('/question/add', question).then(function(output){
        callback()

        // if not going back to dashboard
        // factory.messages.push(output.data)
            // callback(output.data)
        
        $location.url('/dashboard')
    })
    }
    factory.getAll = function(callback){
        $http.get('/question/getall').then(function(output){
            callback(output.data)
    })
    }
    factory.showTopic = function(id){
        $location.url('/showTopic/' + id)
    }

    return factory;
})