(function (app) {
    'use strict';

    app.controller('applicationUserAddController', applicationUserAddController);

    applicationUserAddController.$inject = ['$scope', 'apiService', 'notificationService', '$location', 'commonService', '$sce'];

    function applicationUserAddController($scope, apiService, notificationService, $location, commonService, $sce) {
        $scope.account = {
            Groups: []
        }
        $scope.GetLevelCode = GetLevelCode;
        $scope.addAccount = addAccount;

        function addAccount() {
            debugger;
            apiService.post('/api/applicationUser/add', $scope.account, addSuccessed, addFailed);
        }

        function addSuccessed() {
            
            notificationService.displaySuccess($scope.account.Name + ' đã được thêm mới.');

            $location.url('application_users');
        }
        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }

        function GetLevelCode() {
            if ($scope.account.UserLevel == 3)
            {
                apiService.get('api/donvicoso/getallDonVi', null, function (result) {
                    var str = JSON.stringify(result.data);
                    str = str.replace(/MaDVCS/g, 'code');
                    str = str.replace(/TenDVCS/g, 'name');
                    $scope.items = JSON.parse(str);
                });
            }
            else if ($scope.account.UserLevel == 2)
            {
                apiService.get('api/chicuc/getallChiCuc', null, function (result) {
                    var str = JSON.stringify(result.data);
                    str = str.replace(/MaChiCuc/g, 'code');
                    str = str.replace(/TenChiCuc/g, 'name');
                    $scope.items = JSON.parse(str);
                });
            }
            else if ($scope.account.UserLevel == 1) {
                apiService.get('api/trungtamsangloc/getallTrungTam', null, function (result) {
                    var str = JSON.stringify(result.data);
                    str = str.replace(/MaTTSL/g, 'code');
                    str = str.replace(/TenTTSL/g, 'name');
                    $scope.items = JSON.parse(str);
                });
            }
            else if ($scope.account.UserLevel == 0)
            {
                $scope.account.LevelCode = "1";
            }
            else {
                $scope.items = null;
            }
        }

        function CheckAuthen() {
            apiService.get('api/applicationUser/checkauthencreate',
                function (result) {
                    $state.go('add_application_user');
                }, function () {
                });
        }

        CheckAuthen();

    }
})(angular.module('bionet.application_users'));
