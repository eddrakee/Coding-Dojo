var app = angular.module('myMod', ['ngRoute']);

app.config(function($routeProvider){
    $routeProvider
    .when('/dash', {
        templateUrl:'partials/dash.html'
    })
    .when('/new', {
        templateUrl:'partials/new.html'
    })
    .otherwise({
        redirectTo:'/dash'
    })
})