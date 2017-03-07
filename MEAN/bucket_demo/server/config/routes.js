var session = require('./../controllers/session.js')
var user = require('./../controllers/user.js')
var item = require('./../controllers/item.js')
module.exports = function(app){
  app.post('/login',function(req,res){
    session.login(req,res)
  })
  app.get('/checkuser', function(req,res){
    session.checkUser(req,res)
  })
  app.get('/logout', function(req,res){
    session.logout(req,res)
  })
  // USER ROUTES
  app.get('/users/get',function(req,res){
    // res.json(['this is for testing!!! should see in broswer console.'])
    // console.log(user); this results in empty object in backend
    user.getAll(req,res)
  })
  // ITEM ROUTES
  app.post('/item/add', function(req, res){
    item.add(req, res)
  })
  app.get('/item/all', function(req, res){
    item.all(req, res)
  })
  app.post('/item/updatestatus', function(req, res){
    item.updateStatus(req, res)
  })
}
