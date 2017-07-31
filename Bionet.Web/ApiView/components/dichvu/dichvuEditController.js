(function (app) {
    app.controller('dichvuEditController', dichvuEditController);

    dichvuEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function dichvuEditController(apiService, $scope, notificationService, $state, $stateParams) {

        $scope.Updatedichvu = Updatedichvu;

        function loadDichVuDetail() {
            apiService.get('api/dichvu/getbyid/' + $stateParams.id, null, function (result) {
                $scope.dichvu = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function Updatedichvu() {
            apiService.put('api/dichvu/update', $scope.dichvu,
                function (result) {
                    notificationService.displaySuccess('Dữ liệu đã được cập nhật.');
                    $state.go('dichvu');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }

        function loadNhom() {
            apiService.get('api/nhom/getall', null, function (result) {
                $scope.nhom = result.data;
            }, function () {
                console.log('Cannot get list nhom');
            });
        }

        loadNhom();
        loadDichVuDetail();
    }

})(angular.module('bionet.dichvu'));