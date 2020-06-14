using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellCamera.Models.OtherClass
{
    public class InfoProduct
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int LoaiSP { get; set; }
        public string TenLoai { get; set; }
        public int HangSX { get; set; }
        public string Anh { get; set; }
        public Nullable<int> Isnew { get; set; }
        public Nullable<int> Ishot { get; set; }
        public string tenhang { get; set; }
        public double Gia { get; set; }
        public Nullable<int> Giamgia { get; set; }
        public Nullable<double> giá_mới { get; set; }
    }
}