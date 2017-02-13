var express = require('express');
var app = express();
var path = require('path');
var bp = require('body-parser');

app.use(express.static(path.join(__dirname, './client/static')));
app.use(bp.urlencoded({extended:true}));
app.set('views', path.join(__dirname, './client/views'));
app.set('view engine', 'ejs');

// mongoose will go here

require('./server/config/routes.js')(app);

app.listen(8000,function(){
    console.log('running on 8000')
})