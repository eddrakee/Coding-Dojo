var mongoose = require('mongoose');
var Schema = mongoose.Schema;
var MessageSchema = new Schema({
    // where we put in the association. have to update user schema after doing this
    content: {type: String, required:true},
    // User must match the user schema mongoose.model('User'...)
    _user: {type: Schema.Types.ObjectId, ref:'User'}
})

mongoose.model('Message', MessageSchema)