(function (app) {
    app.controller('chuongtrinhAddController', chuongtrinhAddController);

    chuongtrinhAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$filter'];

    function chuongtrinhAddController(apiService, $scope, notificationService, $state, $filter) {

        $scope.Addchuongtrinh = Addchuongtrinh;

        function Addchuongtrinh() {
            apiService.post('api/chuongtrinh/create', $scope.chuongtrinh,
                function (result) {
                    notificationService.displaySuccess('Dữ liệu đã được thêm mới.');
                    $state.go('chuongtrinh');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }

        function CheckAuthen() {
            apiService.get('api/chuongtrinh/checkauthencreate',
                function (result) {
                    $state.go('chuongtrinh_add');
                }, function () {
                });
        }

        CheckAuthen();
    }

})(angular.module('bionet.chuongtrinh'));