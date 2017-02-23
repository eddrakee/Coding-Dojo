 var session = require('./../controllers/session.js')
    module.exports = function(app){
        app.post('/login', function(req,res){
            session.login(req, res)
        })
        app.get('/checkuser', function(req, res){
            session.checkUser(req, res);
        })
        app.get('/logout', function(req, res){
            session.logout(req, res)
        })
    }