var mongoose = require('mongoose')
var User = mongoose.model("User")
var Appt = mongoose.model("Appt")
module.exports = (function(){
  return{
    add:function(request,response){
      var appt = new Appt (request.body)
      appt.save(function(err){
        console.log('apppt!!!',appt);
        console.log("request.body", request.body);
        User.findOne({_id:request.body._createdBy},function(err,creator){
          creator._created.push(appt._id)
          creator.save(function(err){
            response.json(appt)
            console.log(creator);
          })
        })
      })
    },
    getAll:function(request,response){
      Appt.find({})
      .populate('_createdBy')
      .exec(function(err,appts){
        response.json(appts)
      })
    }
  }
})()
