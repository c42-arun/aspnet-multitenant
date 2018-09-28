var billGatesBirthday = '10-28-1955';
var gatesAge = function() {
    return (new Date() - new Date(billGatesBirthday));
};

document.getElementsByTagName('body')[0].onload = function() {
    document.body.innerHTML = 'Bill Gates Current Age is: <b>' + gatesAge() + '</b>';
};