using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteTuiSach.Models
{
    public class HoaDonNhap
    {
        public string MaHoaDonNhap { get; set; }
        public DateTime NgayNhap { get; set; }
        public string MaNCC { get; set; }
        public int TongTien { get; set; }
    }
}