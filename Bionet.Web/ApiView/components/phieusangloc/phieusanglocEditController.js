(function (app) {
    app.controller('phieusanglocEditController', phieusanglocEditController);

    phieusanglocEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', '$filter'];

    function phieusanglocEditController(apiService, $scope, notificationService, $state, $stateParams, $filter) {

        $scope.UpdatePhieuSangLoc = UpdatePhieuSangLoc;
        $scope.sex = [{ name: 'Nam', id: 0 }, { name: 'Nữ', id: 1 }, { name: 'Không xác định', id: 2 }];
        $scope.phuongphapsinh = [{ name: 'Sinh thường', id: 0 }, { name: 'Sinh mổ', id: 1 }];
        //$scope.chedodinhduong = [{ name: 'Bú mẹ', id: 0 }, { name: 'Bú bình', id: 1 }, { name: 'Tĩnh mạch', id: 2 }];
        //$scope.vitrilaymau = [{ name: 'Gót chân', id: 0 }, { name: 'Tĩnh mạch', id: 1 }, { name: 'Khác', id: 2 }];
        //$scope.tinhtrang = [
        //    { name: 'Bình thường', id: 0 },
        //    { name: 'Bị bệnh', id: 1 },
        //    { name: 'Dùng steroid', id: 2 },
        //    { name: 'Dùng kháng sinh', id: 3 },
        //    { name: 'Truyền máu', id: 4 }
        //];

        function loadphieusanglocDetail() {
            apiService.get('api/phieusangloc/getbyid/' + $stateParams.id, null, function (result) {
                $scope.phieusangloc = result.data;
                $scope.phieusangloc.MotherBirthday = $filter('date')($scope.phieusangloc.MotherBirthday, 'dd/MM/yyyy');
                $scope.phieusangloc.FatherBirthday = $filter('date')($scope.phieusangloc.FatherBirthday, 'dd/MM/yyyy');
                $scope.phieusangloc.NgayGioLayMauTime = $filter('date')($scope.phieusangloc.NgayGioLayMauTime, 'HH:mm');
                $scope.phieusangloc.NgayGioSinhTime = $filter('date')($scope.phieusangloc.NgayGioSinhTime, 'HH:mm');
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function UpdatePhieuSangLoc() {
            apiService.put('api/phieusangloc/update', $scope.phieusangloc,
                function (result) {
                    notificationService.displaySuccess('Dữ liệu đã được cập nhật.');
                    $state.go('phieusangloc');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
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

        loadChuongTrinh();
        loadDonViCoSo();
        loadGoiDichVuChung();
        loadDanToc();
        loadphieusanglocDetail();
    }

})(angular.module('bionet.phieusangloc'));