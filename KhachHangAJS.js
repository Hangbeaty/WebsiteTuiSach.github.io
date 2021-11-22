MyApp.controller("KhachHangController", ['$scope', 'CrudService', function ($scope, CrudService) {
    //khai báo các xử lý cho controller
    //khai báo các giá trị khởi tạo ban đầu
    var baseUrl = "/Admin/KhachHang/";
    $scope.MaKH = "";
    $scope.TenKH = "";
    $scope.SDT = "";
    $scope.DiaChi = "";
    $scope.Email = "";
    $scope.btnText = "Thêm";
    //xây dựng hàm lấy về các bản ghi trong đối tượng KH
    $scope.LoadData = function () {
        var apiRoute = baseUrl + "getAllKH";
        var allData = CrudService.getAll(apiRoute);
        allData.then(function (res) {
            $scope.listdata = res.data;
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
    $scope.LoadData();
    //Viết hàm lấy về một sản phẩm
    $scope.GetByID = function (s) {
        var apiRoute = baseUrl + "getOneKH";
        var oneLSP = CrudService.getbyid(apiRoute, s.MaKH);
        oneLSP.then(function (res) {
            $scope.MaKH = res.data.MaKH;
            $scope.TenKH = res.data.TenKH;
            $scope.SDT = res.data.SDT;
            $scope.DiaChi = res.data.DiaChi;
            $scope.Email = res.data.Email;
            $scope.btnText = "Sửa";
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
    //Viết hàm thực hiện thêm mới một sản phẩm
    $scope.SaveUpdate = function () {
        //khai báo một bản ghi
        var singledata = {
            MaKH: $scope.MaKH,
            TenKH: $scope.TenKH,
            SDT: $scope.SDT,
            MaKH: $scope.DiaChi,
            TenKH: $scope.Email,
        };
        if ($scope.btnText == "Thêm") {
            //thực hiện thao tác thêm loại sản phẩm
            var apiRoute = baseUrl + "CreateKH";
            var saveData = CrudService.post(apiRoute, singledata);
            saveData.then(function (res) {
                if (res.data != null) {
                    alert("Thêm mới thành công!");
                    $scope.LoadData();
                    $scope.Clear();
                }
            }, function (error) {
                console.log("Lỗi: " + error);
            });
        }
        else {
            //thực hiện thao tác sửa loại sản phẩm
            var apiRoute = baseUrl + "UpdateKH";
            var updateData = CrudService.post(apiRoute, singledata);
            updateData.then(function (res) {
                if (res.data != "") {
                    alert("Cập nhật thành công");
                    $scope.LoadData();
                    $scope.Clear();
                }
            }, function (error) {
                console.log("Lỗi: " + error);
            });
        }
        $("#exampleModal").modal("hide");
    }
    //thực hiện xóa loại sản phẩm
    $scope.DeleteKH = function (dataModel) {
        if (!confirm("Bạn có chắc chắn muốn xóa dữ liệu không?")) {
            return;
        }
        var apiRoute = baseUrl + "DeleteKH";
        var deletedata = CrudService.getbyid(apiRoute, dataModel.MaKH);
        deletedata.then(function (res) {
            if (res.data != "") {
                alert("Xóa thành công");
                $scope.LoadData();
                $scope.Clear();
            }
        }, function (error) {
            console.log("Lỗi: " + error);
        });
        $("#exampleModal").modal("hide");
    }
    //khai báo hàm Clear
    $scope.Clear = function () {
        $scope.MaKH = "";
        $scope.TenKH = "";
        $scope.SDT = "";
        $scope.DiaChi = "";
        $scope.Email = "";
    }
}]);