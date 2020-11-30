using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThiKetThucHanhMVC.Models;

namespace ThiKetThucHanhMVC.Controllers
{
    public class ProductsTypeController : Controller
    {
        // GET: ProductsType
        LoaiSanPham lsp = new LoaiSanPham();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllLoaiSanPham()
        {
            IList<LoaiSanPham> List = lsp.GetAllLoaiSanPham();
            return Json(List,JsonRequestBehavior.AllowGet);
        }
    }
}