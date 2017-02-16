console.log('in app.js')

var app = angular.module('myApp', ['ngRoute']);
app.config(function($routeProvider){
    $routeProvider
    .when('/', {
        templateUrl: 'partials/showList.html'
    })
    .otherwise({
        redirectTo: '/'
    });
})