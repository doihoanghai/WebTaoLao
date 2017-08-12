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

                        var url =  'api/account/detail/' + $scope.loginData.userName + "/?password="+$scope.loginData.password;
                        apiService.get(url,null,function (response) {
                             
                            authData.authenticationData.fullName = response.data.FullName;
                            authData.authenticationData.leveluser = response.data.UserLevel;
                            leveluser = response.data.UserLevel;
                            debugger;
                            if (leveluser != 4)
                                $location.path('/admin');
                            else
                                $location.path('/patient');
                         
                            });
                       
                    }
                });
            }
        }]);
})(angular.module('bionet'));