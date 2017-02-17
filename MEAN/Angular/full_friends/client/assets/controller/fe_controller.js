console.log('in fe_controller')

app.controller('friendController', ['$scope', 'myF', '$routeParams', function($scope, myF, $routeParams){
    console.log('friendController working');
    $scope.friends=[];
    
    function updateInfo(){
        myF.index(function(data){
            $scope.friends = data;
        });
    }
    updateInfo();

    $scope.addFriend = function(){
        myF.addFriend($scope.newFriend, updateInfo)
    }
    $scope.delete = function($routeParams){
        console.log('in controller.delete');
        console.log($routeParams)
        // have to pass through updateInfo to get the latest info after augmenting it
        myF.delete($routeParams, updateInfo);
        updateInfo()
    }
}])