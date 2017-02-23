var mongoose = require('mongoose');
var Message = mongoose.model('Message');
var User = mongoose.model('User');

module.exports =(function(){
	return {
		add: function(req, res){
            // pass the properties you want to set
            var newMessage = new Message({content: req.body.content, _user: req.session.user._id})
            newMessage.save(function(err){
                if(err){
                    // make this more robust like res.json(err) make other ones an alert
                    // console.log(err)
                    res.json({status: false }) 
                    // or you can do status: fail
                }else{
                    // find the user that matches the session id
                    User.findOne({_id: req.session.user._id}, function(err, user){
                        // user is the user we just found above
                        user._messages.push(newMessage);
                        // to remove message use .remove
                        user.save(function(err){
                            res.json({status: true})
                        })
                    })
                }
            })
        },
        // all: function(req, res){
        //     Message.find({}, function(err, messages){
        //         // send all found messages to front end
        //         res.json(messages)
        //     })
        all: function(req, res){
            Message.find({})
            .populate('_user')
            .exec(function(err, messages){
                res.json(messages)
            })
        }
        
	}
})()