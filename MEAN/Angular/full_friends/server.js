// 1 - Initial server set up:
// var express = require('express');
// var app = express();
// var bp = require('body-parser');
// var path = require('path');

// app.use(express.static(path.join(__dirname, './client')));
// app.use(express.static(path.join(__dirname, './bower_components')));

// app.use(bp.json());
// app.listen(8000,function(){
//     console.log('LISTENING!!!!')
// });

// 2 - after initiating mongoose and running Mongod server window
var express = require('express');
var app = express();
var bp = require('body-parser');
var path = require('path');
var mongoose = require('mongoose');

app.use(express.static(path.join(__dirname, './client')));
app.use(express.static(path.join(__dirname, './bower_components')));

app.use(bp.json());

require('./server/config/mongoose.js');
require('./server/config/routes.js')(app)
app.listen(8000,function(){
    console.log('LISTENING!!!!')
});

