// we have access to app (which is originally found in app.js) because we linked this controller underneath the app.js link.
app.controller('userController', function($scope, userFactory, $routeParams){
    // if this exists..
    if($routeParams.id){
        // run a callback to view all users that will run automatically
    userFactory.allUsers(function(data){
        // we just created the term "users"
        $scope.users = data
        for(user in $scope.users){
            // $scope.users[user] is the current info we have
            if($scope.users[user]['_id']==$routeParams.id){
                // this is where we set cur_user
                $scope.cur_user = $scope.users[user]
                console.log($scope.cur_user)
            }
        }
    })
    }else{
        // we dont want it to run twice, so we will use the else statement to run if there is no $rP
        userFactory.allUsers(function(data){
            $scope.users = data
        })
    }
    $scope.addUser = function(){
        userFactory.addUser($scope.newUser);
    }
    $scope.delete = function(id){
        userFactory.delete(id)
    }
    $scope.show = function(id){
        userFactory.show(id)
    }
    $scope.update = function(id){
        userFactory.update(id)
    }
    $scope.change = function(){
        userFactory.change($scope.cur_user)
    }
})