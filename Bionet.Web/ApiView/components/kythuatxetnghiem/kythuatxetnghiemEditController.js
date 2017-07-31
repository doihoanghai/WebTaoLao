(function (app) {
    app.controller('kythuatxetnghiemEditController', kythuatxetnghiemEditController);

    kythuatxetnghiemEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function kythuatxetnghiemEditController(apiService, $scope, notificationService, $state, $stateParams) {

        $scope.Updatekythuatxetnghiem = Updatekythuatxetnghiem;

        function loadDichVuDetail() {
            apiService.get('api/dmkythuatxn/getbyid/' + $stateParams.id, null, function (result) {
                $scope.kythuatxetnghiem = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function Updatekythuatxetnghiem() {
            apiService.put('api/dmkythuatxn/update', $scope.kythuatxetnghiem,
                function (result) {
                    notificationService.displaySuccess('Dữ liệu đã được cập nhật.');
                    $state.go('kythuatxetnghiem');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }


        loadDichVuDetail();
    }

})(angular.module('bionet.kythuatxetnghiem'));