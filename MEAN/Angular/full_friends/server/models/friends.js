var mongoose = require('mongoose');
var Schema = mongoose.Schema;
var friendSchema = new Schema({
    first: {type:String, required: true,
        minlength:1},
    last: {type:String, required: true,
        minlength:1},
    bday: {type:Date, required: true},
})

// this is how we will reference this schema in our friends controller
mongoose.model('Friend', friendSchema);