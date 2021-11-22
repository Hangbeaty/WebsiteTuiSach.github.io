MyApp.controller("SanPhamController", ['$scope', 'CrudService', function ($scope, CrudService) {
    //khai báo các xử lý cho controller
    //khai báo các giá trị khởi tạo ban đầu
    var baseUrl = "/Admin/SanPham/";
    $scope.MaSP = "";
    $scope.TenSP = "";
    $scope.MaLoaiSP = "";
    $scope.DonGia = "";
    $scope.MoTa = "";
    $scope.HinhAnh = "";
    $scope.Size = "";
    $scope.MauSac = "";
    $scope.btnText = "Thêm";
    //xây dựng hàm lấy về các bản ghi trong đối tượng  SP
    $scope.LoadData = function () {
        var apiRoute = baseUrl + "getAllSP";
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
        var apiRoute = baseUrl + "get1SP";
        var oneLSP = CrudService.getbyid(apiRoute, s.MaSP);
        oneLSP.then(function (res) {
            $scope.MaSP = res.data.MaSP;
            $scope.TenSP = res.data.TenSP;
            $scope.MaLoaiSP = res.data.MaLoaiSP;
            $scope.DonGia = res.data.DonGia;
            $scope.MoTa = res.data.MoTa;
            $scope.HinhAnh = res.data.HinhAnh;
            $scope.Size = res.data.Size;
            $scope.MauSac = res.data.MauSac;
            $scope.btnText = "Sửa";
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
    //Viết hàm thực hiện thêm mới một sản phẩm
    $scope.SaveUpdate = function () {
        //khai báo một bản ghi
        var singledata = {
            MaSP: $scope.MaSP,
            TenSP: $scope.TenSP,
            MaLoaiSP: $scope.MaLoaiSP,
            DonGia: $scope.DonGia,
            MoTa: $scope.MoTa,
            HinhAnh: $scope.HinhAnh,
            Size: $scope.Size,
            MauSac: $scope.MauSac,          
        };
        if ($scope.btnText == "Thêm") {
            //thực hiện thao tác thêm loại sản phẩm
            var apiRoute = baseUrl + "CreateSP";
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
            var apiRoute = baseUrl + "UpdateSP";
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
    $scope.DeleteSP = function (dataModel) {
        if (!confirm("Bạn có chắc chắn muốn xóa dữ liệu không?")) {
            return;
        }
        var apiRoute = baseUrl + "DeleteSP";
        var deletedata = CrudService.getbyid(apiRoute, dataModel.MaSP);
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
        $scope.MaSP = "";
        $scope.TenSP = "";
        $scope.MaLoaiSP = "";
        $scope.DonGia = "";
        $scope.MoTa = "";
        $scope.HinhAnh = "";
        $scope.Size = "";
        $scope.MauSac = "";
    }
}]);