// http not defined error means I forgot to pass in http below!
app.factory('sessionFactory', function($http){
    var factory = {};

// user is logReg from index.html
    factory.login = function(user){
        // $http is how we send to backend routes
        // post is the only one that can send data, not get
        // can ONLY pass objects to the backend. Can't do strings or anything else!!!!
        $http.post('/login', user)
        // data is what we are sending back to the front end (in this case it is )
        .then(function(data){
            console.log(data)
        })
    }


    return factory;
})