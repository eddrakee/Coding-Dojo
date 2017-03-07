app.factory ('apptFactory',function($http,$location){
  var factory = {}
  factory.getAll = function(callback){
    $http.get('/appt/all').then(function(output){
      callback(output.data)
    })
  }
  factory.add = function(appointment){
    $http.post('/appt/add', appointment).then(function(output){
      $location.url('/dashboard')
    })

  }
  return factory
})
