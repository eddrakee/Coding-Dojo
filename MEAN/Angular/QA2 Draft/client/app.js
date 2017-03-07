var app = angular.module('app', ['ngRoute'])
app.config(function($routeProvider){
        $routeProvider
        .when('/login',{
            templateUrl: 'partials/login.html'
        })
        .when('/dashboard',{
            templateUrl: 'partials/dashboard.html'
        })
        .when('/question/add',{
            templateUrl: 'partials/addQuestion.html'
        })
        .when('/show/:id',{
            templateUrl: 'partials/showOne.html'
        })
        .when('/answer/add/:id',{
            templateUrl: 'partials/addAnswer.html'
        })
        .otherwise({
            redirectTo: '/login'
        })
    })