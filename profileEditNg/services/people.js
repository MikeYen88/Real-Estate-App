(function () {
    "use strict";
    angular.module(APPNAME)
        .factory('peopleService', PeopleServiceFactory);
    PeopleServiceFactory.$inject = ['$baseService', '$sabio']
    function PeopleServiceFactory($baseService, $sabio) {
        var aSabioServiceObject = sabio.services.person;
        var newService = $baseService.merge(true, {}, aSabioServiceObject, $baseService)
        console.log('person service', aSabioServiceObject);

        return newService;
    }
})();