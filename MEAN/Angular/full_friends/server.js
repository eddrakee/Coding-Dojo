var express = require('express');
var app = express();
var bp = require('body-parser');
var path = require('path');

app.use(express.static(path.join(__dirname, './client')));
app.use(express.static(path.join(__dirname, './bower_components')));

app.use(bp.json());
app.listen(8000,function(){
    console.log('LISTENING!!!!')
});