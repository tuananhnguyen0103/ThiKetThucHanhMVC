using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThiKetThucHanhMVC.Models;

namespace ThiKetThucHanhMVC.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        SanPham sp = new SanPham();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllSanPham(string loai)
        {
            IList<SanPham> List = sp.GetAllSanPham(loai);
            return Json(List, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewLoaiSanPham()
        {
            return View();
        }
    }
}