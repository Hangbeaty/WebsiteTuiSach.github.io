using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebsiteTuiSach.Models
{
    public class TinTucModel
    {
        DataConnect dc = new DataConnect();
        public List<TinTuc> getAllTT()
        {
            DataTable dt = dc.getData("select * from TinTuc");
            List<TinTuc> li = new List<TinTuc>();
            //đưa dữ liệu trong datatable vào list
            foreach (DataRow dr in dt.Rows)
            {
                TinTuc tt = new TinTuc();
                tt.Id = dr[0].ToString();
                tt.TieuDe = dr[1].ToString();
                tt.HinhAnh = dr[2].ToString();
                tt.NoiDung = dr[3].ToString();
                tt.NgayDang = dr[4].ToString();
                tt.TrangThai = dr[5].ToString();                
                li.Add(tt);
            }
            return li;
        }
        public TinTuc get1TT(string id)
        {
            TinTuc tt = new TinTuc();
            DataTable dt = dc.getData("select * from TinTuc where Id='" + id + "'");
            tt.Id = dt.Rows[0][0].ToString();
            tt.TieuDe = dt.Rows[0][1].ToString();
            tt.HinhAnh = dt.Rows[0][2].ToString();
            tt.NoiDung = dt.Rows[0][3].ToString();
            tt.NgayDang = dt.Rows[0][4].ToString();
            tt.TrangThai = dt.Rows[0][5].ToString();           
            return tt;
        }
    }
}