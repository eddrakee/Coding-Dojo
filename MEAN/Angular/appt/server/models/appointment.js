var mongoose = require('mongoose')
var Schema = mongoose.Schema
var ApptSchema = new Schema({
  task:{type:String, required:true},
  date:{type:String, required:true},
  time:{type:String, required:true},
  _createdBy:{type:Schema.Types.ObjectId, ref:"User"},
  

},{timestamps:true})
mongoose.model("Appt",ApptSchema)
