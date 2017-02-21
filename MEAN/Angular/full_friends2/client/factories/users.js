app.factory('userFactory', function($http, $location, $route){
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
    factory.delete = function(id){
        $http.get('/users/delete/' + id).then(function(){
            $route.reload()
        })
    }
    factory.show = function(id){
        $location.url('/show/' + id)
    }
    factory.update = function(id){
        $location.url('/update/' + id)
    }
    factory.change = function(user){
        $http.post('/users/change', user).then(function(){
            $location.url('/dash')
        })
    }
    return factory;
})