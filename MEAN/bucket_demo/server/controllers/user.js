var mongoose = require('mongoose')
var User = mongoose.model("User")
module.exports = (function(){
  return{
    getAll:function(req,res){
      // res.json(['this is for testing!!!'])
      User.find({},function(err,users){
        User.find({})
        .populate('_created')
        .populate('_joined')
        .exec(function(err, users){
            res.json(users)
        })
        
      })
    }
  }
})()
