var mongoose = require('mongoose');
var User = mongoose.model('User');
var Question = mongoose.model('Question');
var Answer = mongoose.model('Answer');

module.exports = (function(){
    return{
        add: function(req, res){
            // req.body.name = req.session.user.name
            // var answer = new Answer({content:req.body.content, _user:req.body.user._id, _questions:req.body._question, })
            var answer = new Answer({content:req.body.content, description:req.body.description, _user:req.session.user, _questions:req.body._question, })
            // console.log(req.body, "redq")
            answer.save(function(err, answerData){
                // console.log('answerdata', answerData)
                User.findOne({_id:answerData._user}, function(err, userData){
                    userData._answers.push(answerData._id);
                    
                    // console.log('answers', userData)
                    userData.save(function(err){
                        Question.findOne({_id:answerData._questions}, function(err, questionData){
                            // console.log('anda', answerData._questions)
                            // console.log('q',questionData, err )
                            questionData._answers.push(answerData._id)
                            questionData.save(function(err){
                                res.json(answerData)
                                console.log(answerData)
                            })
                        })
                    })
                })
            })
        },
        like: function(req, res){
            Answer.findById({_id:req.body._id}, function(err, answer){
                answer.likes +=1
                answer.save(function(err){
                    res.json(answer)
                })
            })
        }
        // add: function(req, res){
        //     var answer = new Answer({content:req.body.content, _user:req.body._user, _questions:req.body._question})
        //     answer.save(function(err, answerData){
        //         console.log(answerData)
        //         User.findOne({_id:answerData._user}, function(err, userData){
        //             userData._answers.push(answerData._id);
        //             userData.save(function(err){
        //                 Question.findOne({_id:answerData._questions}, function(err, questionData){
        //                     questionData._answers.push(answerData._id);
        //                     questionData.save(function(err){
        //                         res.json(answerData)
        //                         console.log(answerData, 'answerdata')
        //                     })
        //                 })
        //             })

        //         })
        //     })
        // }, 
        // all: function(req, res){
        //     Answer.find({})
        //     .populate('_user')
        //     .populate('_question')
        //     .exec(function(err, answers){
        //         res.json(answers)
        //     })
        // }
    }
})()
