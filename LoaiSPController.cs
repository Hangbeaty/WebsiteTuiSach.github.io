using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteTuiSach.Models;

namespace WebsiteTuiSach.Areas.Admin.Controllers
{
    public class LoaiSPController : Controller
    {
        LoaiSanPhamModel dblsp = new LoaiSanPhamModel();
        // GET: Admin/LoaiSP
        public ActionResult Index()
        {
            return View();
        }
        //dich vu lay ve tat ca tin
        public JsonResult GetAllLSP()
        {
            List<LoaiSanPham> li = dblsp.getAllLoaiSP();
            return Json(li, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetOneLSP(string id)
        {
            LoaiSanPham li = dblsp.getOneLSP(id);
            return Json(li, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateLSP(LoaiSanPham x)
        {
            dblsp.CreateLSP(x);
            return Json(new { message = "Thêm mới thành công" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateLSP(LoaiSanPham x)
        {
            dblsp.UpdateLSP(x);
            return Json(new { message = "Cập nhật thành công" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteLSP(string id)
        {
            dblsp.DeleteLSP(id);
            return Json(new { message = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
        }
    }
}