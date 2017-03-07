app.factory('questionFactory', function($http, $location){
    var factory = {}

    factory.getAll = function(callback){
        $http.get('/question/all').then(function(output){
            callback(output.data)
        })
    }
    factory.addQuestion = function(question, callback){
        $http.post('/question/add', question).then(function(output){
            if(!output.data.status){
                alert('Something went wrong! Please enter a message!')
            }else{
                callback()
            }
            
        })
    }
    factory.showOne = function( id){
        $location.url('show/' + id)
    }
    // factory.likeQuestion = function(question, callback){
    //     $http.post('/question/like', question).then(function(output){
    //         callback(output.data)
    //     })
    // }
    return factory
})