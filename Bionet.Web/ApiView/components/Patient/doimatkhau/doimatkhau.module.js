(function () {
    angular.module('bionet.doimatkhau', ['bionet.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('doimatkhau', {
                url: "/doimatkhau",
                parent: 'patient',
                templateUrl: "/ApiView/components/Patient/doimatkhau/doimatkhauView.html",
                controller: "doimatkhauController"
            })
    }
})();