(function () {
    angular.module('bionet.thongsoxetnghiem', ['bionet.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('thongsoxetnghiem', {
                url: "/thongsoxetnghiem",
                parent: 'base',
                templateUrl: "/ApiView/components/thongsoxetnghiem/thongsoxetnghiemListView.html",
                controller: "thongsoxetnghiemListController"
            }).state('thongsoxetnghiem_add', {
                url: "/thongsoxetnghiem_add",
                parent: 'base',
                templateUrl: "/ApiView/components/thongsoxetnghiem/thongsoxetnghiemAddView.html",
                controller: "thongsoxetnghiemAddController"
            }).state('thongsoxetnghiem_edit', {
                url: "/thongsoxetnghiem_edit/:id",
                parent: 'base',
                templateUrl: "/ApiView/components/thongsoxetnghiem/thongsoxetnghiemEditView.html",
                controller: "thongsoxetnghiemEditController"
            });
    }
})();