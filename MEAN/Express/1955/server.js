var express = require('express');
var app = express();
var bp = require('body-parser');
var path = require('path');
var port = 8000

app.use(bp.json()); 
app.use(express.static(path.join(__dirname, '/client/static')));
app.use(bp.urlencoded());
app.set('views', path.join(__dirname, './client/views'));

require('./server/config/mongoose.js');

require('./server/config/routes.js')(app);
// you have to wait to put app in until you set up your routes with module.exports

app.listen(8000, function(){
    console.log(`listening on port ${port}`);
})
