var express = require('express')
var app = express()
var bodyParser = require('body-parser')
var path = require('path')
var session = require('express-session')
app.use(express.static(path.join(__dirname, 'client')))
app.use(express.static(path.join(__dirname, 'node_modules')))
app.use(bodyParser.json())
app.use(session({
  secret: 'flowerpower',
  resave: false,
  saveUninitialized: true,
}))
require('./server/config/mongoose.js')
require('./server/config/routes.js')(app)
app.listen(8000,function(){
  console.log('lasdfadf');
})
