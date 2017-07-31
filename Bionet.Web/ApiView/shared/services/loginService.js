(function (app) {
    'use strict';
    app.service('loginService', ['$http', '$q', 'authenticationService', 'authData', 'apiService', '$injector',
    function ($http, $q, authenticationService, authData, apiService, $injector) {
        var userInfo;
        var deferred;

        this.login = function (userName, password) {
            deferred = $q.defer();
            debugger;
            var data = "grant_type=password&username=" + userName + "&password=" + password;
            $http.post(apiService.apihost +'oauth/token', data, {
                headers:
                   { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).then(function (response) {
                var now = new Date();
              
                now.setSeconds(now.getSeconds() + response.data.expires_in);
                userInfo = {
                    accessToken: response.data.access_token,
                    userName: userName,
                    fullName: decodeURIComponent(escape(response.headers().fullName)),
                    timeToken: now
                };
                authenticationService.setTokenInfo(userInfo);
                authData.authenticationData.IsAuthenticated = true;
                authData.authenticationData.userName = userName;
                authData.authenticationData.fullname = userInfo.fullName;
                deferred.resolve(null);
            }, function (err, status) {
                authData.authenticationData.IsAuthenticated = false;
                authData.authenticationData.userName = "";
                authData.authenticationData.fullName = "";
                authData.authenticationData.timeToken = null;
                deferred.resolve(err);
            })
            return deferred.promise;
        }

      

        this.logOut = function () {
            $http.get(apiService.apihost +'api/account/logout').then( function (response) {
                debugger;
                userInfo.access_token = null;
                userInfo = null;
                authData.authenticationData.IsAuthenticated = false;
                authData.authenticationData.userName = "";
                authData.authenticationData.accessToken = "";
                authData.authenticationData.fullName = "";
                authData.authenticationData.timeToken = null;
                authenticationService.removeToken();
            },
            function(){
                null
            }
            );
            
        }

    }]);
})(angular.module('bionet.common'));