(function () {
    "use strict";

    angular.module(APPNAME)
        .directive('passwordEdit', PasswordEditDirective);
    PasswordEditDirective.$inject = ['$document'];

    function PasswordEditDirective($document) {
        var baseDomain = $document[0].location.origin;
        var directive = {
            controller: 'passwordEditController'
            , controllerAs: 'passwordEdit'
            , bindToController: true
            , link: link
            , restrict: 'E'
            , templateUrl: baseDomain + '/scripts/app/personProfileEdit/passwordEdit.html'
        };
        return directive;
    };
    function link(scope, element, attributes) {
        attributes.$observe('email', function (value) {
            if (value) {
                scope.passwordEdit.pwInfo.email = value;
            }
        })
    }
})();