var mongoose = require('mongoose')
var Schema = mongoose.Schema
var UserSchema = new Schema ({
  name:{type:String, required:true},
  _created:[{type:Schema.Types.ObjectId, ref:"Appt"}],
},{timestamps:true})
mongoose.model("User",UserSchema)
