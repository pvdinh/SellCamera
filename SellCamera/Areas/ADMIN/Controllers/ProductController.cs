using SellCamera.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace SellCamera.Areas.ADMIN.Controllers
{
    public class ProductController : Controller
    {
        // GET: ADMIN/Product
        SellCameraDataModel db = new SellCameraDataModel();
        public ActionResult Index()
        {
            var data = db.Sanphams.ToList();
            return View("View", data);
        }
    }
}