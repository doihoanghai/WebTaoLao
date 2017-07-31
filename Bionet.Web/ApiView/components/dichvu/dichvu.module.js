
(function () {
    angular.module('bionet.dichvu', ['bionet.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('dichvu', {
                url: "/dichvu",
                parent: 'base',
                templateUrl: "/ApiView/components/dichvu/dichvuListView.html",
                controller: "dichvuListController"
            }).state('dichvu_add', {
                url: "/dichvu_add",
                parent: 'base',
                templateUrl: "/ApiView/components/dichvu/dichvuAddView.html",
                controller: "dichvuAddController"
            }).state('dichvu_edit', {
                url: "/dichvu_edit/:id",
                parent: 'base',
                templateUrl: "/ApiView/components/dichvu/dichvuEditView.html",
                controller: "dichvuEditController"
            });
    }
})();