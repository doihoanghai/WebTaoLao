(function () {
    angular.module('bionet.phieusangloc', ['bionet.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('phieusangloc', {
                url: "/phieusangloc",
                parent: 'base',
                templateUrl: "/ApiView/components/phieusangloc/phieusanglocListView.html",
                controller: "phieusanglocListController"
            }).state('phieusangloc_add', {
                url: "/phieusangloc_add",
                parent: 'base',
                templateUrl: "/ApiView/components/phieusangloc/phieusanglocAddView.html",
                controller: "phieusanglocAddController"
            }).state('phieusangloc_edit', {
                url: "/phieusangloc_edit/:id",
                parent: 'base',
                templateUrl: "/ApiView/components/phieusangloc/phieusanglocEditView.html",
                controller: "phieusanglocEditController"
            });
    }
})();