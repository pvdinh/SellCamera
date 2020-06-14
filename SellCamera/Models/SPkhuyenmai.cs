namespace SellCamera.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SPkhuyenmai")]
    public partial class SPkhuyenmai
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSPKM { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSP { get; set; }

        public int? Giamgia { get; set; }

        public virtual Khuyenmai Khuyenmai { get; set; }

        public virtual Sanpham Sanpham { get; set; }
    }
}
