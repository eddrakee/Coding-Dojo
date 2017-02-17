var friends = require ('./../controller/friends.js')

console.log('backend route!')
module.exports = function(app){
    app.get('/show', function(req,res){
        friends.index(req, res);
    })
    app.post('/add', function(req,res){
        friends.addFriend(req,res);
    })
    app.delete('/delete/:id', function(req, res){
        console.log(req.body);
        friends.delete(req,res);
    })
    app.get('/show/:id', function(req,res){
        console.log(req.params.id)
        friends.showOne(req,res);
    })
} 