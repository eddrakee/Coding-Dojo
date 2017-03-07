app.factory('commentFactory', function($http){
    var factory = {}
    factory.addComment = function(comment, callback){
        $http.post('/comment/add', comment).then(function(output){
            callback(output.data)
        })
    }
    return factory
})