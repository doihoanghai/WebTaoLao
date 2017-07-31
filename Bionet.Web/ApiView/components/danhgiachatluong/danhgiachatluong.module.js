
(function () {
    angular.module('bionet.danhgiachatluong', ['bionet.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('danhgiachatluong', {
                url: "/danhgiachatluong",
                parent: 'base',
                templateUrl: "/ApiView/components/danhgiachatluong/danhgiachatluongListView.html",
                controller: "danhgiachatluongListController"
            }).state('danhgiachatluong_add', {
                url: "/danhgiachatluong_add",
                parent: 'base',
                templateUrl: "/ApiView/components/danhgiachatluong/danhgiachatluongAddView.html",
                controller: "danhgiachatluongAddController"
            }).state('danhgiachatluong_edit', {
                url: "/danhgiachatluong_edit/:id",
                parent: 'base',
                templateUrl: "/ApiView/components/danhgiachatluong/danhgiachatluongEditView.html",
                controller: "danhgiachatluongEditController"
            });
    }
})();