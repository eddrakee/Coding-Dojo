var session = require('./../controllers/session.js')
var question = require('./../controllers/question.js')
var comment = require('./../controllers/comment.js')
module.exports = function(app){
    app.post('/login', function(req, res){
        session.login(req, res);
    })
    app.get('/checkuser', function(req, res){
        session.checkUser(req, res);
    })
    app.get('/logout', function(req, res){
        session.logout(req, res)
    })
    // ******
    app.post('/question/add', function(req, res){
        question.add(req, res)
    })
    app.get('/question/getall', function(req, res){
        question.getAll(req,res)
    })
    // ***** COMMENTS *******
    app.post('/comment/add', function(req, res){
        comment.add(req, res)
    })
}
