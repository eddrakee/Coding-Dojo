var session = require('./../controllers/session.js')
var question = require('./../controllers/question.js')
var answer = require('./../controllers/answer.js')
module.exports = function (app) {
    app.post('/login', function (req, res) {
        session.login(req, res);
    })
    app.get('/checkuser', function (req, res) {
        session.checkUser(req, res);
    })
    app.get('/logout', function (req, res) {
        session.logout(req, res)
    })
    // QUESTION ROUTES
    app.post('/question/add', function (req, res) {
        question.add(req, res)
    })
    app.get('/question/all', function (req, res) {
        question.all(req, res)
    })
    // ANSWER ROUTES
    app.post('/answer/add', function (req, res) {
        answer.add(req, res)
    })
    app.post('/answer/like', function (req, res) {
        answer.likeAnswer(req, res)
    })


}
