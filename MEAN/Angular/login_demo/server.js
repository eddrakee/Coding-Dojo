var express = require('express');
var app = express();
var bp = require('body-parser');
var path = require('path');
var port = 8000;

app.use(express.static(path.join(__dirname+ "/client")));
// using CDN so no connection to bower components
app.use(bp.json());
// when you put in your mongoose link, RUN MONGOD! You will have to restart your server
require('./server/config/mongoose.js')
require('./server/config/routes.js')(app)
app.listen(port, function(){
    console.log('LISTENING!');
});
