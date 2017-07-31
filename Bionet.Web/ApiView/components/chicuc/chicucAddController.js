(function (app) {
    app.controller('chicucAddController', chicucAddController);

    chicucAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function chicucAddController(apiService, $scope, notificationService, $state, $stateParams) {

        $scope.AddChiCuc = AddChiCuc;

        function AddChiCuc() {
            apiService.post('api/chicuc/create', $scope.chicuc,
                function (result) {
                    notificationService.displaySuccess('Dữ liệu đã được thêm mới.');
                    $state.go('chicuc');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }

        function loadTrungTam() {
            apiService.get('api/trungtamsangloc/getallTrungTam', null, function (result) {
                $scope.trungtam = result.data;
            }, function () {
                console.log('Cannot get list nhom');
            });
        }

        function CheckAuthen() {
            apiService.get('api/chicuc/checkauthencreate',
                function (result) {
                    $state.go('chicuc_add');
                }, function () {
                });
        }

        CheckAuthen();
        loadTrungTam();
    }

})(angular.module('bionet.chicuc'));