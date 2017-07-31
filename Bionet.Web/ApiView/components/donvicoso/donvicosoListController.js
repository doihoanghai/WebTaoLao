(function (app) {
    app.controller('donvicosoListController', donvicosoListController);

    donvicosoListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function donvicosoListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.GoiDichVudonvicoso = {};
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.getdonvicoso = getdonvicoso;
        $scope.keyword = '';

        $scope.search = search;
        $scope.deleteDonViCoSo = deleteDonViCoSo;

        $scope.search = search;
        $scope.loadGoiDVTT = loadGoiDVTT;
        $scope.Update = Update;

        function search() {
            getdonvicoso();
        }

        function deleteDonViCoSo(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/donvicoso/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        function getdonvicoso(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }

            apiService.get('/api/donvicoso/getall', config, function (result) {
                debugger;
                $scope.donvicoso = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load dịch vụ failed.');
            });
        }
        function loadGoiDVTT(maDVCS) {
            debugger;
            $scope.maDVCS = maDVCS;
            loadGoiDVTTdetail(maDVCS);

        }

        function loadGoiDV() {
            apiService.get('api/goidichvuchung/getallGoiDichVu', null, function (result) {
                $scope.service = result.data;
            }, function () {
                console.log('Cannot get list Service Package');
            });
        }
        function loadGoiDVTTdetail(maDVCS) {

            apiService.get('api/goidichvuchung/getallGoiDichVuDVCS?maDVCS=' + maDVCS, null, function (result) {
                debugger;
                $scope.serviceDetail = result.data;
                loadGoiDV();
            }, function () {
                null
            }
            )
        }
        function Update() {
            debugger;
            $scope.GoiDichVudonvicoso.lstGoiDichVu = $scope.serviceDetail;
            $scope.GoiDichVudonvicoso.MaTT = $scope.maDVCS;
            apiService.post('api/goidichvuchung/UpdateGoiDVDVCS', $scope.GoiDichVudonvicoso, function (result) {
                notificationService.displaySuccess('Cập nhật gói dịch vụ đơn vị thành công!');

            }, function () {
                notificationService.displayError('Cập nhật không thành công!');
            })
        }

        $scope.getdonvicoso();
    }
})(angular.module('bionet.donvicoso'));