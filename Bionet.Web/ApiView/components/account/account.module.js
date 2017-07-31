/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('bionet.account', ['bionet.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('accountPassword', {
            url: "/accountPassword",
            templateUrl: "/ApiView/components/account/accountPasswordView.html",
            parent: 'base',
            controller: "accountPasswordController"
        });
    }
})();