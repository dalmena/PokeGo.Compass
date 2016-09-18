angular.module('healthyGulpAngularApp')

.directive('demoComponent', [function() {
    return {
        controller: ['$scope',function ($scope) { $scope.test = "aiai"; }],
            restrict: 'A',
            templateUrl: 'components/demoComponent/demoComponent.html'
        };
    }]);