(function (app) {
    app.controller('loginController', ['$http','$q','$scope', 'loginService', '$injector', 'notificationService', '$location','apiService','authData',
    function ($http,$q, $scope, loginService, $injector, notificationService, $location, apiService,authData) {

            $scope.loginData = {
                userName: "",
                password: ""
            };

            $scope.loginSubmit = function () {
                loginService.login($scope.loginData.userName, $scope.loginData.password).then(function (response) {
                    if (response != null && response.data.error != undefined) {
                        notificationService.displayError("Đăng nhập không đúng.");
                    }
                    else {
                        var stateService = $injector.get('$state');
                        var leveluser;

                        var url = apiService.apihost + 'api/account/detail/' + $scope.loginData.userName;
                        $http.get(url).then(function (response) {
                            debugger;
                            authData.authenticationData.fullName = response.data.FullName;
                            leveluser = response.data.UserLevel;
                            if (leveluser != 0)
                                $location.path('/admin');
                            else
                                $location.path('/patient');
                         
                            });
                       
                    }
                });
            }
        }]);
})(angular.module('bionet'));