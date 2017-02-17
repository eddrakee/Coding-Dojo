var mongoose = require('mongoose');
var User = mongoose.model('User');

module.exports = (function(){
    return {
        login: function(req, res){
            res.send('be_controller.session.login')
        }
    }
})()
// immediate function!
