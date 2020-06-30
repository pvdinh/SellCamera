using SellCamera.Models;
using SellCamera.Models.OtherClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SellCamera.Areas.ADMIN.model;

namespace SellCamera.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        SellCameraDataModel db = new SellCameraDataModel();
        Cart cart = new Cart();
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                int MaKH = int.Parse(Session["user"].ToString());
                cart.listInCart = new Cart().LoadCart(MaKH);
                ViewBag.countincart = cart.listInCart.Count();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
        public ActionResult result(Account user, string ghichu, string group2)
        {
            int MaKH = int.Parse(Session["user"].ToString());
            /*cập nhật lại thông tin khách hàng*/
            new Account().Update_Account(user, MaKH);
            /*===================================*/

            /*cập nhật lại thông tin đơn hàng*/
            if (group2 == null)
            {
                TempData["alertcheckout"] = "Bạn chưa chọn phương thức thanh toán";
                TempData["AlertType"] = "alert-warning";
                return RedirectToAction("index", "Checkout");
            }
            else
            {
                new DonhangKH().Checkout(MaKH, ghichu, group2);

                var list = new chitietDH_KH().getID_ctDH(MaKH);

                foreach (var item in list)
                {
                    var max = db.BaoHanhs.OrderByDescending(P => P.Mabaohanh).FirstOrDefault();

                    BaoHanh temp = new BaoHanh();
                    if (max != null)
                    {
                        temp.Mabaohanh = max.Mabaohanh + 1;
                    }
                    else
                    {
                        temp.Mabaohanh = 1;
                    }
                    temp.MaChitietDH = item.MaChitietDH;
                    temp.thoigianbaohanh = "1 NĂM";
                    temp.sTT = 1;
                    temp.Ngayhetbaohanh = DateTime.Now.AddYears(+1);
                    db.BaoHanhs.Add(temp);
                    db.SaveChanges();

                }
            }
            /*===================================*/
            return RedirectToAction("index", "Cart");
        }
    }
}