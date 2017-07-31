(function (app) {
    app.controller('thongsoxetnghiemEditController', thongsoxetnghiemEditController);

    thongsoxetnghiemEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function thongsoxetnghiemEditController(apiService, $scope, notificationService, $state, $stateParams) {

        $scope.Updatethongsoxetnghiem = Updatethongsoxetnghiem;

        function loadDichVuDetail() {
            apiService.get('api/thongsoxetnghiem/getbyid/' + $stateParams.id, null, function (result) {
                $scope.thongsoxetnghiem = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function Updatethongsoxetnghiem() {
            apiService.put('api/thongsoxetnghiem/update', $scope.thongsoxetnghiem,
                function (result) {
                    notificationService.displaySuccess('Dữ liệu đã được cập nhật.');
                    $state.go('thongsoxetnghiem');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }

        function loadNhom() {
            apiService.get('api/nhom/getall', null, function (result) {
                $scope.nhom = result.data;
            }, function () {
                console.log('Cannot get list nhom');
            });
        }

        function loadDonViCoSo() {
            apiService.get('api/donvicoso/getallDonVi', null, function (result) {
                $scope.donvi = result.data;
            }, function () {
                console.log('Cannot get list nhom');
            });
        }

        loadNhom();
        loadDonViCoSo();
        loadDichVuDetail();
    }

})(angular.module('bionet.thongsoxetnghiem'));