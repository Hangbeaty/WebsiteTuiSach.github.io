using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteTuiSach.Models
{
    public class CTDonDatHang
    {
        public string MaCTDonDatHang { get; set; }
        public string MaDonHang { get; set; }
        public string MaCTHoaDonNhap { get; set; }
        public string MaSP { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
    }
}