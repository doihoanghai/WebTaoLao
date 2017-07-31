/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('bionet',
        ['bionet.application_groups',
         'bionet.application_roles',
         'bionet.application_users',
         'bionet.dichvu',
         'bionet.thongsoxetnghiem',
         'bionet.trungtamsangloc',
         'bionet.chuongtrinh',
         'bionet.chicuc',
         'bionet.donvicoso',
         'bionet.phieusangloc',
         'bionet.danhgiachatluong',
         'bionet.account',
         'bionet.thongtinbenhnhan',
         'bionet.chitietgoidichvu',
         'bionet.goidichvuchung',
         'bionet.kythuatxetnghiem',
         'bionet.common'])

        .config(config)
        .config(configAuthentication);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '/ApiView/shared/views/baseView.html',
                abstract: true
            }).state('login', {
                url: "/login",
                templateUrl: "/ApiView/components/login/loginView.html",
                controller: "loginController"
            })
            .state('home', {
                url: "/admin",
                parent: 'base',
                templateUrl: "/ApiView/components/home/homeView.html",
                controller: "homeController"
            })
            .state('patient', {
                url: "/patient",
                templateUrl: '/ApiView/components/Patient/home/homeView.html',

            })
            .state('error', {
                url: "/error",
                parent: 'base',
                templateUrl: "/ApiView/components/home/errorAuthen.html",
                controller: "homeController"
            });
        $urlRouterProvider.otherwise('/login');
    }

    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location,$window) {
            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                        $window.location.reload(true);

                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status == "401") {
                        $location.path('/login');
                        $window.location.reload(true);

                    }
                    return $q.reject(rejection);
                }
            };
        });
       
    }
})();