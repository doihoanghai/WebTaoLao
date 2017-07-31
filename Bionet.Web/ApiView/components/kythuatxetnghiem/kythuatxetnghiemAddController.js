(function (app) {
    app.controller('kythuatxetnghiemAddController', kythuatxetnghiemAddController);

    kythuatxetnghiemAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function kythuatxetnghiemAddController(apiService, $scope, notificationService, $state, $stateParams) {

        $scope.Addkythuatxetnghiem = Addkythuatxetnghiem;
        $scope.checkExistMa = checkExistMa;


        function checkExistMa(ma) {
            apiService.get('api/dmkythuatxn/getbyMa/' + ma, null, function (result) {
                result.data = result.data;
                if(result.data == null)
                {
                    Addkythuatxetnghiem();
                } else {
                    notificationService.displayError('Mã đã tồn tại.');
                }
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function Addkythuatxetnghiem() {
            apiService.post('api/dmkythuatxn/create', $scope.kythuatxetnghiem,
                function (result) {
                    notificationService.displaySuccess('Dữ liệu đã được thêm mới.');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }

        


        function CheckAuthen() {
            apiService.get('api/dmkythuatxn/checkauthencreate',
                function (result) {
                    $state.go('kythuatxetnghiem_add');
                }, function () {
                });
        }

        CheckAuthen();

    }

})(angular.module('bionet.kythuatxetnghiem'));