(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('resourceEditController', ResourceEditController);
    ResourceEditController.$inject = ['$baseController', '$sabio', 'roleService', '$scope', 'peopleService'];

    function ResourceEditController($baseController, $sabio, roleService, $scope, peopleService) {
        var vm = this;
        vm.$scope = $scope;
        vm.roles = null;
        vm.roleService = roleService;
        vm.peopleService = peopleService;
        vm.render = _render;
        vm.personId = null;
        vm.serviceProvider = null;
        vm.submit = _submit;
        vm.isAgent = sabio.page.isAgent;
        vm.isBroker = sabio.page.isBroker;

        $baseController.merge(vm, $baseController);
        vm.notify = vm.roleService.getNotifier($scope);

        function _render() {
            vm.serviceProvider = JSON.parse(vm.person);
            console.log(vm.serviceProvider);
            //_formatServiceProvider(vm.serviceProvider);
            if (!vm.isAgent && !vm.isBroker) {
                vm.roleService.get(_onSuccessGetRoles, _onError);
            }
        };

        function _formatServiceProvider(data) {
            if (data.logoFileKey) {
                data.logoUrl = _createUrl(data.logoFileKey);
            };
            if (data.roles) {
                for (var i = 0; i < data.roles.length; i++) {
                    data.roles[i] = data.roles[i].id;
                }
            };
        };

        function _createUrl(keyname) {
            var url = "https://" + sabio.page.bucket + "." + sabio.page.baseUrl + "/" + sabio.page.folder + "/" + keyname;
            return url;
        };

        function _submit() {
            console.log(vm.serviceProvider);
            vm.peopleService.updateServiceProvider(vm.serviceProvider.id, vm.serviceProvider, _onSuccessUpdateServiceProvider, _onError);
            //vm.serviceProvider.id
            //vm.serviceProvider.roles;
            //vm.peopleService.updateServiceProvider(vm.personId, vm.serviceProvider, _onSuccessUpdateServiceProvider, _onError);
            //if (vm.logoUrl) {
            //    _upload("Logo");
            //};
        };

        function _onSuccessGetRoles(data, xhr, status) {
            vm.notify(function () {
                vm.roles = data.items;
            });
        };

        function _onError() {
            vm.$alertService('Error loading Service Provider Information');
        }
    }
})();