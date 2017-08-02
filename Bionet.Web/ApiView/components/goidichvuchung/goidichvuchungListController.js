(function (app) {
    app.controller('goidichvuchungListController', goidichvuchungListController);

    goidichvuchungListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function goidichvuchungListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.goidichvuchung = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.getgoidichvuchung = getgoidichvuchung;
        $scope.keyword = '';

        $scope.search = search;
        $scope.deletegoidichvuchung = deletegoidichvuchung;

        function search() {
            getgoidichvuchung();
        }

        function deletegoidichvuchung(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                 
                var config = {
                    params: {
                        ma: id.id
                    }
                }
                apiService.del('api/goidichvuchung/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        function getgoidichvuchung(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }
             
            apiService.get('/api/goidichvuchung/getall', config, function (result) {
                $scope.goidichvuchung = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                 
            }, function () {
                console.log('Load dịch vụ failed.');
            });
        }

        $scope.getgoidichvuchung();
    }
})(angular.module('bionet.goidichvuchung'));