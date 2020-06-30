using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SellCamera.Models;

namespace SellCamera.Areas.ADMIN.Controllers
{
    public class HopdongsController : Controller
    {
        private SellCameraDataModel db = new SellCameraDataModel();

        
        public ActionResult Index()
        {
            var hopdongs = db.Hopdongs.Include(h => h.Nhacungcap).Include(h => h.Sanpham);
            return View(hopdongs.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hopdong hopdong = db.Hopdongs.Find(id);
            if (hopdong == null)
            {
                return HttpNotFound();
            }
            return View(hopdong);
        }

       
        public ActionResult Create()
        {
            ViewBag.IDNhacungcap = new SelectList(db.Nhacungcaps, "IDNhacungcap", "TenNhaungcap");
            ViewBag.IDSP = new SelectList(db.Sanphams, "MaSP", "TenSP");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDHopdong,IDSP,IDNhacungcap,Ngayky,soluong,tongtien")] Hopdong hopdong)
        {
            if (ModelState.IsValid)
            {
                db.Hopdongs.Add(hopdong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDNhacungcap = new SelectList(db.Nhacungcaps, "IDNhacungcap", "TenNhaungcap", hopdong.IDNhacungcap);
            ViewBag.IDSP = new SelectList(db.Sanphams, "MaSP", "TenSP", hopdong.IDSP);
            return View(hopdong);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hopdong hopdong = db.Hopdongs.Find(id);
            if (hopdong == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDNhacungcap = new SelectList(db.Nhacungcaps, "IDNhacungcap", "TenNhaungcap", hopdong.IDNhacungcap);
            ViewBag.IDSP = new SelectList(db.Sanphams, "MaSP", "TenSP", hopdong.IDSP);
            return View(hopdong);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDHopdong,IDSP,IDNhacungcap,Ngayky,soluong,tongtien")] Hopdong hopdong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hopdong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDNhacungcap = new SelectList(db.Nhacungcaps, "IDNhacungcap", "TenNhaungcap", hopdong.IDNhacungcap);
            ViewBag.IDSP = new SelectList(db.Sanphams, "MaSP", "TenSP", hopdong.IDSP);
            return View(hopdong);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hopdong hopdong = db.Hopdongs.Find(id);
            if (hopdong == null)
            {
                return HttpNotFound();
            }
            return View(hopdong);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hopdong hopdong = db.Hopdongs.Find(id);
            db.Hopdongs.Remove(hopdong);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
