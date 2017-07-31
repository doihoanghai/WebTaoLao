(function (app) {
    app.controller('trungtamsanglocAddController', trungtamsanglocAddController);

    trungtamsanglocAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function trungtamsanglocAddController(apiService, $scope, notificationService, $state, $stateParams) {

        $scope.AddTrungTam = AddTrungTam;
        $scope.checkExistMa = checkExistMa;


        function checkExistMa(ma) {
            apiService.get('api/trungtamsangloc/getbyMa/' + ma, null, function (result) {
                result.data = result.data;
                if(result.data == null)
                {
                    AddTrungTam();
                } else {
                    notificationService.displayError('Mã đã tồn tại.');
                }
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function AddTrungTam() {
            apiService.post('api/trungtamsangloc/create', $scope.trungtamsangloc,
                function (result) {
                    notificationService.displaySuccess('Dữ liệu đã được thêm mới.');
                    $state.go('trungtamsangloc');
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
            apiService.get('api/trungtamsangloc/checkauthencreate',
                function (result) {
                    $state.go('trungtamsangloc_add');
                }, function () {
                });
        }

        CheckAuthen();
        loadNhom();
        loadDonViCoSo();
    }

})(angular.module('bionet.trungtamsangloc'));