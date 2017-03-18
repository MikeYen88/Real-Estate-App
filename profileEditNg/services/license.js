(function () {
    "use strict";
    angular.module(APPNAME)
        .factory('licenseService', LicenseServiceFactory);
    function LicenseServiceFactory($http) {
        return {
            grabLicenseData: function (license, onSuccess, onError) {
                return $http.get('/api/licenses/' + license)
                    .then(onSuccess, onError);
            }
        };
    };
})();