﻿(function (app) {
    app.controller('rootController', rootController);

    rootController.$inject = ['$state', 'authData', 'loginService', '$scope', 'authenticationService','$window', 'apiService','$location'];

    function rootController($state, authData, loginService, $scope, authenticationService,$window, apiService, $location) {
        $scope.logOut = function () {

            loginService.logOut();
            $window.location.href = '#';
            $window.location.reload();
        }
        debugger;
        
        $scope.authentication = authData.authenticationData;


        //authenticationService.validateRequest();
    }
})(angular.module('bionet'));