(function (app) {
    app.controller('donvicosoAddController', donvicosoAddController);

    donvicosoAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function donvicosoAddController(apiService, $scope, notificationService, $state, $stateParams) {

        $scope.AddDonViCoSo = AddDonViCoSo;

        function AddDonViCoSo() {
            apiService.post('api/donvicoso/create', $scope.donvicoso,
                function (result) {
                    notificationService.displaySuccess('Dữ liệu đã được thêm mới.');
                    $state.go('donvicoso');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }

        function loadChiCuc() {
            apiService.get('api/chicuc/getallChiCuc', null, function (result) {
                $scope.chicuc = result.data;
            }, function () {
                console.log('Cannot get list nhom');
            });
        }

        function CheckAuthen() {
            apiService.get('api/donvicoso/checkauthencreate',
                function (result) {
                    $state.go('donvicoso_add');
                }, function () {
                });
        }

        CheckAuthen();
        loadChiCuc();
    }

})(angular.module('bionet.donvicoso'));