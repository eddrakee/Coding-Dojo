var mongoose = require('mongoose');
var Schema = mongoose.Schema;
var UserSchema = new Schema({
  name:String,
  // one user can create many items. They can also join many items
  _created:[{type: Schema.Types.ObjectId, ref:'Item'}],
  _joined:[{type: Schema.Types.ObjectId, ref:'Item'}]
})
mongoose.model('User', UserSchema)
