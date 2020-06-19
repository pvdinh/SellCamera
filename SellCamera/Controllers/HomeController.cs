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
        public ActionResult Index()
        {
            Session["user"] = 1003;
            return View();
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