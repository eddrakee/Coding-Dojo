app.factory('userFactory', function($http, $location){
    var factory = {};

    factory.allUsers = function(callback){
        $http.get('/users/viewall').then(function(output){
            callback(output.data)
        })
    }
    factory.addUser=function(user){
        $http.post('/users/add', user).then(function(output){
            console.log(output.data)
            $location.url('/dash')
        })
    }
    return factory;
})