using SellCamera.Models;
using SellCamera.Models.OtherClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SellCamera.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        SellCameraDataModel db = new SellCameraDataModel();
        public ActionResult Index(int? id)
        {
            Session["id"] = id;

            var spkm = db.SPkhuyenmais.Where(s => s.MaSP == id).FirstOrDefault();
            if (spkm != null)
            {
                var ttkm = db.Khuyenmais.Where(s => s.MaKM == spkm.MaSPKM).FirstOrDefault();
                if (ttkm != null)
                    ViewBag.ttkm = ttkm;
            }
            InfoProduct data = new InfoProduct();
            //List<InfoProduct> model = new List<InfoProduct>();
            if (data.MaSP == id)
            {
                data = db.Database.SqlQuery<InfoProduct>("get_product_discount").FirstOrDefault();
            }
            //kiểm tra hàng còn hay không
            var status = db.Sanphams.Where(s => s.MaSP == id).Select(s => s.SoLuong).FirstOrDefault();
            ViewBag.status = status;
            return View(data);
        }
    }
}