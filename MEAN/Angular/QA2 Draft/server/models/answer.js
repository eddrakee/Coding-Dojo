var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var AnswerSchema = new Schema({
    content: {type:String, required: true},
    description:{type:String},
    likes:{type:Number, default:0},
    _user: {type:Schema.Types.ObjectId, ref:'User'},
    _questions: {type:Schema.Types.ObjectId, ref:'Question'}
}, {timestamp:true})

mongoose.model('Answer', AnswerSchema)