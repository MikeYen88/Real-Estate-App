(function () {
    angular.module(APPNAME)
        .factory('uploadService', UploadServiceFactory);
    UploadServiceFactory.$inject = ['$baseService', '$sabio'];
    function UploadServiceFactory($baseService, $sabio) {
        var aSabioServiceObject = sabio.services.uploadFile;
        var newService = $baseService.merge(true, {}, aSabioServiceObject, $baseService);
        console.log('uploadService', aSabioServiceObject);
        return newService;
    }
})();