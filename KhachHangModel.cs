using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebsiteTuiSach.Models
{
    public class KhachHangModel
    {
        DataConnect dc = new DataConnect();
        public List<KhachHang> getAllKH()
        {
            List<KhachHang> li = new List<KhachHang>();
            DataTable dt = dc.getData("Select * from KhachHang");
            foreach (DataRow dr in dt.Rows)
            {
                KhachHang kh = new KhachHang();
                kh.MaKH = dr[0].ToString();
                kh.TenKH = dr[1].ToString();
                kh.SDT = dr[2].ToString();
                kh.DiaChi = dr[3].ToString();
                kh.Email = dr[4].ToString();
                li.Add(kh);
            }
            return li;
        }
        public KhachHang getOneKH(string id)
        {
            KhachHang li = new KhachHang();
            DataTable dt = dc.getData("Select * from KhachHang where MaKH='" + id + "'");
            li.MaKH = dt.Rows[0][0].ToString();
            li.TenKH = dt.Rows[0][1].ToString();
            li.SDT = dt.Rows[0][2].ToString();
            li.DiaChi = dt.Rows[0][3].ToString();
            li.Email = dt.Rows[0][4].ToString();
            return li;
        }
        public void CreateKH(KhachHang x)
        {
            string sql = "insert into KhachHang values('" + x.MaKH + "', N'" + x.TenKH + "', N'" + x.SDT + "', N'" + x.DiaChi + "', N'" + x.Email + "')";
            dc.writeData(sql);
        }
        public void UpdateKH(KhachHang x)
        {
            string sql = "update KhachHang set TenKH=N'" + x.TenKH + "', SDT=N'" + x.SDT + "', DiaChi=N'" + x.DiaChi + "', Email=N'" + x.Email + "' where MaKH='" + x.MaKH + "'";
            dc.writeData(sql);
        }
        public void DeleteKH(string id)
        {
            string sql = "delete from KhachHang where MaKH='" + id + "'";
            dc.writeData(sql);
        }
        
    }
}