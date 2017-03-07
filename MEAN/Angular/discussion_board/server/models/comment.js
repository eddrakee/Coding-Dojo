var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var CommentSchema = new Schema ({
    content:{type:String, required: true},
    _user: {type:Schema.Types.ObjectId, ref:'User'},
    _questions:{type:Schema.Types.ObjectId, ref:'Question'}
}, {timestamp:true})

mongoose.model('Comment', CommentSchema)