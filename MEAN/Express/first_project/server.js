// Load the express module
var express = require("express");

// invoke var express and store the resulting application in var app
// requiring "express" returns a "CreateApplication" function that we store in the express variable before invoking
var app = express();

// now we have created our express app!
// let's use it to handle requests below
// let's handle the base route "/" and respond with "Hello Express"
app.get('/', function(request, response) {
  response.render("index");
//   this will show the form in the index.ejs
// it has to be a response.render which takes our .ejs file and converts it to html and sends it back to the client
// response.send is not used as often since it just sends html to client without interpreting anything. we do not use it as much
})
// notice that the function is app.get(...) why do you think the function is called get?
// the express module has been loaded into our server file and has been invoked to create the server
// it has also created a route for the server to handle. All all we need to do is tell it to listen

// Tell the express app to listen on port 8000
app.listen(8000, function() {
  console.log("listening on port 8000");
})
// this line will almost always be at the end of your server.js file (we only tell the server to listen after we have set up all of our rules)

// this is the line that tells our server to use the "/static" folder for static content
app.use(express.static(__dirname + "/static"));
// note: you have to go to localhost:800/main.html to get here
// two underscores before dirname
// try printing out __dirname using console.log to see what it is and why we use it

// this will tell express that we are going to use EJS
// This sets the location where express will look for the ejs views
app.set('views', __dirname + '/views'); 
// Now lets set the view engine itself so that express knows that we are using ejs as opposed to another templating engine like jade
app.set('view engine', 'ejs');


// now let's say we want to adda route to our app taht displays a list of users. it will be hard coded for nowapp.get("/users", function (request, response){
// hard-coded user data
app.get("/users", function (request, response){
    // hard-coded user data
    var users_array = [
        {name: "Michael", email: "michael@codingdojo.com"}, 
        {name: "Jay", email: "jay@codingdojo.com"}, 
        {name: "Brendan", email: "brendan@codingdojo.com"}, 
        {name: "Andrew", email: "andrew@codingdojo.com"}
    ];
    response.render('users', {users: users_array});
})
// notice how we are passing a Javascript object to the response.render() method. This way when we pass a piece of data to a view, every key-value pair within the larger piece of data becomes its own variable

// require body-parser
var bodyParser = require('body-parser');
// use it!
app.use(bodyParser.urlencoded({extended: true}));

// route to process new user form data:
app.post('/users', function (req, res){
    console.log("POST DATA \n\n", req.body)
    //code to add user to db goes here!
    // redirect the user back to the root route.  
    res.redirect('/')
});

app.get("/users/:id", function (req, res){
    console.log("The user id requested is:", req.params.id);
    // just to illustrate that req.params is usable here:
    res.send("You requested the user with id: " + req.params.id);
    // code to get user from db goes here, etc...
});

// THE CODE BELOW IS FOR SESSION!!!
// new code:
var session = require('express-session');
// original code:
var app = express();
// more new code:
app.use(session({secret: 'codingdojorocks'}));  // string for encryption

