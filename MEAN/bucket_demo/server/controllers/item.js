var mongoose = require('mongoose');
var Item = mongoose.model('Item')
var User = mongoose.model('User')
module.exports = (function(){
    return {
        add:function(req, res){
        var item = new Item(req.body);
        item.save(function(err){
            // we just saved, so now we have to update and do it twice since we have two associations
            User.findOne({_id: req.body._createdBy}, function(err, creator){
                creator._created.push(item._id)
                creator.save(function(err){
                    if(req.body._joinedBy){
                        User.findOne({_id: req.body._joinedBy}, function(err, joiner){
                        joiner._joined.push(item._id)
                        joiner.save(function(err){
                            
                            })
                        })
                    }// send the item we just saved
                    res.json(item)
                    
                })
            })
        })
        },
        all: function(req, res){
            Item.find({})
                .populate('_createdBy')
                .populate('_joinedBy')
                .exec(function(err, items){
                    res.json(items)
                })
        },
        updateStatus: function(req, res){
            Item.findOne({_id: req.body._id}, function(err, item){
                if(item.status == 'Pending'){
                    // make sure this as only one equal sign for done!
                    item.status = 'Done'
                }else{
                    item.status = 'Pending'
                }
                item.save(function(err){
                    res.json(item)
                })
            })
        }
    }
})()