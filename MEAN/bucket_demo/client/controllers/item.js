app.controller('itemController', function($scope, itemFactory){
    $scope.errors = [];
    $scope.addItem = function(curUser){
        $scope.errors = [];
        if(!$scope.newItem || !$scope.newItem.description ){
            $scope.errors.push("please enter content")
        }
        else if($scope.newItem.title.length < 5){
            $scope.errors.push("Item names must be minimum of 5 characters")
        }
        else if($scope.newItem.description.length < 10){
            $scope.errors.push("Descriptions must be minimum of 10 characters")
        }
        else{
        $scope.newItem._createdBy = curUser;
        itemFactory.addItem($scope.newItem)
        }
    }
    itemFactory.getAll(function(data){
        $scope.items = data
        console.log(data)
    })

    $scope.updateStatus = function(item){
        itemFactory.updateStatus(item)
    }
})