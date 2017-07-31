(function (app) {
    app.controller('trungtamsanglocEditController', trungtamsanglocEditController);

    trungtamsanglocEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function trungtamsanglocEditController(apiService, $scope, notificationService, $state, $stateParams) {

        $scope.Updategoidichvu = Updategoidichvu;

        function loadDichVuDetail() {
            apiService.get('api/trungtamsangloc/getbyid/' + $stateParams.id, null, function (result) {
                $scope.trungtamsangloc = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function Updategoidichvu() {
            apiService.put('api/trungtamsangloc/update', $scope.trungtamsangloc,
                function (result) {
                    notificationService.displaySuccess('Dữ liệu đã được cập nhật.');
                    $state.go('trungtamsangloc');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }

        loadDichVuDetail();
    }

})(angular.module('bionet.trungtamsangloc'));