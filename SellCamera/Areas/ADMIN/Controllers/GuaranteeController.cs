using SellCamera.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SellCamera.Areas.ADMIN.model;
using SellCamera.Models;

namespace SellCamera.Areas.ADMIN.Controllers
{
    public class GuaranteeController : Controller
    {

        SellCameraDataModel db = new SellCameraDataModel();
        // GET: ADMIN/Guarantee
        
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Index(int? id)
        {
            string s = Request.Form["name"];
            var temp = db.Database.SqlQuery<Account>("USP_timKH @name", new SqlParameter("@name",s)).ToList();
            List<Account> model = new List<Account>();
            model = temp;
             return View("listKH",model);
        }

        public ActionResult status(int? id)
        {
            var temp = db.Database.SqlQuery<StatusGuarantee>("USP_baohanh_khachhang @id",new SqlParameter("@id",id)).ToList();
            List<StatusGuarantee> model = new List<StatusGuarantee>();
            model = temp;
            return View("status",model);
        }
    }
}