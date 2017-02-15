
var firstApp = angular.module('userApp', []);

console.log(firstApp);
firstApp.controller('userController', ['$scope', function($scope){
    console.log('hello');
    $scope.userList = [];

    $scope.addUser = function(){
        console.log('addUser working')
        $scope.userList.push($scope.newUser);
        $scope.newUser = {};
    console.log($scope.newUser);
    };
    $scope.remove = function(item){
        console.log('delete working');
        var index = $scope.userList.indexOf(item);
        $scope.userList.splice(index, 1);
    }
}]);