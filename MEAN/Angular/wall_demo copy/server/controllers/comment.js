var mongoose = require('mongoose');
var Message = mongoose.model('Message');
var User = mongoose.model('User');
var Comment = mongoose.model('Comment');

module.exports = (function(){
    return{
        add:function(req, res){
            var comment = new Comment(req.body)
            comment.save(function(err, commentData){
                User.findOne({_id:commentData._user}, function(err, userData){
                    userData._comments.push(commentData._id)
                    userData.save(function(err){
                        Message.findOne({_id:commentData._message}, function(err, messageData){
                            messageData._comments.push(commentData._id);
                            messageData.save(function(err){
                                res.json(commentData)
                            })
                        })
                    })
                })
            })
        },
        all: function(req, res){
            Comment.find({})
            .populate('_user')
            .populate('_message')
            .exec(function(err, comments){
                res.json(comments)
            })
        }
    }
})()