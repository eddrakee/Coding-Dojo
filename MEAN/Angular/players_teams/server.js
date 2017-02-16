var 
    express  = require( 'express' ),
    bp       = require('body-parser'),
    path     = require( 'path' ),
    root     = __dirname,
    port     = process.env.PORT || 8000,
    app      = express();
    
app.use( express.static( path.join( root, 'client' )));
// since we made __dirname a variable, we just use root!
app.use( express.static( path.join( root, 'bower_components' )));
// this hooks up to our bower_components page
app.use(bp.json())
// this has changed from urlencoded!
app.listen( port, function() {
  console.log( `server running on port ${ port }` );
});
