(function (app) {
    'use strict';

    app.controller('applicationUsersRoleController', applicationUsersRoleController);

    applicationUsersRoleController.$inject = ['$scope', 'apiService', 'notificationService', '$location', '$stateParams', '$filter'];

    function applicationUsersRoleController($scope, apiService, notificationService, $location, $stateParams, $filter) {
        $scope.account = $stateParams.id;
        $scope.GetRole = GetRole;

        function loadGroup() {
            apiService.get('api/applicationGroup/getlistall', null, function (result) {
                $scope.group = result.data;
            }, function () {
                console.log('Cannot get list group');
            });
        }

        function loadRoleByUser() {
            apiService.get('api/applicationUser/getRoleByUser/' + $scope.account, null, function (result) {
                $scope.userRole = result.data;
            }, function () {
                console.log('Cannot get list group');
            });
        }

        function GetRole(id) {
            apiService.get('api/applicationRole/getlistbygroup/' + id[0], null, function (result) {
                $scope.roles = result.data;
            }, function () {
                console.log('Cannot get list roles');
            });
        }

        $scope.updateAccount = updateAccount;

        function updateAccount() {
            apiService.put('api/applicationUser/updateUserRole', $scope.userRole, addSuccessed, addFailed);
        }
        function addSuccessed() {
            notificationService.displaySuccess('Đã được cập nhật thành công.');
            loadRoleByUser();
            loadGroup();
        }
        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }

        loadRoleByUser();
        loadGroup();
 
    }
})(angular.module('bionet.application_users'));
