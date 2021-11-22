using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebsiteTuiSach.Models
{
    public class LoaiSanPhamModel
    {
        DataConnect dc = new DataConnect();
        public List<LoaiSanPham> getAllLoaiSP()
        {
            List<LoaiSanPham> li = new List<LoaiSanPham>();
            DataTable dt = dc.getData("Select * from LoaiSanPham");
            foreach (DataRow dr in dt.Rows)
            {
                LoaiSanPham lsp = new LoaiSanPham();
                lsp.MaLoaiSP = dr[0].ToString();
                lsp.TenLoaiSP = dr[1].ToString();
                lsp.GhiChu = dr[2].ToString();
                li.Add(lsp);
            }
            return li;
        }
        public LoaiSanPham getOneLSP(string id)
        {
            LoaiSanPham li = new LoaiSanPham();
            DataTable dt = dc.getData("Select * from LoaiSanPham where MaloaiSP='" + id + "'");
            li.MaLoaiSP = dt.Rows[0][0].ToString();
            li.TenLoaiSP = dt.Rows[0][1].ToString();
            li.GhiChu = dt.Rows[0][2].ToString();
            return li;
        }
        public void CreateLSP(LoaiSanPham x)
        {
            string sql = "insert into LoaiSanPham values('" + x.MaLoaiSP + "', N'" + x.TenLoaiSP + "', N'" + x.GhiChu + "')";
            dc.writeData(sql);
        }
        public void UpdateLSP(LoaiSanPham x)
        {
            string sql = "update LoaiSanPham set TenLoai=N'" + x.TenLoaiSP + "', GhiChu=N'" + x.GhiChu + "' where MaLoaiSP='" + x.MaLoaiSP + "'";
            dc.writeData(sql);
        }
        public void DeleteLSP(string id)
        {
            string sql = "delete from LoaiSanPham where MaLoaiSP='" + id + "'";
            dc.writeData(sql);
        }
        public void SearchName(string tensp)
        {
            string sql = "SELECT * FROM LoaiSanPham WHERE (TenLoaiSP like N'%" + tensp + "%')";
            dc.writeData(sql);
        }
    }
}