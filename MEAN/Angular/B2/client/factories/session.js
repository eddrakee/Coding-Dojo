app.factory('sessionFactory', function($http, $location){
    var factory = {};
    factory.login = function(user){
        $http.post('/login', user).then(function(output){
            if(output.data){
                $location.url('dashboard')
            }
        })
    }
    factory.checkUser = function(callback){
        $http.get('/checkUser').then(function(output){
            if(!output.data){
                $location.url('/login')
            }else{
                callback(output.data)
            }
        })
    }
    return factory
})