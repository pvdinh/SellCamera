namespace SellCamera.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaoHanh")]
    public partial class BaoHanh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Mabaohanh { get; set; }

        public int? MaChitietDH { get; set; }

        [StringLength(50)]
        public string thoigianbaohanh { get; set; }

        public int? sTT { get; set; }

        public DateTime? Ngayhetbaohanh { get; set; }

        public virtual ChitietDH ChitietDH { get; set; }
    }
}
