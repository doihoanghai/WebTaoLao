(function (app) {
    app.controller('thongsoxetnghiemListController', thongsoxetnghiemListController);

    thongsoxetnghiemListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function thongsoxetnghiemListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.thongsoxetnghiem = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.getthongsoxetnghiem = getthongsoxetnghiem;
        $scope.keyword = '';

        $scope.search = search;
        $scope.deleteThongSoXN = deleteThongSoXN;

        function search() {
            getthongsoxetnghiem();
        }

        function deleteThongSoXN(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/thongsoxetnghiem/delete', id, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        function getthongsoxetnghiem(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }

            apiService.get('/api/thongsoxetnghiem/getall', config, function (result) {
                $scope.thongsoxetnghiem = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load dịch vụ failed.');
            });
        }

        $scope.getthongsoxetnghiem();
    }
})(angular.module('bionet.thongsoxetnghiem'));