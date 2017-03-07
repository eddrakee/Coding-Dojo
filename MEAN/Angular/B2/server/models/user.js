var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var UserSchema = new Schema({
    name:{type:String, required:true},
    _quotes:[{type:Schema.Types.ObjectId, ref:"Quote"}],
}, {timestamps: true})

mongoose.model('User', UserSchema);