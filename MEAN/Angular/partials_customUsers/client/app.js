var myApp = angular.module('mod', ['ngRoute']);

    //  use the config method to set up routing:
    myApp.config(function ($routeProvider) {
      $routeProvider
        .when('/',{
            templateUrl: 'partials/customizeUsers.html',
            controller: 'userController'
        })
        .when('/showUsers',{
            templateUrl: 'partials/userList.html',
            controller: 'showController'
        })
        .otherwise({
          redirectTo: '/'
        });
    
    });

// CONTROLLERS

 myApp.controller('userController', ['$scope', 'userFactory', function($scope, userFactory){
    function setUsers(data){
        $scope.userList = data;
        // passed in via form on html
        $scope.newUser = {};
    }
    $scope.userList = [];

    // This will load the user list when the controller is loaded
    userFactory.index(setUsers)

    // When new user info is passed into the factory it will return it to here 
    $scope.createUser = function(){
        console.log($scope.newUser)
        userFactory.createUser($scope.newUser);
        // code below will reset the form!
        $scope.newUser = {};
        console.log($scope.newUser);
    }
    $scope.deleteUser = function($index){
        console.log('in controller.deleteUser')
        userFactory.deleteUser($index);
    }
 }]);

myApp.controller('showController', ['$scope', 'userFactory', function($scope, userFactory){
    function setUsers(data){
        $scope.userList = data;
    }
    $scope.userList=[];
    userFactory.index(setUsers);
}])

// FACTORY

myApp.factory("userFactory", [function(){
    // this factory object will grow to hold all of the methods below (like .index!)
    var factory = {};
    // need to initialize user list
    var userList = [
        {first: 'Elise', last: 'Drake', book: 'Kafka on the Shore'}
    ];

    // a controller will use this to get the user list
    factory.index = function(callback){
        console.log('in factory.index');
        callback(userList);
    }
    // controller.createUser will call to this to create a user
    factory.createUser = function(user){
        console.log('in factory.createUser');
        userList.push(user);
    }
    // to delete a user!
    factory.deleteUser = function($index){
        console.log('in factory.deleteUser');
        userList.splice($index, 1);
        
    }

    // make sure to always return the factory! Or else nothing will be passed back
    return factory;
}])
