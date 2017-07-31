
(function () {
    angular.module('bionet.chitietgoidichvu', ['bionet.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('chitietgoidichvu', {
                url: "/chitietgoidichvu",
                parent: 'base',
                templateUrl: "/ApiView/components/chitietgoidichvu/chitietgoidichvuView.html",
                controller: "chitietgoidichvuController"
            });
    }
})();