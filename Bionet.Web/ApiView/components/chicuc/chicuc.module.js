
(function () {
    angular.module('bionet.chicuc', ['bionet.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('chicuc', {
                url: "/chicuc",
                parent: 'base',
                templateUrl: "/ApiView/components/chicuc/chicucListView.html",
                controller: "chicucListController"
            }).state('chicuc_add', {
                url: "/chicuc_add",
                parent: 'base',
                templateUrl: "/ApiView/components/chicuc/chicucAddView.html",
                controller: "chicucAddController"
            }).state('chicuc_edit', {
                url: "/chicuc_edit/:id",
                parent: 'base', 
                templateUrl: "/ApiView/components/chicuc/chicucEditView.html",
                controller: "chicucEditController"
            });
    }
})();