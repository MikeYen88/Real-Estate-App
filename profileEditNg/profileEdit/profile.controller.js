(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('personController', PersonController);

    PersonController.$inject = ['$scope'
        , '$baseController'
        , 'peopleService'
        , '$location'
        , 'uploadService'
        , '$timeout'
        , 'Cropper'
        , 'toDosService'
        , 'userService'
        , '$filter'
        , 'roleService'
        , 'mlsCategoriesService'
        , 'licenseService'
        , 'officeService'
        , 'notificationService'];

    function PersonController(
        $scope
        , $baseController
        , peopleService
        , $location
        , uploadService
        , $timeout
        , Cropper
        , toDosService
        , userService
        , $filter
        , roleService
        , mlsCategoriesService
        , licenseService
        , officeService
        , notificationService) {

        var vm = this;
        vm.$scope = $scope;
        vm.item = null;
        vm.selectedPerson = null;
        vm.avatarTab = false;
        vm.caseCount = null;
        vm.pwForm = null;
        vm.notForm = null;
        vm.pwInfo = null;
        vm.dataUrl = null;
        vm.notif = {
            "caseInvite": {
                "emailNotif": false
                , "smsNotif": false
                , "notificationEventid": 3
            }
            , "newListingOnSavedSearch": {
                "emailNotif": false
                , "smsNotif": false
                , "notificationEventid": 4
            }
            , "notesAddedToListing": {
                "emailNotif": false
                , "smsNotif": false
                , "notificationEventid": 5
            }
            , "newMessage": {
                "emailNotif": false
                , "smsNotif": false
                , "notificationEventid": 6
            }
            , "expensesReminder": {
                "emailNotif": false
                , "smsNotif": false
                , "notificationEventid": 7
            }
            , "transactionParticipants": {
                "emailNotif": false
                , "smsNotif": false
                , "notificationEventid": 8
            }
            , "transactionDocuments": {
                "emailNotif": false
                , "smsNotif": false
                , "notificationEventid": 9
            }
            , "transactionDocumentReminders": {
                "emailNotif": false
                , "smsNotif": false
                , "notificationEventid": 10
            }
            , "transactionComments": {
                "emailNotif": false
                , "smsNotif": false
                , "notificationEventid": 11
            }
        };
        vm.pwValidation = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{6,}$/;
        vm.personId = sabio.page.currentPersonId;
        vm.profilePicture = null;
        vm.file = null;
        vm.data = null;
        vm.agentSettings = null;
        vm.roles = null;
        vm.mlsLookup = null;
        vm.office = {};
        vm.serviceProvider = {};
        vm.serviceProviderTab = false;
        vm.registerOfficeTab = false;
        vm.agent = {};
        vm.agentTab = false;
        vm.languages = [{
            "value": "English"
            , "name": "English"
        }, {
            "value": "Chinese"
            , "name": "Chinese"
        }, {
            "value": "Spanish"
            , "name": "Spanish"
        }, {
            "value": "Italian"
            , "name": "Italian"
        }, {
            "value": "Korean"
            , "name": "Korean"
        }, {
            "value": "Japanese"
            , "name": "Japanese"
        }];
        vm.isAgent = sabio.page.isAgent;
        vm.isBroker = sabio.page.isBroker;
        //ngcropper options
        vm.showEvent = 'show';
        vm.hideEvent = 'hide';
        vm.$scope.cropper = {};
        vm.cropperProxy = 'cropper.first';
        vm.options = {
            maximize: true,
            aspectRatio: 1 / 1,
            crop: function (dataNew) {
                vm.data = dataNew;
            }
        };

        vm.peopleService = peopleService;
        vm.userService = userService;
        vm.roleService = roleService;
        vm.notificationService = notificationService;
        vm.mlsCategoriesService = mlsCategoriesService;
        vm.licenseService = licenseService;
        vm.officeService = officeService;

        vm.uploadService = uploadService;
        vm.$location = window.location;
        vm.submit = _submit;
        vm.changePassword = _changePassword;
        vm.upload = _upload;
        vm.$scope.readBanner = _readBanner;
        vm.$scope.readLogo = _readLogo;
        vm.$scope.readProfile = _readProfile;
        vm.preview = _preview;
        vm.show = _show;


        $baseController.merge(vm, $baseController);
        vm.notify = vm.peopleService.getNotifier($scope);

        _render();

        function _render() {
            vm.peopleService.getPersonById(vm.personId, _onSuccessGetPerson, _onError);
            vm.mlsCategoriesService.selectLookup(_onSuccessGetMlsLookup, _onError);
            vm.notificationService.getPreferences(vm.personId, _onSuccessGetPreferences, _onError);

        };

        function _createUrl(keyname) {
            var url = "https://" + sabio.page.bucket + "." + sabio.page.baseUrl + "/" + sabio.page.folder + "/" + keyname;
            return url;
        };

        function _formatForm(data) {
            if (data.languages) {
                data.languages = data.preferredLanguages.join(',');
            };
            if (data.roles) {
                for (var i in data.oles) {
                    data.roles[i] = data.roles[i].id;
                };
            };
        };

        function _changePassword() {
            vm.pwInfo.email = vm.item.emailPublic;
            vm.userService.changePassword(vm.pwInfo, _onSuccessChangePassword, _onErrorChangePassword);
        };

        function _readBanner(blob) {
            Cropper.encode((vm.file = blob)).then(function (bannerUrl) {
                vm.bannerUrl = bannerUrl;
            });
        };

        function _readLogo(blob) {
            Cropper.encode((vm.file = blob)).then(function (logoUrl) {
                vm.logoUrl = logoUrl;
            });
        };

        function _clearPreviewDataUrls() {
            vm.dataUrl = null;
            vm.preview.dataUrl = null;
            vm.bannerUrl = null;
            vm.logoUrl = null;
        };

        function _show(text) {
            switch (text) {
                case 'serviceProvider':
                    vm.serviceProviderTab = true;
                    break;
                case 'registerOffice':
                    vm.registerOfficeTab = true;
                    break;
                case 'avatarTab':
                    vm.avatarTab = true;
                    break;
                case 'agentTab':
                    vm.agentTab = true;
            };
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
            if (data.roles) {
                for (var i = 0; i < data.roles.length; i++) {
                    vm.item.roles[i] = vm.item.roles[i].id;
                };
            }
            data.birthday = _formatDate(data.birthday);

            if (data.logoFileKey) {
                vm.logoUrl = _createUrl(data.logFileKey);
            };
        };

        function _formatDate(date) {
            return $filter('date')(new Date(date), 'MM/dd/yyyy');
        };

        function _submit(type, isValid) {
            if (isValid) {
                switch (type) {
                    case 'officeForm':
                        if (vm.agentSettings.registeredOffice) {
                            vm.officeService.update(id, vm.office, _onSuccessUpdateOffice, _onErrorUpdateOffice);
                        }
                        else {
                            vm.officeService.insert(vm.office, _onSuccessInsertOffice, _onErrorInsertOffice);
                        };
                        break;
                    case 'serviceProvider':
                        vm.serviceProvider.id = vm.personId;
                        vm.serviceProvider.roles = vm.item.roles;
                        vm.peopleService.updateServiceProvider(vm.personId, vm.serviceProvider, _onSuccessUpdateServiceProvider, _onError);
                        if (vm.logoUrl) {
                            _upload("Logo");
                        };
                        break;
                    case 'agentForm':
                        if (vm.isAgent) {
                            vm.agentSettings.licenseType = "SALESPERSON";
                        };
                        if (vm.isBroker) {
                            vm.agentSettings.licenseType = "BROKER";
                        };
                        console.log(vm.agentSettings);
                        vm.peopleService.updateAgentSettings(vm.personId, vm.agentSettings, _onSuccessUpdateAgent, _onErrorUpdateAgent);
                        if (vm.bannerUrl) {
                            _upload("Banner");
                        };
                        if (vm.logoUrl) {
                            _upload("Logo");
                        };
                        break;
                    case 'userForm':
                        _formatForm(vm.item);
                        vm.peopleService.editPerson(vm.item.id, vm.item, _onSuccessUpdatePersonInfo, _onErrorUpdatePersonInfo);
                        break;
                    case 'notForm':
                        console.log(vm.notif);
                        var data = {};
                        data.personId = vm.personId;
                        data.notificationEventList = [vm.notif.caseInvite
                            , vm.notif.newListingOnSavedSearch
                            , vm.notif.notesAddedToListing
                            , vm.notif.newMessage
                            , vm.notif.expensesReminder
                            , vm.notif.transactionParticipants
                            , vm.notif.transactionDocuments
                            , vm.notif.transactionDocumentReminders
                            , vm.notif.transactionComments];
                        vm.notificationService.updatePreferences(vm.personId, data, _onSuccessUpdatePref, _onError);
                }
            }
        };

        //file upload
        function _upload(type) {
            if (vm.serviceProvider.roles) {
                if (sabio.page.isAgent || sabio.page.isBroker || vm.serviceProvider.roles.length > 0) {
                    var data;
                    switch (type) {
                        case "Profile":
                            data = _blobToFormData(_resizeImage(vm.preview.dataUrl));
                            vm.uploadService.updateKey(vm.personId, type, data, _onSuccessUpload, _onError);
                            var newFd = _blobToFormData(vm.preview.dataUrl);
                            vm.uploadService.updateKey(vm.personId, "AgentProfile", newFd, _onSuccessUpload, _onError);
                            break;
                        case "Banner":
                            data = _blobToFormData(vm.bannerUrl);
                            vm.uploadService.updateKey(vm.personId, type, data, _onSuccessUpload, _onError);
                            break;
                        case "Logo":
                            data = _blobToFormData(vm.logoUrl);
                            vm.uploadService.updateKey(vm.personId, type, data, _onSuccessUpload, _onError);
                            break;
                    }
                }
            }
            else {
                var fd = _blobToFormData(_resizeImage(vm.preview.dataUrl));
                vm.uploadService.updateKey(vm.personId, type, fd, _onSuccessUpload, _onError);
            };
        };
        function _blobToFormData(data) {
            var blob = _dataURItoBlob(data);
            var fd = new FormData(vm.file);
            fd.append('file', blob, vm.file.name);
            return fd;
        };
        function _resizeImage(dataUrl) {
            "use strict";
            var image, oldWidth, oldHeight, newHeight, newWidth, canvas, ctx, newDataUrl, imageArguments, imageType;

            newWidth = 200;
            newHeight = 200;

            // Provide default values
            imageType = "image/jpeg";
            imageArguments = .7;

            // Create a temporary image so that we can compute the height of the downscaled image.
            image = new Image();
            image.src = dataUrl;
            oldWidth = image.width;
            oldHeight = image.height;

            // Create a temporary canvas to draw the downscaled image on.
            canvas = document.createElement("canvas");
            canvas.width = newWidth;
            canvas.height = newHeight;

            // Draw the downscaled image on the canvas and return the new data URL.
            ctx = canvas.getContext("2d");
            ctx.drawImage(image, 0, 0, newWidth, newHeight);
            newDataUrl = canvas.toDataURL(imageType, imageArguments);
            return newDataUrl;
        };
        function _dataURItoBlob(dataURI) {
            // convert base64 to raw binary data held in a string
            // doesn't handle URLEncoded DataURIs - see SO answer #6850276 for code that does this
            var byteString = atob(dataURI.split(',')[1]);

            // separate out the mime component
            var mimeString = dataURI.split(',')[0].split(':')[1].split(';')[0];

            // write the bytes of the string to an ArrayBuffer
            var ab = new ArrayBuffer(byteString.length);
            var ia = new Uint8Array(ab);
            for (var i = 0; i < byteString.length; i++) {
                ia[i] = byteString.charCodeAt(i);
            }
            return new Blob([ab], { type: mimeString });
        };

        //onSuccess functions
        function _onSuccessUpdatePersonInfo(data, xhr, status) {
            vm.notify(function () {
                vm.$alertService.success("Personal Info Updated");
            })
        }
        function _onSuccessChangePassword(xhr, status) {
            vm.notify(function () {
                vm.$alertService['success']('Password Changed Successfully');
            });
        };
        function _onSuccessUpdateAgent(data, xhr, status) {

            vm.$alertService.success("Setting Updated Successfully");
        };
        function _onSuccessGetPerson(data, xhr, status) {
            vm.notify(function () {
                vm.item = data.item;
                _formatPersonInfo(vm.item);
                if (vm.item.roles) {
                    vm.peopleService.getServiceProvider(vm.personId, _onSuccessGetServiceProvider, _onError);
                }
            });
        };
        //function _onSuccessGetLicenseInfo(data, xhr, status) {
        //    vm.notify(function () {
        //        vm.agentSettings = data.item;
        //        console.log(vm.agentSettings);
        //        if (vm.agentSettings.registeredOffice) {
        //            vm.officeService.getByLicenseNumber(vm.agentSettings.officeId, _onSuccessGetOfficeInfo, _onError);
        //        }
        //        else {
        //            vm.licenseService.grabLicenseData(vm.agentSettings.officeId, _onSuccessGetOfficeInfo, _onError);
        //        }
        //        if (vm.agentSettings.logoFileKey) {
        //            vm.agent.logoUrl = _createUrl(vm.agentSettings.logoFileKey);
        //        }
        //        vm.agentSettings.expirationDate = _formatDate(vm.agentSettings.expirationDate);
        //    });
        //};
        function _onSuccessUpload(data, xhr, status) {
            vm.notify(function () {
                _clearPreviewDataUrls();
                vm.$alertService['success']('File Uploaded Successfully');
                _render();
            });

        };
        //function _onSuccessGetRoles(data, xhr, status) {
        //    vm.notify(function () {
        //        vm.roles = data.items;
        //    });
        //};
        function _onSuccessGetMlsLookup(data, xhr, status) {
            vm.notify(function () {
                vm.mlsLookup = data.items;
            });
        };
        function _onSuccessGetOfficeInfo(object) {
            vm.office = object.data.item;
            vm.office.expirationDate = _formatDate(vm.office.expirationDate);
        };
        function _onSuccessGetServiceProvider(data, xhr, status) {
            vm.notify(function () {
                console.log(data.item);
            });
        };
        function _onSuccessUpdateServiceProvider(data, xhr, status) {
            vm.notify(function () {
                vm.$alertService.success('Business Information Submitted Successfully');
            });
        };
        function _onSuccessUpdatePref(data, xhr, status) {
            vm.$alertService.success('Notification Settings Updated');
        };
        function _onSuccessGetPreferences(data, xhr, stauts) {
            console.log(data);
        };

        //onError functions
        function _onErrorChangePassword(jqXHR) {
            vm.notify(function () {
                console.error(jqXHR.responseText);
                vm.$alertService['error']('Password has not been changed');
            });
        };
        function _onErrorUpdateAgent(jqXHR) {
            vm.notify(function () {
                console.error(jqXHR.responseText);
                vm.$alertService['error']('Agent Settings has not been changed');
            })
        };
        function _onError(jqXHR) {
            vm.$alertService.error('Error Updating');
            console.error(jqXHR);
        };
        function _onErrorUpdatePersonInfo(jxQHR) {
            vm.notify(function () {
                vm.$alertService.error("Profile was not updated succesfully");
            });
        };

        //ngCropper
        function _readProfile(blob) {
            Cropper.encode((vm.file = blob)).then(function (dataUrl) {
                vm.dataUrl = dataUrl;
                $timeout(_hideCropper);
                $timeout(_showCropper);  // wait for $digest to set image's src
            });
        };
        function _preview() {
            if (!vm.file || !vm.data) return;
            Cropper.crop(vm.file, vm.data).then(Cropper.encode).then(function (dataUrl) {
                (vm.preview || (vm.preview = {})).dataUrl = dataUrl;
            });
        };
        function _showCropper() {
            vm.$scope.$broadcast(vm.showEvent);
        }
        function _hideCropper() {
            vm.$scope.$broadcast(vm.hideEvent);
        }

    };
})();
