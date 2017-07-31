﻿/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('bionet.application_users', ['bionet.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('application_users', {
            url: "/application_users",
            templateUrl: "/ApiView/components/application_users/applicationUserListView.html",
            parent: 'base',
            controller: "applicationUserListController"
        })
            .state('add_application_user', {
                url: "/add_application_user",
                parent: 'base',
                templateUrl: "/ApiView/components/application_users/applicationUserAddView.html",
                controller: "applicationUserAddController"
            })
            .state('edit_application_user', {
                url: "/edit_application_user/:id",
                templateUrl: "/ApiView/components/application_users/applicationUserEditView.html",
                controller: "applicationUserEditController",
                parent: 'base',
            })
            .state('role_application_user', {
                url: "/role_application_user/:id",
                templateUrl: "/ApiView/components/application_users/applicationUsersRoleView.html",
                controller: "applicationUsersRoleController",
                parent: 'base',
            });
    }
})();