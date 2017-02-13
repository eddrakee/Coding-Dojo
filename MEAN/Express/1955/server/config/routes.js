console.log('routes is working!')

var births = require('./../controllers/births.js')

module.exports = function(app){
    app.get('/', function(req, res){
        console.log('hi')
        births.index(req, res);
    });

    app.get('/new/:name/', function(req, res){
        births.new(req, res);
    });

    app.get('/remove/:id/', function(req, res){
        births.delete(req,res);
    });

    app.get('/:name', function(req, res){
        births.findName(req,res);
    });
}
