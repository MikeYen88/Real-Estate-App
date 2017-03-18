(function () {
    "use strict";

    angular.module(APPNAME)
        .factory('officeService', OfficeServiceFactory);
    function OfficeServiceFactory($http) {
        var url = '/api/office';
        return {
            insert: function (data, onSuccess, onError) {
                return $http({
                    url: url
                    , method: "POST"
                    , data: data
                })
                    .then(onSuccess)
                    .catch(onError);
            },
            update: function (id, data, onSuccess, onError) {
                return $http.put('/api/office/' + id)
                    .then(onSuccess)
                    .catch(onError);
            },
            getByLicenseNumber: function (license, onSuccess, onError) {
                return $http.get('/api/office/' + license)
                    .then(onSuccess)
                    .catch(onError);
            }
        };
    };
})();