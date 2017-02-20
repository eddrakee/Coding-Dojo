var user = require('./../controllers/users.js')

module.exports = function(app){
    app.post('/users/add', function(req, res){
        user.addUser(req, res)
    })

    app.get('/users/viewall', function(req, res){
        res.json(['elise', 'doug'])
    })
}