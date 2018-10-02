var angular = require('angular');

angular.module('MTApp', []).controller('SVCCController', SVCCController);

function SVCCController ($scope) {
    $scope.sessions = [
        {title: 'Javascript', speaker: 'Crockford'},
        {title: 'C', speaker: 'Ritchie'},
        {title: 'Java', speaker: 'Gosling'},
        {title: 'C#', speaker: 'Hejlsberg'},
    ];
}

SVCCController.$inject = ['$scope'];