(function (app) {
    'use strict';

    app.controller('applicationUserEditController', applicationUserEditController);

    applicationUserEditController.$inject = ['$scope', 'apiService', 'notificationService', '$location', '$stateParams', '$filter'];

    function applicationUserEditController($scope, apiService, notificationService, $location, $stateParams, $filter) {
        $scope.account = {}
        $scope.GetLevelCode = GetLevelCode;
        $scope.updateAccount = updateAccount;

        function updateAccount() {
            apiService.put('/api/applicationUser/update', $scope.account, addSuccessed, addFailed);
        }
        function loadDetail() {
            apiService.get('/api/applicationUser/detail/' + $stateParams.id, null,
            function (result) {
                $scope.account = result.data;
                GetLevelCode();
            },
            function (result) {
                notificationService.displayError(result.data);
            });
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.account.FullName + ' đã được cập nhật thành công.');

            $location.url('application_users');
        }
        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }

        function GetLevelCode() {
            if ($scope.account.UserLevel == 3) {
                apiService.get('api/donvicoso/getallDonVi', null, function (result) {
                    var str = JSON.stringify(result.data);
                    str = str.replace(/MaDVCS/g, 'code');
                    str = str.replace(/TenDVCS/g, 'name');
                    $scope.items = JSON.parse(str);
                });
            }
            else if ($scope.account.UserLevel == 2) {
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
            else {
                $scope.items = null;
            }
        }

        loadDetail();
    }
})(angular.module('bionet.application_users'));
