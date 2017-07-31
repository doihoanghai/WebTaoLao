(function (app) {
    app.controller('donvicosoEditController', donvicosoEditController);

    donvicosoEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function donvicosoEditController(apiService, $scope, notificationService, $state, $stateParams) {

        $scope.Updatedonvicoso = Updatedonvicoso;

        function loadDonViCoSoDetail() {
            apiService.get('api/donvicoso/getbyid/' + $stateParams.id, null, function (result) {
                $scope.donvicoso = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function Updatedonvicoso() {
            apiService.put('api/donvicoso/update', $scope.donvicoso,
                function (result) {
                    notificationService.displaySuccess('Dữ liệu đã được cập nhật.');
                    $state.go('donvicoso');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }

        function loadChiCuc() {
            apiService.get('api/chicuc/getallChiCuc', null, function (result) {
                $scope.chicuc = result.data;
            }, function () {
                console.log('Cannot get list nhom');
            });
        }

        loadChiCuc();
        loadDonViCoSoDetail();
    }

})(angular.module('bionet.donvicoso'));