(function (app) {
    app.controller('rootController', rootController);

    rootController.$inject = ['$state', 'authData', 'loginService', '$scope', 'authenticationService','$window', 'apiService','$location'];

    function rootController($state, authData, loginService, $scope, authenticationService,$window, apiService, $location) {
        $scope.logOut = function () {
            debugger;
            loginService.logOut();
            $window.location.href = '/admin';
            $window.reload();
        }
        $scope.authentication = authData.authenticationData;

        //authenticationService.validateRequest();
    }
})(angular.module('bionet'));