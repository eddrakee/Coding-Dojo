app.controller('quoteController',function($scope, quoteFactory, $routeParams, $route){
    $scope.errors = []

    if($routeParams.author){
        quoteFactory.showOne($routeParams.author, function(data){
            $scope.showOne = data
        })
    }
    else{
        quoteFactory.allQuotes(function(data){
        $scope.quotes = data
        })
    }
    
    $scope.addQuote = function(id){
        $scope.errors = []
        if(!$scope.newQuote || !$scope.newQuote.content ){
            $scope.errors.push("please enter content")
        }
        else if($scope.newQuote.content.length < 10){
            $scope.errors.push("Description must be at least 10 characters")
        }
        else if(!$scope.newQuote || !$scope.newQuote.title){
            $scope.errors.push("Please enter an item name")
        }
        else if($scope.newQuote.title.length < 5){
            $scope.errors.push("Item names must be at least 5 characters")
        }
        else{
            $scope.newQuote._id = id
            quoteFactory.addQuote($scope.newQuote)
            $scope.newQuote = {}
        }

    }
})