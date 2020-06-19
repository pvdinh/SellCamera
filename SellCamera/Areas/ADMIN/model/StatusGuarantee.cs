using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellCamera.Areas.ADMIN.model
{
    public class StatusGuarantee
    {
        public string Hoten {get;set;}
        public string Phonenumber{get;set;}
        public DateTime Ngaydatmua{ get; set; }
        public string TenSP{ get; set; }
        public int Soluong { get; set; }
        public int sTT { get; set; }
    }
}