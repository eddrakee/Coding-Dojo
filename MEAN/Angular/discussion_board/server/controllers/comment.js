var mongoose = require('mongoose');
var Question = mongoose.model('Question')
var User = mongoose.model('User')
var Comment = mongoose.model('Comment')

module.exports = (function(){
    return{
        add:function(req, res){
        
            var comment = new Comment({content: req.body.content, _user:req.body._user, _questions:req.body._question})
            comment.save(function(err, commentData){
                User.findOne({_id:commentData._user}, function(err, userData){
                
                    userData._comments.push(commentData._id);
                    userData.save(function(err){
                        Question.findOne({_id:commentData._questions}, function(err, questionData){
                            questionData._comments.push(commentData._id);
                            questionData.save(function(err){
                                res.json(commentData)
                            })
                        } )
                    })
                })
            })
        }
    }
})()