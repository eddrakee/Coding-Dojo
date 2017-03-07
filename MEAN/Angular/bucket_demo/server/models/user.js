var mongoose = require('mongoose');
var Schema = mongoose.Schema;

// pass Schema an object
var UserSchema = new Schema({
    name: String,
})

mongoose.model('User', UserSchema)