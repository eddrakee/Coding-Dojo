var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var UserSchema = new Schema({
    first: {type: String, required:true, minlength:1},
    last: {type: String, required:true, minlength:1},
    bday: Date,
}, {timestamps:true});

mongoose.model('User', UserSchema);