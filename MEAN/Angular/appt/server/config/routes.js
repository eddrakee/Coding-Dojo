var session = require('./../controllers/session.js')
var user = require('./../controllers/user.js')
var appt = require('./../controllers/appointment.js')
module.exports = function(app){
  app.post('/login', function(request,response){
    session.login(request,response)
  })
  app.get('/checkuser',function(request,response){
    session.checkUser(request,response)
  })
  app.get('/logout',function(request,response){
    session.logout(request,response)
  })
  //***************************************
  app.get('/users/get',function(request,response){
    user.getAll(request,response)
  })
  //**************************************
  app.post('/appt/add',function(request,response){
    appt.add(request,response)
  })
  app.get('/appt/all',function(request,response){
    appt.getAll(request,response)
  })
}
