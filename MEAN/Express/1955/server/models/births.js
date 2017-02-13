var mongoose = require('mongoose');
var Schema = mongoose.Schema;
var BirthSchema = new Schema({
    name: {type: String, required:true, minlength:1},
    
}, {timestamps:true});

mongoose.model('Birth', BirthSchema);