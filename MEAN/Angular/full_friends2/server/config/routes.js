var user = require('./../controllers/users.js')

module.exports = function(app){
    app.post('/users/add', function(req, res){
        user.addUser(req, res)
    })

    app.get('/users/viewall', function(req, res){
        user.viewAll(req,res)
    })
    app.get('/users/delete/:id', function(req,res){
        user.delete(req, res)
    })
    app.post('/users/change', function(req, res){
        user.change(req, res)
    })
}