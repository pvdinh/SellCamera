namespace SellCamera.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hopdong")]
    public partial class Hopdong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDHopdong { get; set; }

        public int IDSP { get; set; }

        public int IDNhacungcap { get; set; }

        public DateTime? Ngayky { get; set; }

        public int? soluong { get; set; }

        public double? tongtien { get; set; }

        public virtual Nhacungcap Nhacungcap { get; set; }

        public virtual Sanpham Sanpham { get; set; }
    }
}
