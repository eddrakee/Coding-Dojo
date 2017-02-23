var app = angular.module('app', ['ngRoute', 'angularMoment']);
app.config(function($routeProvider){
    $routeProvider
    .when('/login',{
        templateUrl: 'partials/login.html'
    })
    .when('/dashboard', {
        templateUrl: 'partials/dashboard.html'
    })
    .when('/add',{
        templateUrl: 'partials/add.html'
    })
    .when('/showAll', {
        templateUrl: 'partials/show.html'
    })
    .when('/showOne/:author',{
        templateUrl: 'partials/showOne.html'
    })
    .otherwise({
        redirectTo: '/login'
    })
})