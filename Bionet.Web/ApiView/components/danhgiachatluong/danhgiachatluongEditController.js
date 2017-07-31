(function (app) {
    app.controller('danhgiachatluongEditController', danhgiachatluongEditController);

    danhgiachatluongEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', '$filter'];

    function danhgiachatluongEditController(apiService, $scope, notificationService, $state, $stateParams, $filter) {

        $scope.Updatedanhgiachatluong = Updatedanhgiachatluong;
        

        function loaddanhgiachatluongDetail() {
            apiService.get('api/danhgiachatluong/getbyid/' + $stateParams.id, null, function (result) {
                $scope.danhgiachatluong = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function Updatedanhgiachatluong() {
            apiService.put('api/danhgiachatluong/update', $scope.danhgiachatluong,
                function (result) {
                    notificationService.displaySuccess('Dữ liệu đã được cập nhật.');
                    $state.go('danhgiachatluong');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }

        loaddanhgiachatluongDetail();
    }

})(angular.module('bionet.danhgiachatluong'));