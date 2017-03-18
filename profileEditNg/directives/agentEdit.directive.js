(function () {
    "use strict";

    angular.module(APPNAME)
        .directive('agentEdit', AgentEditDirective);
    AgentEditDirective.$inject = ['$document'];

    function AgentEditDirective($document) {
        var baseDomain = $document[0].location.origin;
        var directive = {
            controller: 'agentEditController'
            , controllerAs: 'agentEdit'
            , bindToController: true
            , link: link
            , restrict: 'E'
            , templateUrl: baseDomain + '/scripts/app/personProfileEdit/agentEdit.html'
        };
        return directive;
    };
    function link(scope, element, attributes) {
        attributes.$observe('personId', function (value) {
            if (value) {
                scope.agentEdit.personId = value;
                scope.agentEdit.render();
            };
        });
    };
})();