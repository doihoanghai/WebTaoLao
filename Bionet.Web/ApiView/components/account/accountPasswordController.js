(function (app) {
    app.controller('accountPasswordController', accountPasswordController);

    accountPasswordController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', '$filter'];

    function accountPasswordController(apiService, $scope, notificationService, $state, $stateParams, $filter) {

        $scope.UpdatechangePass = UpdatechangePass;

        function UpdatechangePass() {
            $scope.account.Username = $scope.authentication.userName;
            apiService.put('api/applicationUser/changepassword', $scope.account, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess('Thay đổi mật khẩu thành công.');
            $state.go('home');
        }
        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }

    }

})(angular.module('bionet.account'));