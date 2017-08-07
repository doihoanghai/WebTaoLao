(function (app) {
    app.filter('statusFilter', function () {
        return function (input) {
            if (input == true)
                return 'Kích hoạt';
            else
                return 'Khóa';
        }
    });

    app.filter('statusLevel', function () {
        return function (input) {
            if (input == 1)
                return 'Trung Tâm';
            else if (input == 2)
                return 'Chi cục';
            else if (input == 3)
                return 'Đơn vị cơ sở'
            else if(input == 0)
                return 'Tổng cục'
            else
                return 'N/a';
        }
    });

    app.filter('trangthaiphieu', function () {
        return function (input) {
            if (input == true)
                return 'Đã nhân';
            else
                return 'Chưa nhận';
        }
    });

    app.filter('trangthaimau', function () {
        return function (input) {
            if (input == 1)
                return 'Đã tiếp nhận';
            else if (input == 2)
                return 'Đã đánh giá';
            else if (input == 3)
                return 'Đã vào phòng xét nghiệm';
            else if (input == 4)
                return 'Đã có kết quả';
            else if (input == 5)
                return 'Mẫu làm xét nghiệm lần 2';
            else if (input == 6)
                return 'Mẫu chỉ định thu lại';
            else
                return 'Na/Na';
        }
    });
})(angular.module('bionet.common'));