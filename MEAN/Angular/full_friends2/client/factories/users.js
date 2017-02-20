app.factory('userFactory', function($http){
    var factory = {};
    factory.addUser=function(user){
        $http.post('/users/add', user)
    }
    return factory;
})