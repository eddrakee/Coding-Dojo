var mongoose = require('mongoose');
var Question = mongoose.model('Question')
var User = mongoose.model('User')
module.exports = (function(){
    return{
        add:function(req, res){
            console.log(req.body)
            var question = new Question({topic:req.body.topic,description:req.body.description, category:req.body.category, _user:req.body._id})

            question.save(function(err, data){
                User.findOne({_id: req.body._id}, function(err, user){
                    user._questions.push(req.body._id)
                    user.save(function(err, userData){
                        res.json(data)
                
                    })
                })
            })
            
        },
        getAll: function(req, res){
            Question.find({})
            .populate('_user')
            // do this later
            .populate('_comments')
            // .populate('_comments._user')
            .exec(function(err, questions){
                res.json(questions)
            })
        }
    }
})()