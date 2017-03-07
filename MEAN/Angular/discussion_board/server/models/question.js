var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var QuestionSchema = new Schema({
    topic:{type:String, required:true},
    description: {type:String, required:true},
    category:{type:String, required:true},
    _user: {type:Schema.Types.ObjectId, ref:"User"},
    _comments:[{type:Schema.Types.ObjectId, ref: "Comment"}]
}, {timestamps:true})

mongoose.model('Question', QuestionSchema)
