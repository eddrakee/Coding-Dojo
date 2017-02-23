var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var UserSchema = new Schema({
	name: String,
	// give it messages to hook it up
	_messages:[{type:Schema.Types.ObjectId, ref:'Message'}],
	_comments:[{type: Schema.Types.ObjectId, ref:'Comment'}]
}, {timestamps:true})

mongoose.model('User', UserSchema);