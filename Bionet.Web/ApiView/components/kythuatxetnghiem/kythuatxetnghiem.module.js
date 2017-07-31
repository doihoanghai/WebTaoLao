(function () {
    angular.module('bionet.kythuatxetnghiem', ['bionet.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('kythuatxetnghiem', {
                url: "/kythuatxetnghiem",
                parent: 'base',
                templateUrl: "/ApiView/components/kythuatxetnghiem/kythuatxetnghiemListView.html",
                controller: "kythuatxetnghiemListController"
            }).state('kythuatxetnghiem_add', {
                url: "/kythuatxetnghiem_add",
                parent: 'base',
                templateUrl: "/ApiView/components/kythuatxetnghiem/kythuatxetnghiemAddView.html",
                controller: "kythuatxetnghiemAddController"
            }).state('kythuatxetnghiem_edit', {
                url: "/kythuatxetnghiem_edit/:id",
                parent: 'base',
                templateUrl: "/ApiView/components/kythuatxetnghiem/kythuatxetnghiemEditView.html",
                controller: "kythuatxetnghiemEditController"
            });
    }
})();