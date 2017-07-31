(function (app) {
    app.controller('chicucListController', chicucListController);

    chicucListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function chicucListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.chicuc = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.getchicuc = getchicuc;
        $scope.keyword = '';

        $scope.search = search;
        $scope.deleteChiCuc = deleteChiCuc;

        function search() {
            getchicuc();
        }

        function deleteChiCuc(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/chicuc/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        function getchicuc(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }

            apiService.get('/api/chicuc/getall', config, function (result) {
                $scope.chicuc = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load dịch vụ failed.');
            });
        }

        $scope.getchicuc();
    }
})(angular.module('bionet.chicuc'));