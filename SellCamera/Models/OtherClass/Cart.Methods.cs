using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SellCamera.Models;

namespace SellCamera.Models.OtherClass
{
    public partial class Cart
    {
        public SellCameraDataModel db = new SellCameraDataModel();
        public void Init(int idKh)
        {
            DonhangKH x = new DonhangKH();
            x.MaDH = db.DonhangKHs.OrderByDescending(s=>s.MaDH).Select(s=>s.MaDH).FirstOrDefault() + 1;
            x.MaKH = idKh;
            x.Phivanchuyen = 0;
            x.PhuongthucTT = "NULL";
            x.TongTien = 0;
            x.Ngaydatmua = DateTime.Now;
            x.Tinhtrangdonhang = 0;
            x.ghichu = null;
            db.DonhangKHs.Add(x);
            db.SaveChanges();
        }
        public List<Cart> LoadCart(int idKh)
        {
            if (db.DonhangKHs.Where(s => s.MaKH == idKh && s.Tinhtrangdonhang == 0).FirstOrDefault() == null)
            {
                Init(idKh);
            }
            return db.Database.SqlQuery<Cart>("Load_Cart @idKH", new SqlParameter("@idKH", idKh)).ToList();
        }
        public void add(int MaSP, int idKH)
        {
            var Sp = db.Sanphams.Where(s => s.MaSP == MaSP).FirstOrDefault(); //lấy giá của sản phẩm
            var Dhkh = db.DonhangKHs.Where(s => s.MaKH == idKH && s.Tinhtrangdonhang == 0).FirstOrDefault(); //trường hợp cart trống hoàn toàn sẽ lấy mã đơn hàng để tạo mới chi tiết đơn hàng
            List<Cart> list = new Cart().LoadCart(idKH); //dành cho trường hợp cart có sản phẩm trước đó
            if (list.Where(s => s.MaSP == MaSP).FirstOrDefault() != null)
            {
                //Nếu sản phẩm đã có trong giỏ hàng thì tăng sl lên 1 và giảm số lượng trong kho đi 1
                int MaDH = list[0].MaDH;
                var x = db.ChitietDHs.Where(s => s.MaSP == MaSP && s.MaDH == MaDH).FirstOrDefault();
                x.Soluong += 1;
                x.Thanhtien += x.Thanhtien;
                //===================================================================================
                var y = db.Sanphams.Where(s => s.MaSP == MaSP).FirstOrDefault();
                y.SoLuong -= 1;
                if(y.SoLuong < 0)
                {
                    y.SoLuong = 0;
                    x.Soluong -= 1;
                }
                db.SaveChanges();
            }
            else
            {
                ChitietDH ct = new ChitietDH();
                ct.MaChitietDH = db.ChitietDHs.OrderByDescending(s => s.MaChitietDH).Select(s => s.MaChitietDH).FirstOrDefault() + 1;
                ct.MaDH = Dhkh.MaDH;
                ct.MaSP = MaSP;
                ct.Soluong = 1;
                ct.Thanhtien = Sp.Gia;
                db.ChitietDHs.Add(ct);
                //giảm số lượng trong kho đi 1
                var y = db.Sanphams.Where(s => s.MaSP == MaSP).FirstOrDefault();
                y.SoLuong -= 1;      
                db.SaveChanges();
            }
        }
        public void subtract(int MaSP, int idKH)
        {
            List<Cart> list = new Cart().LoadCart(idKH); // load danh sách sản phẩm trong giỏ hàng
            int MaDH = list[0].MaDH;
            var x = db.ChitietDHs.Where(s => s.MaSP == MaSP && s.MaDH == MaDH).FirstOrDefault(); //tìm chi tiết đơnn hàng của sản phẩm
            if (x.Soluong > 1)
            {
                x.Soluong -= 1;
                x.Thanhtien -= x.Thanhtien;
                var y = db.Sanphams.Where(s => s.MaSP == MaSP).FirstOrDefault();
                y.SoLuong += 1; //tăng số lượng trong kho lên 1
                db.SaveChanges();
            }
            else
            {
                x.Soluong = 1;
                db.SaveChanges();
            }
        }
        public void delete(int MaSP, int idKH)
        {
            List<Cart> list = new Cart().LoadCart(idKH); //load danh sách sản phẩm
            int MaDH = list[0].MaDH;
            var x = db.ChitietDHs.Where(s => s.MaSP == MaSP && s.MaDH == MaDH).FirstOrDefault(); //tìm chi tiết đơnn hàng của sản phẩm
            db.ChitietDHs.Remove(x);
            var y = db.Sanphams.Where(s => s.MaSP == MaSP).FirstOrDefault();
            y.SoLuong += x.Soluong; //tăng số lượng sp trong kho bằng số lượng sp đã xoá đi
            db.SaveChanges();
        }

        public double? Total(int idKH)
        {
            double? Total=0;
            List<Cart> list = new Cart().LoadCart(idKH); //load danh sách sản phẩm
            foreach(var item in list)
            {
                if(item.Giamgia != null)
                {
                    Total += item.giamoi * item.Soluong;
                }
                else
                {
                    Total += item.Gia * item.Soluong;
                }
            }
            return Total;
        }
    }
}