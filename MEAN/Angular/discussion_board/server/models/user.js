var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var UserSchema = new Schema({
    name:{type:String, required:true},
    _questions:[{type:Schema.Types.ObjectId, ref:'Question'}],
    _comments:[{type:Schema.Types.ObjectId, ref:'Comment'}]
    }, {timestamps: true})

mongoose.model('User', UserSchema); 