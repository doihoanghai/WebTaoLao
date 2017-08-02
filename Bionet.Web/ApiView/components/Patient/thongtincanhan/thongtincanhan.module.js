(function () {
    angular.module('bionet.thongtincanhan', ['bionet.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('thongtincanhan', {
                url: "/thongtincanhan",
                parent: 'patient',
                templateUrl: "/ApiView/components/Patient/thongtincanhan/thongtincanhanView.html",
                controller: "thongtincanhanController"
            })
    }
})();