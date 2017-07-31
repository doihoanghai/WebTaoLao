
(function () {
    angular.module('bionet.chuongtrinh', ['bionet.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('chuongtrinh', {
                url: "/chuongtrinh",
                parent: 'base',
                templateUrl: "/ApiView/components/chuongtrinh/chuongtrinhListView.html",
                controller: "chuongtrinhListController"
            }).state('chuongtrinh_add', {
                url: "/chuongtrinh_add",
                parent: 'base',
                templateUrl: "/ApiView/components/chuongtrinh/chuongtrinhAddView.html",
                controller: "chuongtrinhAddController"
            }).state('chuongtrinh_edit', {
                url: "/chuongtrinh_edit/:id",
                parent: 'base',
                templateUrl: "/ApiView/components/chuongtrinh/chuongtrinhEditView.html",
                controller: "chuongtrinhEditController"
            });
    }
})();