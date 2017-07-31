(function (app) {
    app.controller('chicucEditController', chicucEditController);

    chicucEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function chicucEditController(apiService, $scope, notificationService, $state, $stateParams) {

        $scope.Updatechicuc = Updatechicuc;

        function loadChiCucDetail() {
            apiService.get('api/chicuc/getbyid/' + $stateParams.id, null, function (result) {
                $scope.chicuc = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function Updatechicuc() {
            apiService.put('api/chicuc/update', $scope.chicuc,
                function (result) {
                    notificationService.displaySuccess('Dữ liệu đã được cập nhật.');
                    $state.go('chicuc');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }

        function loadTrungTam() {
            apiService.get('api/trungtamsangloc/getallTrungTam', null, function (result) {
                $scope.trungtam = result.data;
            }, function () {
                console.log('Cannot get list nhom');
            });
        }

        loadTrungTam();
        loadChiCucDetail();
    }

})(angular.module('bionet.chicuc'));