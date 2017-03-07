var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var ItemSchema = new Schema({
    title: {type:String, required: true},
    description: {type:String, required: true},
    status: {type:String, default:'Pending'},
    _joinedBy:{type: Schema.Types.ObjectId, ref:'User'},
    _createdBy:{type: Schema.Types.ObjectId, ref:'User'},
}, {timestamps:true})

mongoose.model('Item', ItemSchema)