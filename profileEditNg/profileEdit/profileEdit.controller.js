(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('profileEditController', ProfileEditController);
    ProfileEditController.$inject = ['$scope'
        , '$baseController'
        , 'peopleService'
        , '$filter'];
    function ProfileEditController($scope
        , $baseController
        , peopleService
        , $filter) {
        var vm = this;
        vm.$scope = $scope;
        vm.person = null;
        vm.personId = null;
        vm.render = _render;
        vm.peopleService = peopleService;

        $baseController.merge(vm.$baseController);
        vm.notify = vm.peopleService.getNotifier($scope);

        function _submit(isValid) {
            _formatForm(vm.person);
            vm.peopleService.editPerson(vm.item.id, vm.item, _onSuccessUpdatePersonInfo, _onErrorUpdatePersonInfo);
        }
        function _render() {
            vm.peopleService.getPersonById(vm.personId, _onSuccessGetPerson, _onError);
        }
        function _onSuccessGetPerson(data, xhr, status) {
            vm.notify(function () {
                vm.person = data.item;
                _formatPersonInfo(vm.person);
            });
        };
        function _formatPersonInfo(data) {
            if (data.keyName) {
                vm.profilePicture = _createUrl(data.keyName);
            }
            else {
                vm.profilePicture = "http://budhubz.com/wp-content/themes/budhubs/images/noavatar.png";
            };
            if (data.preferredLanguages) {
                data.preferredLanguages = data.languages.split(',')
            };
            for (var i in vm.person.roles) {
                vm.person.roles[i] = vm.person.roles[i].id;
            };
            data.birthday = _formatDate(data.birthday);

            if (data.logoFileKey) {
                vm.logoUrl = _createUrl(data.logFileKey);
            };
        };
        function _onError(jqXHR) {
            vm.$alertService.error('Error Updating');
            console.error(jqXHR);
        };
        function _formatDate(date) {
            return $filter('date')(new Date(date), 'MM/dd/yyyy');
        };
        function _createUrl(keyname) {
            var url = "https://" + sabio.page.bucket + "." + sabio.page.baseUrl + "/" + sabio.page.folder + "/" + keyname;
            return url;
        };

    };
})();
