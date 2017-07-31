
(function () {
    angular.module('bionet.trungtamsangloc', ['bionet.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('trungtamsangloc', {
                url: "/trungtamsangloc",
                parent: 'base',
                templateUrl: "/ApiView/components/trungtam/trungtamsanglocListView.html",
                controller: "trungtamsanglocListController"
            }).state('trungtamsangloc_add', {
                url: "/trungtamsangloc_add",
                parent: 'base',
                templateUrl: "/ApiView/components/trungtam/trungtamsanglocAddView.html",
                controller: "trungtamsanglocAddController"
            }).state('trungtamsangloc_edit', {
                url: "/trungtamsangloc_edit/:id",
                parent: 'base', 
                templateUrl: "/ApiView/components/trungtam/trungtamsanglocEditView.html",
                controller: "trungtamsanglocEditController"
            });
    }
})();