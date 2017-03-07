var mongoose = require('mongoose');
var User = mongoose.model('User');
var Question = mongoose.model('Question');
var Answer = mongoose.model('Answer');

module.exports = (function () {
    return {
        add: function (req, res) {
            var answer = new Answer({ content: req.body.content, description: req.body.description, _user: req.session.user, _questions: req.body._question })
            answer.save(function (err, answerData) {
                User.findOne({ _id: answerData._user }, function (err, userData) {
                    // I struggled trying to get the user's name to show up on the showOne page, and could not get their name to be added without getting an error
                    userData._answers.push(answerData._id);
                    userData.save(function (err) {
                        Question.findOne({ _id: answerData._questions }, function (err, questionData) {
                            questionData.num_answers += 1
                            questionData._answers.push(answerData._id)
                            questionData.save(function (err) {
                                res.json(answerData)
                            })
                        })
                    })
                })
            })
        },
        likeAnswer: function (req, res) {
            Answer.findById({ _id: req.body._id }, function (err, answer) {
                answer.likes += 1;
                answer.save(function (err) {
                    res.json(answer)
                })
            })
        },
    }
})()
