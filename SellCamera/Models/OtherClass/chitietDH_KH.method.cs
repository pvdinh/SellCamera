using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace SellCamera.Models.OtherClass
{
    public partial class chitietDH_KH
    {
        SellCameraDataModel db = new SellCameraDataModel();
        public List<ChitietDH> getID_ctDH(int id)
        {          
            var DH = db.DonhangKHs.Where(p=>p.MaKH==id && p.Ngaydatmua>DateTime.Today).FirstOrDefault();
            var list1 = db.ChitietDHs.Where(p=>p.MaDH==DH.MaDH).ToList();
            return list1;
        }
    }
}