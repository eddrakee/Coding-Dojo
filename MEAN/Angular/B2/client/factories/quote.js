app.factory('quoteFactory', function($http, $location){
    var factory = {}

    factory.allQuotes = function(callback){
        $http.get('/quotes/allQuotes').then(function(output){
             
            callback(output.data)
        })
    }

    factory.addQuote = function(quote){
        $http.post('/quotes/add', quote).then(function(output){
            factory.quote.push(output.data)
            $location.url('/dashboard')
        })
    }
    factory.showOne = function(author, callback){
        $http.post('/quotes/author',  {author: author}).then(function(data){
            callback(data.data)
        })
    }

    return factory
}) 