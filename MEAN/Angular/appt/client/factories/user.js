app.factory('userFactory', function($http){
  var factory = {}
  factory.getAll = function(callback){
    $http.get('/users/get').then(function(output){
      callback(output.data)
    })
  }
  return factory
})
