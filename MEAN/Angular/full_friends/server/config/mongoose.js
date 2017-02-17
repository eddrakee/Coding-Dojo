var mongoose = require('mongoose');
var fs = require('fs');
var path = require('path');
var models_path = path.join(__dirname, '../models');

// make sure to change the name of the db as needed
mongoose.connect('mongodb://localhost/friends_db');
fs.readdirSync(models_path).forEach(function(file){
    if (file.indexOf('.js') >= 0){
        require(models_path + '/' + file);
    }
});