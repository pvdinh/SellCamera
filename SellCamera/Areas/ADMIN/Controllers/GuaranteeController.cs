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
using System.Data.Entity.Migrations;

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

            //var temp = db.Database.SqlQuery<Account>("USP_timKH @name", new SqlParameter("@name",s)).ToList();

           
            var model = db.Accounts.Where(p => p.Hoten.Contains(s)).ToList();
         
            
             return View("listKH",model);
        }

        public ActionResult status(int? id)
        {
            var model = db.Database.SqlQuery<StatusGuarantee>("USP_baohanh_khachhang @id",new SqlParameter("@id",id)).ToList();

            foreach(var item in model)
            {
                if (item.Ngayhetbaohanh < DateTime.Now)
                {
                    BaoHanh t = new BaoHanh();
                    t.MaChitietDH = item.MaChitietDH;
                    t.Mabaohanh = item.Mabaohanh;                 
                    t.sTT = 0;
                    t.thoigianbaohanh = "";
                    t.Ngayhetbaohanh = item.Ngayhetbaohanh;
                    db.BaoHanhs.AddOrUpdate(t);
                    db.SaveChanges();
                }
            }
            model = db.Database.SqlQuery<StatusGuarantee>("USP_baohanh_khachhang @id", new SqlParameter("@id", id)).ToList();
            return View("status",model);
        }

        public ActionResult Del(int? id)
        {
            var temp = db.ChitietDHs.Where(p => p.MaChitietDH == id).FirstOrDefault();
            db.ChitietDHs.Remove(temp);
            db.SaveChanges();
            return View("Index");
        }
    }
}