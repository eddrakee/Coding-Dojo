var mongoose = require('mongoose');
var Schema = mongoose.Schema;
var CommentSchema = new Schema({
    // where we put in the association. have to update user schema after doing this
    content: {type: String, required:true, minlength:2, maxlength:100},
    // User must match the user schema mongoose.model('User'...)
    _user: {type: Schema.Types.ObjectId, ref:'User'},
    _message: {type: Schema.Types.ObjectId, ref: 'Message'}
}, {timestamps:true})

mongoose.model('Comment', CommentSchema);