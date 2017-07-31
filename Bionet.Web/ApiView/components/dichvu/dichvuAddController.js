(function (app) {
    app.controller('dichvuAddController', dichvuAddController);

    dichvuAddController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function dichvuAddController(apiService, $scope, notificationService, $state) {

        $scope.Adddichvu = Adddichvu;

        function Adddichvu() {
            apiService.post('api/dichvu/create', $scope.dichvu,
                function (result) {
                    notificationService.displaySuccess('Dữ liệu đã được thêm mới.');
                    $state.go('dichvu');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }
        function loadNhom() {
            apiService.get('api/nhom/getall', null, function (result) {
                $scope.nhom = result.data;
            }, function () {
                console.log('Cannot get list nhom');
            });
        }
         function CheckAuthen() {
            apiService.get('api/dichvu/checkauthencreate',
                function (result) {
                    $state.go('dichvu_add');
                }, function () {
                });
        }

        CheckAuthen();
        loadNhom();
    }

})(angular.module('bionet.dichvu'));