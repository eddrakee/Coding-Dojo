console.log('in app.js')

var app = angular.module('myApp', ['ngRoute']);
app.config(function($routeProvider){
    $routeProvider
    .when('/', {
        templateUrl: 'partials/showList.html',
        controller: 'friendController',
    })
    .when('/add',{
        templateUrl: 'partials/addFriend.html',
        controller:'friendController'
    })
    .when('/show/:id',{
        templateUrl: 'partials/showOne.html',
        controller:'friendController'
    })
    .otherwise({
        redirectTo: '/'
    });
})