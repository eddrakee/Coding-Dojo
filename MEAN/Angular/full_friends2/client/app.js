var app = angular.module('myMod', ['ngRoute']);

app.config(function($routeProvider){
    $routeProvider
    .when('/dash', {
        templateUrl:'partials/dash.html',
        controller: 'userController'
    })
    .when('/new', {
        templateUrl:'partials/new.html',
        controller: 'userController'
    })
    .otherwise({
        redirectTo:'/dash'
    })
})