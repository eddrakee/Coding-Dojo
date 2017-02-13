var mongoose = require('mongoose');
var Schema = mongoose.Schema;
var FactSchema = new Schema({
    fact:{type: String, required: true, minlength:1},
}, {timestamps:true});

mongoose.model('Fact', FactSchema);