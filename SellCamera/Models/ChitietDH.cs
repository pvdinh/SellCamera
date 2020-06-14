namespace SellCamera.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChitietDH")]
    public partial class ChitietDH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChitietDH()
        {
            BaoHanhs = new HashSet<BaoHanh>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaChitietDH { get; set; }

        public int? MaDH { get; set; }

        public int? MaSP { get; set; }

        public int? Soluong { get; set; }

        public double? Thanhtien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaoHanh> BaoHanhs { get; set; }

        public virtual DonhangKH DonhangKH { get; set; }

        public virtual Sanpham Sanpham { get; set; }
    }
}
