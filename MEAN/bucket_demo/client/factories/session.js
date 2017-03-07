app.factory('sessionFactory', function($http, $location){
  var factory = {};
  factory.login = function(crazyCatOwner){
    $http.post('/login',crazyCatOwner).then(function(output){
      if(output.data){
        $location.url('/dash')
      }
    })
    // can only pass objects to the backend!!!!! will not work with string.. will say cannot read property token

  }
  factory.checkUser = function(callback){
    $http.get('/checkuser').then(function(output){
      if(!output.data){
        $location.url('/login')
      }
      else{
        callback(output.data)
      }
    })
  }
  return factory;
})
