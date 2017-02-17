console.log('in fe_Factory')

app.factory('myF', ['$http', function($http){
    var factory={};
    var friends = [{first:'Elise', last: 'Drake', bday: '05/19/1991'}]

// this will send our controller the updated friends list
    factory.index = function(callback){
        console.log('in factory index');
        callback(friends);
        $http.get('/show').then(
            function(returned_data){
                console.log('returned_data',returned_data)
                callback(returned_data.data)
            }
        )

    }
    factory.addFriend = function(newFriend, callback){
        $http.post('/add', newFriend).then(function(returned_data){
            console.log('addFriend', returned_data)
            // latest friends list that has been updated from db
            callback(returned_data.data)
        })
    }
    factory.delete = function(id, callback){
        console.log('in factory.deleteUser');
        // we need to send our db the id (aka the $routeParams) so be sure to pass it through
        $http.delete('/delete/'+ id).then
        (function(returned_data){
            callback(returned_data.data)
            // DELETE IS WORKING BUT NOT UPDATING ON THE PAGE
        })
        // update will be .put
    }

    return factory;
}])
