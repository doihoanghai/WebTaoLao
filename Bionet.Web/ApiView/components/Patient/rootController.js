(function (app) {
    app.controller('rootController', rootController);

    rootController.$inject = ['$state', 'authData', 'loginService', '$scope', 'authenticationService', 'apiService'];

    function rootController($state, authData, loginService, $scope, authenticationService, apiService) {
        $scope.logOut = function () {
            apiService.get('/api/patient/logout', null, function (response) {
                loginService.logOut();
                $state.go('login');
            }, null);
        }
        $scope.authentication = authData.authenticationData;

        //authenticationService.validateRequest();
    }
})(angular.module('bionet'));