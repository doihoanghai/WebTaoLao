(function (app) {
    app.controller('thongsoxetnghiemAddController', thongsoxetnghiemAddController);

    thongsoxetnghiemAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function thongsoxetnghiemAddController(apiService, $scope, notificationService, $state, $stateParams) {

        $scope.Addthongsoxetnghiem = Addthongsoxetnghiem;
        $scope.checkExistMa = checkExistMa;


        function checkExistMa(ma) {
            apiService.get('api/thongsoxetnghiem/getbyMa/' + ma, null, function (result) {
                result.data = result.data;
                if(result.data == null)
                {
                    Addthongsoxetnghiem();
                } else {
                    notificationService.displayError('Mã đã tồn tại.');
                }
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function Addthongsoxetnghiem() {
            apiService.post('api/thongsoxetnghiem/create', $scope.thongsoxetnghiem,
                function (result) {
                    notificationService.displaySuccess('Dữ liệu đã được thêm mới.');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
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

        function CheckAuthen() {
            apiService.get('api/thongsoxetnghiem/checkauthencreate',
                function (result) {
                    $state.go('thongsoxetnghiem_add');
                }, function () {
                });
        }

        CheckAuthen();
        loadNhom();
        loadDonViCoSo();
    }

})(angular.module('bionet.thongsoxetnghiem'));