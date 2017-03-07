var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var QuestionSchema = new Schema({
    topic: { type: String, required: true },
    description: { type: String, required: true },
    num_answers: { type: Number, default: 0 },
    _user: { type: Schema.Types.ObjectId, ref: "User" },
    _answers: [{ type: Schema.Types.ObjectId, ref: 'Answer' }]
}, { timestamps: true })

mongoose.model('Question', QuestionSchema)
