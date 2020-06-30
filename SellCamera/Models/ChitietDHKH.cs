using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SellCamera.Models
{
    public class ChitietDHKH
    {
        SellCameraDataModel db = new SellCameraDataModel();
        public List<ChitietDH> getID_ctDH(Account acc)
        {
            List<ChitietDH> list1 = new List<ChitietDH>();
            list1 = db.Database.SqlQuery<ChitietDH>("USP_chitietDH @id", new SqlParameter("@id", acc.IDAccount)).ToList();
            return list1;
        }      
    }
}