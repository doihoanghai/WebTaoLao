﻿(function (app) {
    app.controller('chuongtrinhListController', chuongtrinhListController);

    chuongtrinhListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function chuongtrinhListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.chuongtrinh = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.getchuongtrinh = getchuongtrinh;
        $scope.keyword = '';

        $scope.search = search;
        $scope.deleteChuongTrinh = deleteChuongTrinh;

        function search() {
            getchuongtrinh();
        }

        function deleteChuongTrinh(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/chuongtrinh/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        function getchuongtrinh(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }

            apiService.get('/api/chuongtrinh/getall', config, function (result) {
                $scope.chuongtrinh = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load dịch vụ failed.');
            });
        }

        $scope.getchuongtrinh();
    }
})(angular.module('bionet.chuongtrinh'));