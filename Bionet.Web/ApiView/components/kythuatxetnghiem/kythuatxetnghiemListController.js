(function (app) {
    app.controller('kythuatxetnghiemListController', kythuatxetnghiemListController);

    kythuatxetnghiemListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function kythuatxetnghiemListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.mapsupdate = {};
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.getkythuatxetnghiem = getkythuatxetnghiem;
        $scope.keyword = '';

        $scope.search = search;
        $scope.deleteKyThuatXN = deleteKyThuatXN;
        $scope.Update = Update;
        $scope.idKythuat;


        $scope.loadthongsoxntheokythuat = loadthongsoxntheokythuat;

        function search() {
            getkythuatxetnghiem();
        }

        function deleteKyThuatXN(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                 
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

        function loadthongsoxntheokythuat(maKyThuat)
        {
            $scope.idKythuat = maKyThuat;
            loadthongsoxntheokythuat1(maKyThuat);
        }

        function loadthongsoxn()
        {

            apiService.get('api/thongsoxetnghiem/GetMapsTS', null, function (result) {
                $scope.service = result.data;
            }, function () {
                console.log('Cannot get list Service Package');
            });
        }

        function loadthongsoxntheokythuat1(maKyThuat)
        {
            
            apiService.get('api/mapsxnthongso/getallthongsoxn?makythuat=' + maKyThuat, null, function (result) {
                 
                $scope.serviceDetail = result.data;
                loadthongsoxn();
            }, function () {
                null
            }
            )
        }
        function Update() {
             
            $scope.mapsupdate.idKyThuat = $scope.idKythuat;
            $scope.mapsupdate.mapxnts = $scope.serviceDetail;
            apiService.post('api/mapsxnthongso/update', $scope.mapsupdate, function (result) {
                notificationService.displaySuccess('Cập nhật gói dịch vụ trung tâm thành công!');

            }, function () {
                notificationService.displayError('Cập nhật không thành công!');
            })
        }


      


        $scope.getkythuatxetnghiem();
    }
})(angular.module('bionet.kythuatxetnghiem'));