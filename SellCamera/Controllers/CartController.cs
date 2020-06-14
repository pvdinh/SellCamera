﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SellCamera.Models.OtherClass;
using SellCamera.Models;

namespace SellCamera.Controllers
{
    public class CartController : Controller
    {

        // GET: Cart
        SellCameraDataModel db = new SellCameraDataModel();
        Cart cart = new Cart();
        public ActionResult Index(int? MaSP)
        {
            Session["user"] = 1001;
            int MaKH = int.Parse(Session["user"].ToString());
            cart.listInCart = new Cart().LoadCart(MaKH);
            if (MaSP != null)
            {
                cart.add((int)MaSP, MaKH);
            }
            ViewBag.countincart = cart.listInCart.Count();
            return View();
        }

        public ActionResult Cart()
        {
            int MaKH = int.Parse(Session["user"].ToString());
            cart.listInCart = new Cart().LoadCart(MaKH);
            return PartialView("_ViewCart", cart.listInCart);
        }
        public ActionResult add(int MaSP)
        {
            int MaKH = int.Parse(Session["user"].ToString());
            cart.add(MaSP, MaKH);
            cart.listInCart = new Cart().LoadCart(MaKH);
            return PartialView("_ViewCart", cart.listInCart);
        }
        public ActionResult subtract(int MaSP)
        {
            int MaKH = int.Parse(Session["user"].ToString());
            cart.subtract(MaSP, MaKH);
            cart.listInCart = new Cart().LoadCart(MaKH);
            return PartialView("_ViewCart", cart.listInCart);
        }
        public ActionResult delete(int MaSP)
        {
            int MaKH = int.Parse(Session["user"].ToString());
            cart.delete(MaSP, MaKH);
            cart.listInCart = new Cart().LoadCart(MaKH);
            return PartialView("_ViewCart", cart.listInCart);
        }
        public ActionResult ProductOther()
        {
            List<InfoProduct> list = new List<InfoProduct>();
            list = db.Database.SqlQuery<InfoProduct>("get_product_discount").ToList();
            list = list.OrderBy(s => Guid.NewGuid()).Take(4).ToList();
            return PartialView("_ViewProductOther", list);
        }
    }
}