(function (app) {
    app.controller('phieusanglocAddController', phieusanglocAddController);

    phieusanglocAddController.$inject = ['apiService', 'authData', '$scope', 'notificationService', '$state', '$stateParams'];

    function phieusanglocAddController(apiService, authData, $scope, notificationService, $state, $stateParams) {

        $scope.AddPhieuSangLoc = AddPhieuSangLoc;
        $scope.checkExistMa = checkExistMa;
        $scope.authentication = authData.authenticationData;

        function checkExistMa(ma) {
            apiService.get('api/phieusangloc/getbyMa/' + ma, null, function (result) {
                result.data = result.data;
                if (result.data == null) {
                    AddPhieuSangLoc();
                } else {
                    notificationService.displayError('Mã đã tồn tại.');
                }
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function CheckAuthen() {
            apiService.get('api/phieusangloc/checkauthencreate',
                function (result) {
                    $state.go('phieusangloc_add');
                }, function () {
                });
        }

        function AddPhieuSangLoc() {
            $scope.phieusangloc.Username = $scope.authentication.userName;
            apiService.post('api/phieusangloc/create', $scope.phieusangloc,
                function (result) {
                    notificationService.displaySuccess('Dữ liệu đã được thêm mới.');
                    $state.go('phieusangloc');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }

        function loadChuongTrinh() {
            apiService.get('api/chuongtrinh/getallChuongTrinh', null, function (result) {
                $scope.chuongtrinh = result.data;
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

        function loadGoiDichVuChung() {
            apiService.get('api/goidichvuchung/getallGoiDichVu', null, function (result) {
                $scope.goidichvu = result.data;
            }, function () {
                console.log('Cannot get list nhom');
            });
        }

        function loadDanToc() {
            apiService.get('api/dantoc/getallDanToc', null, function (result) {
                $scope.dantoc = result.data;
            }, function () {
                console.log('Cannot get list nhom');
            });
        }

        CheckAuthen();
        loadChuongTrinh();
        loadDonViCoSo();
        loadGoiDichVuChung();
        loadDanToc();
    }

})(angular.module('bionet.phieusangloc'));