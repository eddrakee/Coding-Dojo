//  make sure this is an immediate function
 var mongoose = require('mongoose');
 var User = mongoose.model('User');
 module.exports = (function(){
     return{
         addUser: function(req, res){
             var user  = new User(req.body);
             user.save(function(err, data){
                 if (err){
                     console.log(err)
                 }else{
                     res.json(data);
                 }
             })
         }
     }
 })()