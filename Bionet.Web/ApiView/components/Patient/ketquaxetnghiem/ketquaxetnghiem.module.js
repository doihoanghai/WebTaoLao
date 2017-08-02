(function () {
    angular.module('bionet.ketquaxetnghiem', ['bionet.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('ketquaxetnghiem', {
                url: "/ketquaxetnghiem",
                parent: 'patient',
                templateUrl: "/ApiView/components/Patient/ketquaxetnghiem/ketquaxetnghiemView.html",
                controller: "ketquaxetnghiemController"
            })
    }
})();