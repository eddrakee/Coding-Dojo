module.exports = function(app){
    
    app.get('/', function(req, res){
        res.render('index');
    })

    app.post('/add', function(req, res){
        console.log('yo')
    })


}