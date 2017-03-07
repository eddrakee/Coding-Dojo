var session = require('./../controllers/session.js')
var quote = require('./../controllers/quotes.js')
module.exports = function(app){
    app.post('/login', function(req, res){
        session.login(req, res)
    })
    app.get('/checkUser', function(req, res){
        session.checkUser(req, res)
    })
    app.get('/logout', function(req, res){
        session.logout(req, res)
    })
    //******************************************
    app.post('/quotes/add',function(req,res){
        quote.addQuote(req,res)
    })
    app.get('/quotes/allQuotes', function(req, res){
        quote.allQuotes(req, res)
    })
    app.post('/quotes/like', function(req, res){
        quote.likeQuote(req,res)
    })
    app.post('/quotes/author', function(req ,res){
       quote.showAuthor(req, res)
    })
    
    app.post('/quote/status', function(req, res){
        quote.changeStat(req, res)
    })
}