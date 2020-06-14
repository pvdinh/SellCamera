namespace SellCamera.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Thongsokythuat")]
    public partial class Thongsokythuat
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string Thuoctinh { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(150)]
        public string Giatri { get; set; }

        public virtual Sanpham Sanpham { get; set; }
    }
}
