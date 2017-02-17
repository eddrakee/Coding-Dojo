// link our back end session controller to routes
var session = require('./../controllers/session.js')

// app is being sent through server.js file
module.exports = function(app){
    app.post('/login', function(req, res){
        // .send will send back to the function that called it
        session.login(req, res)
    })
    app.get('/checkuser', function(req, res){
        // to check use:
        // res.json(null)
        session.checkUser(req, res)
    })
    app.get('/logout', function(req, res){
        session.logout(req, res)
    })
}