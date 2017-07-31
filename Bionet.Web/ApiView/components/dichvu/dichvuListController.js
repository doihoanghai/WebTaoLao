(function (app) {
    app.controller('dichvuListController', dichvuListController);

    dichvuListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function dichvuListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.dichvu = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.getdichvu = getdichvu;
        $scope.keyword = '';

        $scope.search = search;
        $scope.deleteDichVu = deleteDichVu;

        function search() {
            getdichvu();
        }

         function deleteDichVu(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/dichvu/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }
        
        function getdichvu(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }

            apiService.get('/api/dichvu/getall', config, function (result) {
                $scope.dichvu = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load dịch vụ failed.');
            });
        }

        $scope.getdichvu();
    }
})(angular.module('bionet.dichvu'));