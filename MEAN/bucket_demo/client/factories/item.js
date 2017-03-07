app.factory('itemFactory',function($http, $location, $route){
  var factory = {}
    factory.addItem = function(item){
        // if passing objects, use post not get. so when console loging item, it should be an object. If it's a string, you can wrap it in an object
        // make sure the route starts with a /
        $http.post('/item/add', item).then(function(output){
            $route.reload();
        })
    }
    factory.getAll = function(callback){
        $http.get('/item/all').then(function(output){
            // if this callback is messed up, it will give you a "cant get _joined of null" error
            callback(output.data)
        })
    }
    factory.updateStatus = function(item){
        $http.post('/item/updatestatus', item).then(function(output){$route.reload()
            })
    }
  return factory
})
