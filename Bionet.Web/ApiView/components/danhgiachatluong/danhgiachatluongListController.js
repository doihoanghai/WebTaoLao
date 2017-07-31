(function (app) {
    app.controller('danhgiachatluongListController', danhgiachatluongListController);

    danhgiachatluongListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function danhgiachatluongListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.danhgiachatluong = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.getdanhgiachatluong = getdanhgiachatluong;
        $scope.keyword = '';

        $scope.search = search;
        $scope.deletedanhgiachatluong = deletedanhgiachatluong;

        function search() {
            getdanhgiachatluong();
        }

        function deletedanhgiachatluong(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/danhgiachatluong/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        function getdanhgiachatluong(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }

            apiService.get('/api/danhgiachatluong/getall', config, function (result) {
                $scope.danhgiachatluong = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load dịch vụ failed.');
            });
        }

        $scope.getdanhgiachatluong();
    }
})(angular.module('bionet.danhgiachatluong'));