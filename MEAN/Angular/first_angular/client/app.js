// firstModule takes in firstApp and an array
var firstModule = angular.module('firstApp', []);

// controller is a method from the firstModule object
firstModule.controller('firstController', ['$scope', function($scope){
    $scope.myName = 'Elise';
    $scope.fav_lang = 'CSS';
    $scope.fav_lib = 'Angular';
}]);