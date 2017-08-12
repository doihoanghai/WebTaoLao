(function (app) {
    app.controller('homeController', homeController);

    homeController.$inject = ['authData','$scope', 'authenticationService'];

    function homeController(authData,$scope,authenticationService) {
        $scope.authentication = authData.authenticationData;

    }

})(angular.module('bionet'));