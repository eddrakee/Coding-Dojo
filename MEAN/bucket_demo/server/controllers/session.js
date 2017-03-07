var mongoose = require('mongoose');
var User = mongoose.model("User");
module.exports = (function(){
  return{
    login:function(req,res){
      User.findOne({name: req.body.name}, function(err,user){
        if(!user){
          //info we found in our database
          var newUser = new User(req.body)
          newUser.save(function(err){
            if(err){
              return res.json({error: 'Something went wrong. Please try again'})
              // backend validation!
            }
            req.session.user = newUser
            req.session.save()
            res.json({status:true})
            // if status exists, that means user logged in correctly.

          })
        }else{
          req.session.user = user;
          req.session.save()
          res.json({status:true})
        }
      })
    },
    checkUser: function(req,res){
      if(!req.session || !req.session.user){
        res.json(null)
      }
      else{
        res.json(req.session.user)
      }
    },
    logout: function(req,res){
      req.session.destroy();
      res.redirect('/')
    }
  }
})()
