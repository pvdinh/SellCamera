namespace SellCamera.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Binhluan")]
    public partial class Binhluan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaBL { get; set; }

        public int MaSP { get; set; }

        public int? MaKH { get; set; }

        [StringLength(500)]
        public string Noidung { get; set; }

        public DateTime Ngaydang { get; set; }

        [Required]
        [StringLength(50)]
        public string Hoten { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public virtual Account Account { get; set; }

        public virtual Sanpham Sanpham { get; set; }
    }
}
