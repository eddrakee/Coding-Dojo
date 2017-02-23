var mongoose = require('mongoose')
var Quote = mongoose.model('Quote')
var User = mongoose.model("User")
module.exports = (function(){
    return{
        addQuote:function(req,res){
            var quote = new Quote({content:req.body.content, author: req.body.author, date:req.body.date , likes:req.body.likes, _user:req.body._id})
            quote.save(function(err,data){
                User.findOne({_id:req.body._id}, function(err,user){
                    user._quotes.push(data._id)
                    user.save(function(err,userData){
                        res.json(data)
                    })
                })
            })
        },
        allQuotes: function(req, res){
            Quote.find({})
            .populate('_user')
            .exec(function(err, quotes){
                res.json(quotes)
            })
        },
        showAuthor:function(req, res){
            Quote.find({author: req.body.author}, function(err, data){
                // console.log(data)
                res.json(data)
            })
        },
        likeQuote: function(req,res){
            // Quote.findOne({_id:req.params.id},function(err,data){
            //     var index = data.likes.indexOf(req.session.user._id)
            //     if(index < 0){
            //         data.likes.push(req.session.user._id);
            //         Quote.findByIdAndUpdate(req.params.id, { $addToSet: { likes:req.session.user._id}}, function(err, quote){ 
            //             console.log("like count" + data)
            //             res.json(data);
            //         })
            //     }else {
            //         data.likes.splice(index, 1);
            //         Quote.findByIdAndUpdate(req.params.id, {$pull: {likes: req.session.user._id } }, function(err, quote){
            //             console.log("like count" + data)
            //             res.json(data)
            //         })
            //     }
            // })
            Quote.findById({_id: req.body._id}, function(err, quote){
                quote.likes += 1;
                quote.save(function(err){
                    res.json(quote)
                    // console.log(quote)
                })
            })
        }
    }
})()

