var mongoose = require('mongoose')
var User = mongoose.model("User")
module.exports = (function(){
  return{
    getAll:function(request,response){
      User.find({}, function(err,users){
        response.json(users)
      })
    }
  }
})()
