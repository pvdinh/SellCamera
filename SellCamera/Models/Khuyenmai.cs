namespace SellCamera.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Khuyenmai")]
    public partial class Khuyenmai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Khuyenmai()
        {
            SPkhuyenmais = new HashSet<SPkhuyenmai>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaKM { get; set; }

        public DateTime Ngaybatdau { get; set; }

        public DateTime Ngayketthuc { get; set; }

        [StringLength(400)]
        public string noidung { get; set; }

        [StringLength(100)]
        public string ten { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPkhuyenmai> SPkhuyenmais { get; set; }
    }
}
