using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteTuiSach.Models;

namespace WebsiteTuiSach.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: Admin/KhachHang
        KhachHangModel dbkh = new KhachHangModel();
        // GET: Admin/SanPham
        public ActionResult Index()
        {
            return View();
        }
        //dich vu lay ve tat ca tin
        public JsonResult getAllKH()
        {
            List<KhachHang> li = dbkh.getAllKH();
            return Json(li, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getOneKH(string id)
        {
            KhachHang li = dbkh.getOneKH(id);
            return Json(li, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateKH(KhachHang x)
        {
            dbkh.CreateKH(x);
            return Json(new { message = "Thêm mới thành công" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateKH(KhachHang x)
        {
            dbkh.UpdateKH(x);
            return Json(new { message = "Cập nhật thành công" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteKH(string id)
        {
            dbkh.DeleteKH(id);
            return Json(new { message = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
        }
    }
}