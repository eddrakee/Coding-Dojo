// add http after hooking up factory
app.factory('messageFactory', function($http){
    var factory = {};
    factory.getAll = function(callback){
        $http.get('/message/all').then(function(data){
            callback(data.data)
        })
    }

    factory.addMessage = function(message, callback){
        // pass message to our routes by adding it below
        // output is what came from the backend
        console.log(message)
        $http.post('/message/add', message).then(function(output){
            if(!output.data.status){
                alert('Something went wrong! Please enter a message!')
            }else{
                callback();
            }
            
        })
    }

    return factory;
})