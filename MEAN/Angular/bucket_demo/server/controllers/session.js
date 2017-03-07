var mongoose = require('mongoose');
var User = mongoose.model('User');

module.exports = (function(){
    return {
        login: function(req, res){
            console.log(req.session.user)
            // user is info we found from database
            User.findOne({name: req.body.name}, function(err, user){
                if (!user){
                    var newUser = new User(req.body);
                    newUser.save(function(err){
                        if(err){
                            return res.json({err:'something went wrong. Please try again'})
                        }
                        // if there isn't a user in our db, save it!
                        req.session.user = newUser;
                        req.session.save()
                        // if status exists, that means the user correctly logged in!
                        res.json({status:true})
                    })
                }else{
                    // if the user already exists, go get it!
                    req.session.user = user;
                    req.session.save();
                    // will send back an object so in data it will show status
                    res.json({status:true})
                }
            })
        },
        checkUser: function(req, res){
            // it nothing in it or user doesn't exist (aka no one logged in)
            if(!req.session || !req.session.user){
            res.json(null)
            }else{
                res.json(req.session.user)
            }
        },
        logout: function(req, res){
            req.session.destroy();
            // this will load up index
            res.redirect('/')
        }
    }
})()
// immediate function!
