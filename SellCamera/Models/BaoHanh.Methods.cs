using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellCamera.Models
{
    public partial class BaoHanh
    {
        public SellCameraDataModel db = new SellCameraDataModel();
        public int add(BaoHanh temp)
        {
            db.BaoHanhs.Add(temp);
            db.SaveChanges();
            return temp.Mabaohanh;
        }
    }
}