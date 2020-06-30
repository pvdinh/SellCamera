using SellCamera.Models;
using SellCamera.Models.OtherClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellCamera.Controllers
{
    public class HomeController : Controller
    {
        SellCameraDataModel db = new SellCameraDataModel();
        Cart cart = new Cart();
        List<InfoProduct> data = new List<InfoProduct>();
        public ActionResult Index()
        {
            Session["user"] = 1006;
            return View();
        }
        public ActionResult ViewListProduct()
        {
            Session["count"] = 12; //kiểm soát số lượng hiển thị sản phẩm
            Session["temp"] = 1;  //trạng thái phát hiện đang ở loại sp nào
            data = db.Database.SqlQuery<InfoProduct>("get_product_discount").ToList();
            data.Where(s => s.LoaiSP == 2222).Take(8).ToList();
            return PartialView("_ViewProduct", data);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult HistoryOrder()
        {
            if(Session["user"] != null)
            {
                int MaKH = int.Parse(Session["user"].ToString());
                //lấy lịch sử order
                List<HistoryOrder> list = db.Database.SqlQuery<HistoryOrder>("history_order @idKH", new SqlParameter("@idKH", MaKH)).OrderByDescending(s=>s.MaDH).ToList();
                ViewBag.countinhistory = list.Count();
                ViewBag.data = list;
                //lấy lịch sử sản phẩm đã order
                cart.listInCart = db.Database.SqlQuery<Cart>("Load_Cart_History @idKH", new SqlParameter("@idKH", MaKH)).ToList();
                return View(cart.listInCart);
            }
            else
            {
                ViewBag.countinhistory = 0;
                return View();
            }
        }

    }
}