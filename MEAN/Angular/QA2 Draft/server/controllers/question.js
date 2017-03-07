var mongoose = require('mongoose');
var Question = mongoose.model('Question')
var User = mongoose.model('User')

module.exports = (function(){
    return{
        add:function(req, res){
            var question = new Question({topic: req.body.topic, description:req.body.description, _user:req.session.user._id})
            question.save(function(err, data){
                if(err){
                    res.json({status:false})
                }else{
                    User.findOne({_id: req.session.user._id}, function(err, user){

                        user._questions.push(question)
                        user.save(function(err, userData){
                            res.json({status:true})
                        })
                    })
                }
            })
        },
        all: function(req, res){
            Question.find({})
            .populate('_user')
            .populate('_answers')
            .exec(function(err, questions){
                res.json(questions)
            })
        },
        likeQuestion: function(req, res){
            Question.findById({_id: req.body._id}, function(err, question){
                question.likes += 1
                question.save(function(err){
                    res.json(question)
                    console.log(question, "back")
                })
            })

        }
    }
})()