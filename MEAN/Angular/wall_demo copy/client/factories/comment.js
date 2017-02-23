app.factory('commentFactory', function($http){
    var factory = {};
factory.getAll = function(callback){
    $http.get('/comment/all').then(function(output){
        callback(output.data)
    })
}

factory.addComment = function(comment, callback){
    $http.post('/comment/add', comment).then(function(output){
        callback();
    })
}

    return factory
})