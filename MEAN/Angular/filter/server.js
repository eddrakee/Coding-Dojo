var express = require('express');
var app = express();
var bp = require('body-parser');
var path = require('path');

app.use(express.static(path.join(__dirname, './client')));
// if you used npm instead of bower, do this below
// app.use(express.static(path.join(__dirname, './node_modules')));

// for bower
app.use('/bower_components', express.static('./bower_components'));

app.use(bp.urlencoded());
app.listen(8000,function(){
    console.log('LISTENING!!!!')
});