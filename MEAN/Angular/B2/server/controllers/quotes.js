var mongoose = require('mongoose')
var Quote = mongoose.model('Quote')
var User = mongoose.model("User")
module.exports = (function(){
    return{
        addQuote:function(req,res){
            var quote = new Quote({content:req.body.content, author: req.body.author, status:true , title:req.body.title, _user:req.body._id})
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
            Quote.findById({_id: req.body._id}, function(err, quote){
                quote.likes += 1;
                quote.save(function(err){
                    res.json(quote)
                    // console.log(quote)
                })
            })
        },
        changeStat: function(req, res){
            Quote.findById({_id:req.body._id}, function( err, quote){
                if(err){
                    alert("Something went wrong!")
                }else{
                    if(quote.status == true){
                        quote.status = false;
                        quote.save(function(err){
                            res.json(quote)
                        })
                    }else{
                        if(quote.status == false){
                            quote.status = true;
                            quote.save(function(err){
                                res.json(quote)
                            })
                        }
                    }
                }
            })
        }
    }
})()

