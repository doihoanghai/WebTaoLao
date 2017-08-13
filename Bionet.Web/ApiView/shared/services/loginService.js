(function (app) {
    'use strict';
    app.service('loginService', ['$http', '$q', 'authenticationService', 'authData', 'apiService', '$injector',
    function ($http, $q, authenticationService, authData, apiService, $injector) {
        var userInfo;
        var deferred;

        this.login = function (userName, password) {
            debugger;

            deferred = $q.defer();
            var data = "grant_type=password&username=" + userName + "&password=" + password;
            $http.post(apiService.apihost +'oauth/token', data, {
                headers:
                   { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).then(function (response) {
                var now = new Date();
                debugger;
                now.setSeconds(now.getSeconds() + response.data.expires_in);
                userInfo = {
                    accessToken: response.data.access_token,
                    userName: userName,
                    fullName: decodeURIComponent(escape(response.headers().fullName)),
                    timeToken: now
                };
                debugger;

                authenticationService.setTokenInfo(userInfo);
                authData.authenticationData = userInfo;
                deferred.resolve(null);
            }, function (err, status) {
                debugger;

                authData.authenticationData.IsAuthenticated = false;
                authData.authenticationData.userName = "";
                authData.authenticationData.fullName = "";
                authData.authenticationData.timeToken = null;

                deferred.resolve(err);
            })
            return deferred.promise;
        }

      

        this.logOut = function () {
            apiService.get('api/account/logout', null, function (result) {
                
                
            },
            function(){
                null
            }
            );
            debugger;
            userInfo.accessToken = null;
            authData.authenticationData.IsAuthenticated = false;
            authData.authenticationData.userName = "";
            authData.authenticationData.accessToken = "";
            authData.authenticationData.fullName = "";
            authData.authenticationData.timeToken = null;
            authenticationService.removeToken();
            authenticationService.setTokenInfo(userInfo);

        }

    }]);
})(angular.module('bionet.common'));