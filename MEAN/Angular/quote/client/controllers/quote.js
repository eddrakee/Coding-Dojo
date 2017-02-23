app.controller('quoteController',function($scope, quoteFactory, $routeParams, $route){
    $scope.errors = []
    // $scope.showOne = function(author){
    //     console.log
        
    // }
    // // from ray
    if($routeParams.author){
        quoteFactory.showOne($routeParams.author, function(data){
            $scope.showOne = data
        })
    }

    // if($routeParams.id){
    //     console.log('RP', $routeParams.id )
    //     quoteFactory.allQuotes(function(data){
    //         $scope.quotes = data
    //         for(quote in $scope.quotes){
    //             console.log('QUOTE', $scope.quotes)
    //             if($scope.quotes[quote]['_id']== $routeParams.id){
    //                 $scope.currentAuthor = $scope.quotes[quote]
            
    //             }
    //         }
    //     })
    // }
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
        else if($scope.newQuote.content.length < 4){
            $scope.errors.push("please enter longer quote")
        }
        else if($scope.newQuote.content.length > 50){
            $scope.errors.push("QUOTE TOO LONG")
        }
        else if(!$scope.newQuote || !$scope.newQuote.author){
            $scope.errors.push("please enter author")
        }
        else if($scope.newQuote.author.length < 4){
            $scope.errors.push("please enter longer author name")
        }
        else if($scope.newQuote.author.length > 30){
            $scope.errors.push("Is the author's name really that long?")
        }
        else if(!$scope.newQuote || !$scope.newQuote.date){
            $scope.errors.push("please enter date")
        }
        else{
            $scope.newQuote._id = id
            quoteFactory.addQuote($scope.newQuote)
            $scope.newQuote = {}
            // NEED TO FIGURE OUT HOW TO DISPLAY ALL ERROR MESSAGES WHILE USING ELSE IF
        }

    }
    $scope.likeQuote = function(quote){
        quoteFactory.likeQuote(quote, function(data){
            console.log(data)
            $scope.quote = data.likes
            $route.reload()
        });
        
    }
})