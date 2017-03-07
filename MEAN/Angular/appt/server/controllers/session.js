var mongoose = require('mongoose')
var User = mongoose.model("User")
module.exports = (function(){
  return{
    login:function(request,response){
      console.log(request.session.user);
      User.findOne({name:request.body.name}, function(err,user){
        if(!user){
          var newUser = new User (request.body)
          newUser.save(function(err){
            if(err){
              return response.json({error:"Something wrong. Please try again"})
            }
            else{
              request.session.user = newUser
              request.session.save()
              response.json({status:true})
            }
          })
        }
        else{
          request.session.user = user
          request.session.save()
          response.json({status:true})
        }
      })
    },
    checkUser:function(request,response){
      if(!request.session || !request.session.user){
        response.json(null)
      }
      else{
        response.json(request.session.user)
      }
    },
    logout:function(request,response){
      request.session.destroy()
      response.redirect('/')
    }
  }
})()
