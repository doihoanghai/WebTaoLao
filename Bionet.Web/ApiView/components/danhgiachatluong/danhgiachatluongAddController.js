(function (app) {
    app.controller('danhgiachatluongAddController', danhgiachatluongAddController);

    danhgiachatluongAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$filter','$location'];

    function danhgiachatluongAddController(apiService, $scope, notificationService, $state, $filter,$location) {

        $scope.Adddanhgiachatluong = Adddanhgiachatluong;

        function Adddanhgiachatluong() {
            apiService.post('api/danhgiachatluong/create', $scope.danhgiachatluong, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess('Dữ liệu đã được thêm mới.');
            $location.url('danhgiachatluong');
        }
        function addFailed(response) {
            notificationService.displayError(response.data);
        }

        function CheckAuthen() {
            apiService.get('api/danhgiachatluong/checkauthencreate',
                function (result) {
                    $state.go('danhgiachatluong_add');
                }, function () {
                });
        }

        CheckAuthen();
    }

})(angular.module('bionet.danhgiachatluong'));