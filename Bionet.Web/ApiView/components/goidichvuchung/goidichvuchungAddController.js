(function (app) {
    app.controller('goidichvuchungAddController', goidichvuchungAddController);

    goidichvuchungAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function goidichvuchungAddController(apiService, $scope, notificationService, $state, $stateParams) {

        $scope.AddGoiDV = AddGoiDV;
        $scope.checkExistMa = checkExistMa;


        function checkExistMa(ma) {
            apiService.get('api/goidichvuchung/getbyMa/' + ma, null, function (result) {
                result.data = result.data;
                if(result.data == null)
                {
                    AddGoiDV();
                } else {
                    notificationService.displayError('Mã đã tồn tại.');
                }
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function AddGoiDV() {
            apiService.post('api/goidichvuchung/create', $scope.goidichvuchung,
                function (result) {
                    notificationService.displaySuccess('Dữ liệu đã được thêm mới.');
                    $state.go('goidichvuchung');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }

        function CheckAuthen() {
            apiService.get('api/goidichvuchung/checkauthencreate',
                function (result) {
                    $state.go('goidichvuchung_add');
                }, function () {
                });
        }

        CheckAuthen();
    }

})(angular.module('bionet.goidichvuchung'));