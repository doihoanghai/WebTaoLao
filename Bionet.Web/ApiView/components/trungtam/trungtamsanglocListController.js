(function (app) {
    app.controller('trungtamsanglocListController', trungtamsanglocListController);

    trungtamsanglocListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function trungtamsanglocListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.goiDVtrungtam = {};
        $scope.maTT;
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.gettrungtam = gettrungtam;
        $scope.keyword = '';
        
        $scope.search = search;
        $scope.deleteTrungTamSangLoc = deleteTrungTamSangLoc;
        $scope.loadGoiDVTT = loadGoiDVTT;
        $scope.Update = Update;

        function search() {
            gettrungtam();
        }

        function deleteTrungTamSangLoc(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/trungtamsangloc/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        function gettrungtam(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }

            apiService.get('/api/trungtamsangloc/getall', config, function (result) {
                $scope.trungtamsangloc = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load dịch vụ failed.');
            });
        }

        function loadGoiDVTT(maTT)
        {
             
            $scope.maTT = maTT;
            loadGoiDVTTdetail(maTT);
            
        }

        function loadGoiDV()
        {
            apiService.get('api/goidichvuchung/getallGoiDichVu', null, function (result) {
                $scope.service = result.data;
            }, function () {
                console.log('Cannot get list Service Package');
            });
        }
        function loadGoiDVTTdetail(maTT)
        {
            
            apiService.get('api/goidichvuchung/getallGoiDichVuTT?maTT='+maTT,null, function (result) {
                 
                $scope.serviceDetail = result.data;
                loadGoiDV();
            }, function () {
                null
            }
            )
        }
        function Update()
        {
             
            $scope.goiDVtrungtam.lstGoiDichVu = $scope.serviceDetail;
            $scope.goiDVtrungtam.maTT = $scope.maTT;
            apiService.post('api/goidichvuchung/UpdateGoiDVTT', $scope.goiDVtrungtam, function (result) {
                notificationService.displaySuccess('Cập nhật gói dịch vụ trung tâm thành công!');

            }, function () {
                notificationService.displayError('Cập nhật không thành công!');
            })
        }

        $scope.gettrungtam();
    }
})(angular.module('bionet.trungtamsangloc'));