(function () {
    "use strict";

    angular.module(APPNAME)
        .directive('resourceEdit', ResourceEditDirective);
    ResourceEditDirective.$inject = ['$document'];

    function ResourceEditDirective($document) {
        var baseDomain = $document[0].location.origin;
        var directive = {
            controller: 'resourceEditController'
            , controllerAs: 'resourceEdit'
            , bindToController: true
            , link: link
            , restrict: 'E'
            , templateUrl: baseDomain + '/scripts/app/personProfileEdit/resourceEdit.html'
        };
        return directive;
    };
    function link(scope, element, attributes) {
        attributes.$observe('person', function (value) {
            if (value) {
                scope.resourceEdit.person = value;
                scope.resourceEdit.render();
            };
        });
    };
})();