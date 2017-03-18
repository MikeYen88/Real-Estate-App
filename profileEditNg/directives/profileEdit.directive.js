(function () {
    "use strict";

    angular.module(APPNAME)
        .directive('profileEdit', ProfileEditDirective);
    ProfileEditDirective.$inject = ['$document'];

    function ProfileEditDirective($document) {
        var baseDomain = $document[0].location.origin;

        var directive = {
            controller: 'profileEditController'
            , controllerAs: 'profileEdit'
            , bindToController: true
            , link: link
            , restrict: 'E'
            , templateUrl: baseDomain + '/scripts/app/personProfileEdit/profileEdit.html'
        };
        return directive;
    };
    function link(scope, element, attributes) {
        attributes.$observe('personId', function (value) {
            if (value) {
                scope.profileEdit.personId = value;
                scope.profileEdit.render();
            }
        })
    }
})();