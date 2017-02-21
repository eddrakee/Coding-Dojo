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
    .when('/show/:id', {
        templateUrl:'partials/show.html',
        controller: 'userController'
    })
    .when('/update/:id', {
        templateUrl:'partials/update.html',
        controller: 'userController'
    })
    .otherwise({
        redirectTo:'/dash'
    })
})