var app = angular.module('myMod', ['ngRoute']);

app.config(function($routeProvider){
    $routeProvider
    .when('/login', {
        templateUrl: 'partials/login.html',
        controller: 'sessionController'
    })
    .otherwise({
        redirectTo: '/login'
    })
})
