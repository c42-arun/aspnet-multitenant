(function(){function r(e,n,t){function o(i,f){if(!n[i]){if(!e[i]){var c="function"==typeof require&&require;if(!f&&c)return c(i,!0);if(u)return u(i,!0);var a=new Error("Cannot find module '"+i+"'");throw a.code="MODULE_NOT_FOUND",a}var p=n[i]={exports:{}};e[i][0].call(p.exports,function(r){var n=e[i][1][r];return o(n||r)},p,p.exports,r,e,n,t)}return n[i].exports}for(var u="function"==typeof require&&require,i=0;i<t.length;i++)o(t[i]);return o}return r})()({1:[function(require,module,exports){
var billGatesBirthday = '10-28-1955';

exports.gatesAge = function() {
    return (new Date() - new Date(billGatesBirthday)) / 1000 / 60/ 60 / 24  / 365.25
};


exports.gatesAgeOnDate = function(date1) {
    return (new Date(date1) - new Date(billGatesBirthday)) / 1000 / 60/ 60 / 24 / 365.25
};
},{}],2:[function(require,module,exports){
var calcAge = require('./calcAge.js');

document.getElementsByTagName('body')[0].onload = function() {
    document.body.innerHTML = 'The answer is:' + calcAge.gatesAge();
};
},{"./calcAge.js":1}]},{},[2]);
