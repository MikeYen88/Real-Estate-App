(function () {
    "use strict";

    angular.module(APPNAME)
        .factory("roleService", RoleServiceFactory);
    RoleServiceFactory.$inject = ["$baseService", "$sabio"];

    function RoleServiceFactory($baseService, $sabio) {
        var aSabioServiceObject = sabio.services.roles;
        var newService = $baseService.merge(true, {}, aSabioServiceObject, $baseService);
        console.log('role service', aSabioServiceObject);
        return newService;
    };
})();