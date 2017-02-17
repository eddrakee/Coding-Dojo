var mongoose = require('mongoose');
var path = require('path');
var fs = require('fs');
var models_path = path.join(__dirname + './../models');

// connect to db and create a db!
// db is now named login_demo
mongoose.connect('mongodb://localhost/login_demo');

fs.readdirSync(models_path).forEach(function(file){
    if(file.indexOf('.js') >= 0){
        require(models_path + '/' + file);
    }
})