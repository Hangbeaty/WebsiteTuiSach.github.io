using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebsiteTuiSach.Models;

namespace WebsiteTuiSach.Models
{
    public class SanPhamModel
    {
        //lấy ra tất cả các sản phẩm trong bảng sản phẩm -->Viết 1 hàm thực hiện thao tác lấy sp
        //khởi tạo đối tượng dataconnect
        DataConnect dc = new DataConnect();
        public List<SanPham> getAllSP()
        {
            DataTable dt = dc.getData("select * from SanPham");
            List<SanPham> li = new List<SanPham>();
            //đưa dữ liệu trong datatable vào list
            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaSP = dr[0].ToString();
                sp.TenSP = dr[1].ToString();
                sp.MaLoaiSP = dr[2].ToString();
                sp.DonGia = int.Parse(dr[3].ToString());
                sp.MoTa = dr[4].ToString();
                sp.HinhAnh = dr[5].ToString();
                sp.Size = dr[6].ToString();
                sp.MauSac = dr[7].ToString();
                li.Add(sp);
            }
            return li;
        }

        public SanPham get1SP(string id)
        {
            SanPham sp = new SanPham();
            DataTable dt = dc.getData("select * from SanPham where MaSP='" + id + "'");
            sp.MaSP = dt.Rows[0][0].ToString();
            sp.TenSP = dt.Rows[0][1].ToString();
            sp.MaLoaiSP = dt.Rows[0][2].ToString();
            sp.DonGia = int.Parse(dt.Rows[0][3].ToString());
            sp.MoTa = dt.Rows[0][4].ToString();
            sp.HinhAnh = dt.Rows[0][5].ToString();
            sp.Size = dt.Rows[0][6].ToString();
            sp.MauSac = dt.Rows[0][7].ToString();
            return sp;
        }
        public List<SanPham> getSPByLoaiSP(string id)
        {
            List<SanPham> li = new List<SanPham>();
            DataTable dt = dc.getData("Select * from SanPham where MaLoaiSP='" + id + "'");
            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaSP = dr[0].ToString();
                sp.TenSP = dr[1].ToString();
                sp.MaLoaiSP = dr[2].ToString();
                sp.DonGia = int.Parse(dr[3].ToString());
                sp.MoTa = dr[4].ToString();
                sp.HinhAnh = dr[5].ToString();
                sp.Size = dr[6].ToString();
                sp.MauSac = dr[7].ToString();
                li.Add(sp);
            }
            return li;
        }
        
        
        public void CreateSP(SanPham x)
        {
            string sql = "insert into SanPham values('" + x.MaSP + "', N'" + x.TenSP + "', N'" + x.MaLoaiSP + "', N'" + x.DonGia + "', N'" + x.MoTa + "', N'" + x.HinhAnh + "', N'" + x.Size + "', N'" + x.MauSac + "')";
            dc.writeData(sql);
        }
        public void UpdateSP(SanPham x)
        {
            string sql = "update SanPham set TenSP=N'" + x.TenSP + "', MaLoaiSP=N'" + x.MaLoaiSP + "', DonGia=N'" + x.DonGia + "', MoTa=N'" + x.MoTa + "', HinhAnh=N'" + x.HinhAnh + "', Size=N'" + x.Size + "', MauSac=N'" + x.MauSac + "' where MaSP='" + x.MaSP + "'";
            dc.writeData(sql);
        }
        public void DeleteSP(string id)
        {
            string sql = "delete from SanPham where MaSP='" + id + "'";
            dc.writeData(sql);
        }
        public void SearchName(string tensp)
        {
            string sql = "SELECT * FROM SanPham WHERE (TenSP like N'%" + tensp + "%')";
            dc.writeData(sql);
        }
    }
}