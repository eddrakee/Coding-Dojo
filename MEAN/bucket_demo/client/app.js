var app = angular.module('app',['ngRoute'])
app.config(function($routeProvider){
  $routeProvider
  .when('/login',{
    templateUrl: 'partials/login.html'
  })
  .when('/dash',{
    templateUrl: 'partials/dash.html'
  })
  .when('/show/:id',{
    templateUrl: 'partials/showOne.html'
  })
  .otherwise({
    redirectTo: '/login'
  })
})
