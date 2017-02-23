var app = angular.module('myMod', ['ngRoute', 'angularMoment']);


app.config(function($routeProvider){
	$routeProvider
	.when('/login',{
		templateUrl: 'partials/login.html'
	})
	.when('/dash',{
		templateUrl: 'partials/dash.html'
	})
	.otherwise({
		redirectTo: '/login'
	})
})
