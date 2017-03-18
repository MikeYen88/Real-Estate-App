(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('passwordEditController', PasswordEditController);
    PasswordEditController.$inject = ['$scope', '$baseController', 'userService','$sabio'];

    function PasswordEditController($scope, $baseController, userService, $sabio) {
        var vm = this;
        vm.$scope = $scope;
        vm.pwInfo = {};
        vm.pwValidation = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{6,}$/;
        vm.userService = userService;
        vm.render = _render;

        vm.changePassword = _changePassword;

        $baseController.merge(vm, $baseController);
        vm.notify = vm.userService.getNotifier($scope);



        function _changePassword() {
            vm.userService.changePassword(vm.pwInfo, _onSuccessChangePassword, _onErrorChangePassword);
        };

        function _onSuccessChangePassword(data, xhr, status) {
            vm.notify(function () {
                vm.$alertService.success('Password Successfully Updated');
            });
        };

        function _onErrorChangePassword(jqXHR) {
            console.error(jqXHR);
            vm.$alertService('Password has not been changed');
        }
    }
})();