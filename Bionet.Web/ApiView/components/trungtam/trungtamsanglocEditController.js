(function (app) {
    app.controller('trungtamsanglocEditController', trungtamsanglocEditController);

    trungtamsanglocEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function trungtamsanglocEditController(apiService, $scope, notificationService, $state, $stateParams) {

        $scope.Updatetrungtam = Updatetrungtam;

        function loadtrungtamdetail() {
            apiService.get('api/trungtamsangloc/getbyid/' + $stateParams.id, null, function (result) {
                $scope.trungtam = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function Updatetrungtam() {
            debugger;
            apiService.put('api/trungtamsangloc/update', $scope.trungtam,
                function (result) {
                    notificationService.displaySuccess('Dữ liệu đã được cập nhật.');
                    $state.go('trungtamsangloc');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }

        loadtrungtamdetail();
    }

})(angular.module('bionet.trungtamsangloc'));