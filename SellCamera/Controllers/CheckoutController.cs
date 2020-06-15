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
    public class CheckoutController : Controller
    {
        // GET: Checkout
        SellCameraDataModel db = new SellCameraDataModel();
        Cart cart = new Cart();
        public ActionResult Index()
        {
            Session["user"] = 1001;
            int MaKH = int.Parse(Session["user"].ToString());
            cart.listInCart = new Cart().LoadCart(MaKH);
            ViewBag.countincart = cart.listInCart.Count();
            return View();
        }
        public ActionResult Cart()
        {
            int MaKH = int.Parse(Session["user"].ToString());
            cart.listInCart = new Cart().LoadCart(MaKH);
            return PartialView("_ViewCart", cart.listInCart);
        }
        public ActionResult InfoCustomer()
        {
            int MaKH = int.Parse(Session["user"].ToString());
            Account User = db.Accounts.Where(s => s.IDAccount == MaKH).FirstOrDefault();
            return PartialView("_ViewInfoCustomer", User);
        }
        [HttpPost]
        public ActionResult result(Account user, string group2)
        {
            int MaKH = int.Parse(Session["user"].ToString());
            /*cập nhật lại thông tin khách hàng*/
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("Hoten",user.Hoten),
                new SqlParameter("Email",user.Email),
                new SqlParameter("Phonenumber",user.Phonenumber),
                new SqlParameter("address",user.Address),
                new SqlParameter("idKH",MaKH)
            };
            db.Database.ExecuteSqlCommand("update_checkout_user @Hoten,@Email,@Phonenumber,@address,@idKH", param);
            /*===================================*/
            return RedirectToAction("index", "Cart");
        }
    }
}