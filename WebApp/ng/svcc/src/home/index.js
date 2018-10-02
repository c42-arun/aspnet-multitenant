module.exports = 
    require('angular')
        .module('home', [])
        .controller('SVCCController', require('./controller'))
        .name;

