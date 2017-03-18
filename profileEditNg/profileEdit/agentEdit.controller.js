(function () {
    angular.module(APPNAME)
        .controller('agentEditController', AgentEditController);
    AgentEditController.$inject = ['$scope', '$baseController', 'peopleService', '$filter'];
    function AgentEditController($scope, $baseController, peopleService, $filter) {

        var vm = this;
        vm.$scope = $scope;
        vm.agentSettings = null;
        vm.render = _render;

        vm.peopleService = peopleService;
        $baseController.merge(vm, $baseController);
        vm.notify = vm.peopleService.getNotifier($scope);


        function _render() {
            vm.peopleService.getLicenseInfoById(vm.personId, _onSuccessGetAgentInfo, _onError);
        }

        function _onSuccessGetAgentInfo(data, xhr, status) {
            vm.notify(function () {
                vm.agentSettings = data.item;
                vm.agentSettings.expirationDate = _formatDate(vm.agentSettings.expirationDate);
            });
        }
        function _onError(jqXHR) {
            vm.$alertService.error('OOPS trouble loading');
        }

        function _formatDate(date) {
            return $filter('date')(new Date(date), 'MM/dd/yyyy');
        };

    }
})();
