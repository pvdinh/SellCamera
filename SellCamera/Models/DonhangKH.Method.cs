using SellCamera.Models.OtherClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SellCamera.Models
{
    public partial class DonhangKH
    {
        SellCameraDataModel db = new SellCameraDataModel();
        public void Checkout(int idKH,string ghichu,string pptt)
        {
            double pvc = 0;
            int ttdh = 1;
            int idDH = db.DonhangKHs.Where(s => s.MaKH == idKH && s.Tinhtrangdonhang==0).Select(s => s.MaDH).FirstOrDefault();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@phivanchuyen",pvc),
                new SqlParameter("@phuongthuctt",pptt),
                new SqlParameter("@ngaydatmua",DateTime.Now),
                new SqlParameter("@tongtien",new Cart().Total(idKH)),
                new SqlParameter("@tinhtrangdonhang",ttdh),
                new SqlParameter("@ghichu",ghichu),
                new SqlParameter("@idDH",idDH)
            };
            db.Database.ExecuteSqlCommand("update_donhangKH @phivanchuyen,@phuongthuctt,@ngaydatmua,@tongtien,@tinhtrangdonhang,@ghichu,@idDH", param);
        }
    }
}