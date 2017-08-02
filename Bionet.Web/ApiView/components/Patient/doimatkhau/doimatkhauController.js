(function (app) {
    app.controller('doimatkhauController', doimatkhauController);

    doimatkhauController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', '$filter'];

    function doimatkhauController(apiService, $scope, notificationService, $state, $stateParams, $filter) {

        $scope.UpdatechangePass = UpdatechangePass;

        function UpdatechangePass() {
            $scope.account.Username = $scope.authentication.userName;
            apiService.put('api/applicationUser/changepassword', $scope.account, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess('Thay đổi mật khẩu thành công.');
            $state.go('patient');
        }
        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }

    }

})(angular.module('bionet.doimatkhau'));