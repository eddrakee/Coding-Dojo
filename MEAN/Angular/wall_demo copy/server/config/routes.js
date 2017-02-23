//  ROUTES FOR LOGIN
var session = require('./../controllers/session.js')
var message = require('./../controllers/message.js')
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

//  ROUTES FOR MESSAGES
	app.post('/message/add', function(req, res){
		message.add(req, res);
	})
	app.get('/message/all', function(req, res){
		message.all(req, res)
	})

// ROUTES FOR COMMENTS
	app.post('/comment/add', function(req, res){
		comment.add(req,res)
	})

	app.get('/comment/all', function(req, res){
		comment.all(req, res)
	})
}
