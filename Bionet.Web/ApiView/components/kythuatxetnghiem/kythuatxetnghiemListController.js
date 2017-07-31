(function (app) {
    app.controller('kythuatxetnghiemListController', kythuatxetnghiemListController);

    kythuatxetnghiemListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function kythuatxetnghiemListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.kythuatxetnghiem = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.getkythuatxetnghiem = getkythuatxetnghiem;
        $scope.keyword = '';

        $scope.search = search;
        $scope.deleteKyThuatXN = deleteKyThuatXN;

        $scope.loadthongsoxntheokythuat = loadthongsoxntheokythuat;

        function search() {
            getkythuatxetnghiem();
        }

        function deleteKyThuatXN(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                debugger;
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/dmkythuatxn/delete/?id=' +id, null, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        function getkythuatxetnghiem(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }

            apiService.get('/api/dmkythuatxn/getall', config, function (result) {
                $scope.kythuatxetnghiem = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load dịch vụ failed.');
            });
        }

        function loadthongsoxn()
        {
<<<<<<< HEAD
            apiService.get('api/thongsoxetnghiem/GetMapsTS', null, function (result) {
                $scope.service = result.data;
            }, function () {
                console.log('Cannot get list Service Package');
            });
=======

>>>>>>> 0ff1717dcaea158ef193d2a433afc89a5454a473
        }

        function loadthongsoxntheokythuat(maKyThuat)
        {
<<<<<<< HEAD
            apiService.get('api/mapxnts/getallthongsoxn?makythuat=' + maKyThuat, null, function (result) {
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
            $scope.goiDVtrungtam.lstGoiDichVu = $scope.serviceDetail;
            $scope.goiDVtrungtam.maTT = $scope.maTT;
            apiService.post('api/goidichvuchung/UpdateGoiDVTT', $scope.goiDVtrungtam, function (result) {
                notificationService.displaySuccess('Cập nhật gói dịch vụ trung tâm thành công!');

            }, function () {
                notificationService.displayError('Cập nhật không thành công!');
            })
        }

=======

        }


>>>>>>> 0ff1717dcaea158ef193d2a433afc89a5454a473
        $scope.getkythuatxetnghiem();
    }
})(angular.module('bionet.kythuatxetnghiem'));