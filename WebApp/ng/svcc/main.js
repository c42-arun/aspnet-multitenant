var calcAge = require('./calcAge.js');

document.getElementsByTagName('body')[0].onload = function() {
    document.body.innerHTML = 'The answer is:' + calcAge.gatesAge();
};