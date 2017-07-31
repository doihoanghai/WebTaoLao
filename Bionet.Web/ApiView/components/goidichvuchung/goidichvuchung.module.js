(function () {
    angular.module('bionet.goidichvuchung', ['bionet.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('goidichvuchung', {
                url: "/goidichvuchung",
                parent: 'base',
                templateUrl: "/ApiView/components/goidichvuchung/goidichvuchungListView.html",
                controller: "goidichvuchungListController"
            }).state('goidichvuchung_add', {
                url: "/goidichvuchung_add",
                parent: 'base',
                templateUrl: "/ApiView/components/goidichvuchung/goidichvuchungAddView.html",
                controller: "goidichvuchungAddController"
            }).state('goidichvuchung_edit', {
                url: "/goidichvuchung_edit/:id",
                parent: 'base',
                templateUrl: "/ApiView/components/goidichvuchung/goidichvuchungEditView.html",
                controller: "goidichvuchungEditController"
            });
    }
})();