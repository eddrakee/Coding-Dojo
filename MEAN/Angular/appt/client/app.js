var app = angular.module('app',['ngRoute'])
app.config(function($routeProvider){
  $routeProvider
  .when("/login",{
    templateUrl: 'partials/login.html'
  })
  .when('/dashboard',{
    templateUrl: 'partials/dashboard.html'
  })
  .when('/add',{
    templateUrl: 'partials/add.html'
  })
  .otherwise({
    redirectTo: '/login'
  })
})
