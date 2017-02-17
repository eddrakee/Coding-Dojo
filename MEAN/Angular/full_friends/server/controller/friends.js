// 2 - After setting up our controller, then add these two lines:
var mongoose = require('mongoose');
// this is how we reference our Friend collection in our friend_db database
var Friend = mongoose.model('Friend');
// 1 - Initially, all you need is below:
module.exports = (function(){
    return{
        index: function(req, res){
            console.log('in be_controller.index!');
            // 1 - initially hard coded a person to test it out
            // res.json([{first:'Elise', last: 'Drake', bday: '05/19/1991'}])
            // 2 - let  it find people!
            Friend.find({}, function(err, data){
                console.log(data)
                res.json({friends:data})
                });
    
        },

        addFriend: function(req, res){
            console.log('in friends Add Friend');
            console.log(req.body);
            var friend = new Friend(req.body)
                friend.save(function(err){
                    if(err){
                        res.json(err);
                  }
                return res.json(friend) 
                // use this friend to append to factory friendList to add it
            });
        },
        delete: function(req, res){
            console.log('in friends Delete');
            Friend.remove({_id:req.params.id}, function(err){
// you don't need a redirect since our backend shouldn't have to do anything like this!
            });
          
        },
        showOne: function(req, res){
            console.log('in be_controller showOne');
            Friend.findOne({_id:req.params.id}, function(err, data){
                console.log(data)
                res.json({friends:data})
            });
        }
    }

// make sure to invoke the function down here cause it's immediate!
})();