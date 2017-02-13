var mongoose = require('mongoose');
var Birth = mongoose.model('Birth')
module.exports = (function(){
    return{
        index: function(req, res){
            console.log('index');
            Birth.find({}, function(err, data){
                console.log(data);
                res.json(data);
            })
        },
        new: function(req, res){
            var births = new Birth(req.params);
            console.log(req.params.name)
            births.save();
            res.json(births);
        },
        delete: function(req, res){
            Birth.remove({_id: req.params.id}, function(err){
            return res.redirect('/')
            });
         },
         findName: function(req, res){
             Birth.findOne({name:req.params.name}, function(err, data){
                 res.json(data);
             })
         }
        }
    })();