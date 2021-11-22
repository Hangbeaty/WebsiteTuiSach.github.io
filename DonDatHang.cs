using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteTuiSach.Models
{
    public class DonDatHang
    {
        public string MaHoaDon { get; set; }
        public string MaKH { get; set; }
        public string DiaChiNhan { get; set; }
        public string SDTNhan { get; set; }
        public string TinhTrang { get; set; }
        public string ThanhTien { get; set; }
        public DateTime NgayGiao { get; set; }
        public DateTime NgayNhan { get; set; }
        
    }
}