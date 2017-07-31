(function () {
    angular.module('bionet.thongtinbenhnhan', ['bionet.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('thongtinbenhnhan', {
                url: "/thongtinbenhnhan",
                parent: 'patient',
                templateUrl: "/ApiView/components/thongtinbenhnhan/thongtinbenhnhanView.html",
                controller: "thongtinbenhnhanController"
            })
    }
})();