using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteTuiSach.Models;

namespace WebsiteTuiSach.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        SanPhamModel dbsp = new SanPhamModel();
        // GET: Admin/SanPham
        public ActionResult Index()
        {
            return View();
        }
        //dich vu lay ve tat ca tin
        public JsonResult getAllSP()
        {
            List<SanPham> li = dbsp.getAllSP();
            return Json(li, JsonRequestBehavior.AllowGet);
        }
        public JsonResult get1SP(string id)
        {
            SanPham li = dbsp.get1SP(id);
            return Json(li, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateSP(SanPham x)
        {
            dbsp.CreateSP(x);
            return Json(new { message = "Thêm mới thành công" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateSP(SanPham x)
        {
            dbsp.UpdateSP(x);
            return Json(new { message = "Cập nhật thành công" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteSP(string id)
        {
            dbsp.DeleteSP(id);
            return Json(new { message = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
        }
    }
}