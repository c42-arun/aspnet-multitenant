var angular = require('angular');

var name = angular.module('MTApp', [
    require('./home') // 'home' is exported from 
]).name; 

module.exports = name;
