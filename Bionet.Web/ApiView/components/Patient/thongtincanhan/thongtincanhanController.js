(function (app) {
    app.controller('thongtincanhanController', thongtincanhanController);

    thongtincanhanController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', '$filter'];

    function thongtincanhanController(apiService, $scope, notificationService, $state, $stateParams, $filter) {
        debugger;
        $scope.getthongtin = getthongtin;
        $scope.sex = ['Nam','Nữ', 'Không xác định'];
        $scope.phuongphapsinh = ['Sinh thường','Sinh mổ','Không xác định'];
        $scope.chedodinhduong = ['Bú mẹ', 'Bú bình','Tĩnh mạch'];
        $scope.vitrilaymau = ['Gót chân','Tĩnh mạch',  'Khác'];
        $scope.tinhtrang = [
            { name: 'Bình thường', id: 0 },
            { name: 'Bị bệnh', id: 1 },
            { name: 'Dùng steroid', id: 2 },
            { name: 'Dùng kháng sinh', id: 3 },
            { name: 'Truyền máu', id: 4 }
        ];
        function getthongtin(ma) {
            apiService.get('/api/patient/getThongTin/?mabenhnhan=', null, function (result) {
                $scope.thongtin = result.data;
                var s = $scope.sex[0];
                debugger;

            })
        }

        $scope.getthongtin();
    }

})(angular.module('bionet.thongtincanhan'));