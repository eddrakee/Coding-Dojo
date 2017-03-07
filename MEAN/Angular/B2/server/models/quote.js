var mongoose = require('mongoose')
var Schema = mongoose.Schema
var QuoteSchema = new Schema({
    date:{type:Date, required:true},
    title:{type:String, required:true},
    status: {type:Boolean, default:true},
    author:{type:String, required:true},
    content:{type:String, required:true},
    likes: {type:Number, default:0},
    _user:{type:Schema.Types.ObjectId, ref:"User"},
},{timestamps:true})
mongoose.model("Quote",QuoteSchema)