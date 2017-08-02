(function (app) {
    app.controller('chitietgoidichvuController', chitietgoidichvuController);

    chitietgoidichvuController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function chitietgoidichvuController($scope, apiService, notificationService, $ngBootbox) {
        $scope.chitietgoidichvu = {};
        $scope.Update = Update;
        $scope.deletechitietgoidichvu = deletechitietgoidichvu;
        $scope.loadServiceByServicePackage = loadServiceByServicePackage;


        function loadServicePackage() {
            apiService.get('api/goidichvuchung/getallGoiDichVu', null, function (result) {
                $scope.servicePackage = result.data;
            }, function () {
                console.log('Cannot get list Service Package');
            });
        }

        function loadService() {
            apiService.get('api/dichvu/getallDichVu', null, function (result) {
                $scope.service = result.data;
            }, function () {
                console.log('Cannot get list Service');
            });
        }

        function loadServiceByServicePackage(servicePackageCode, serviceName) {
            $scope.servicePackageCode = servicePackageCode;
            $scope.serviceName = serviceName;
            apiService.get('api/chitietgoidichvu/getServiceByServicePackage/' + servicePackageCode, null, function (result) {

                $scope.serviceDetail = result.data;
                loadService();
            }, function () {
                console.log('Cannot get list Service');
            });
        }

        function deletechitietgoidichvu(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/chitietgoidichvu/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        function Update() {
            if ($scope.servicePackageCode != undefined)
            {
                 
                $scope.chitietgoidichvu.lstDanhMucDichVu = $scope.serviceDetail;
                $scope.chitietgoidichvu.IDGoiDichVuChung = $scope.servicePackageCode;
                apiService.post('/api/chitietgoidichvu/update', $scope.chitietgoidichvu
                    , function (result) {
                        notificationService.displaySuccess('Cập nhật chi tiêt gói dịch vụ chung thành công!');
                    }, function () {
                        notificationService.displayError('Cập nhật thất bại');
                    });
            } else {
                notificationService.displayError('Chưa chọn gói dịch vụ để thực hiện');
            }
            
        }

        function CheckAuthen() {
            apiService.get('api/chitietgoidichvu/checkauthencreate',
                function (result) {
                    $state.go('dichvu_add');
                }, function () {
                });
        }

        CheckAuthen();
        loadServicePackage();
        loadService();
    }
})(angular.module('bionet.chitietgoidichvu'));