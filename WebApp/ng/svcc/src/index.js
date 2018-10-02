var angular = require('angular');

var name = angular.module('MTApp', [
    require('./home')
]).name; 

module.exports = name;
