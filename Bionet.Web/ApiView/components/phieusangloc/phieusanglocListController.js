(function (app) {
    app.controller('phieusanglocListController', phieusanglocListController);

    phieusanglocListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function phieusanglocListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.phieusangloc = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.getphieusangloc = getphieusangloc;
        $scope.keyword = '';
        $scope.search = search;
        $scope.deletephieusangloc = deletephieusangloc;
        $scope.number = 5;

        function search() {
            getphieusangloc();
        }

        function deletephieusangloc(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/phieusangloc/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        function getphieusangloc(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: $scope.number
                }
            }

            apiService.get('/api/phieusangloc/getall', config, function (result) {
                $scope.phieusangloc = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load dịch vụ failed.');
            });
        }

        $scope.getphieusangloc();
    }
})(angular.module('bionet.phieusangloc'));
