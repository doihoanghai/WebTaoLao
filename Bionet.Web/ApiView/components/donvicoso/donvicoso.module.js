(function () {
    angular.module('bionet.donvicoso', ['bionet.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('donvicoso', {
                url: "/donvicoso",
                parent: 'base',
                templateUrl: "/ApiView/components/donvicoso/donvicosoListView.html",
                controller: "donvicosoListController"
            }).state('donvicoso_add', {
                url: "/donvicoso_add",
                parent: 'base',
                templateUrl: "/ApiView/components/donvicoso/donvicosoAddView.html",
                controller: "donvicosoAddController"
            }).state('donvicoso_edit', {
                url: "/donvicoso_edit/:id",
                parent: 'base', 
                templateUrl: "/ApiView/components/donvicoso/donvicosoEditView.html",
                controller: "donvicosoEditController"
            });
    }
})();