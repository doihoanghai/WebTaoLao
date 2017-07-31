(function (app) {
    app.controller('chuongtrinhEditController', chuongtrinhEditController);

    chuongtrinhEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', '$filter'];

    function chuongtrinhEditController(apiService, $scope, notificationService, $state, $stateParams, $filter) {

        $scope.Updatechuongtrinh = Updatechuongtrinh;
        

        function loadChuongTrinhDetail() {
            apiService.get('api/chuongtrinh/getbyid/' + $stateParams.id, null, function (result) {
                $scope.chuongtrinh = result.data;
                $scope.chuongtrinh.Ngaytao = $filter('date')($scope.chuongtrinh.Ngaytao, 'dd/MM/yyyy');
                $scope.chuongtrinh.NgayHetHieuLuc = $filter('date')($scope.chuongtrinh.NgayHetHieuLuc, 'dd/MM/yyyy');
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function Updatechuongtrinh() {
            apiService.put('api/chuongtrinh/update', $scope.chuongtrinh,
                function (result) {
                    notificationService.displaySuccess('Dữ liệu đã được cập nhật.');
                    $state.go('chuongtrinh');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }

        loadChuongTrinhDetail();
    }

})(angular.module('bionet.chuongtrinh'));