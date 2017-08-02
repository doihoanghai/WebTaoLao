(function (app) {
    app.controller('goidichvuchungEditController', goidichvuchungEditController);

    goidichvuchungEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function goidichvuchungEditController(apiService, $scope, notificationService, $state, $stateParams) {

        $scope.Updategoidichvuchung = Updategoidichvuchung;

        function loadGoiDichVuDetail() {
            apiService.get('api/goidichvuchung/getbyma/' + $stateParams.id, null, function (result) {
                $scope.goidichvuchung = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function Updategoidichvuchung() {
            apiService.put('api/goidichvuchung/update', $scope.goidichvuchung,
                function (result) {
                    notificationService.displaySuccess('Dữ liệu đã được cập nhật.');
                    $state.go('goidichvuchung');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }

        loadGoiDichVuDetail();
    }

})(angular.module('bionet.goidichvuchung'));