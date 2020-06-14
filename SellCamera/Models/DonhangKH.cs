namespace SellCamera.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonhangKH")]
    public partial class DonhangKH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonhangKH()
        {
            ChitietDHs = new HashSet<ChitietDH>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDH { get; set; }

        public int MaKH { get; set; }

        public double? Phivanchuyen { get; set; }

        [Required]
        [StringLength(50)]
        public string PhuongthucTT { get; set; }

        public DateTime Ngaydatmua { get; set; }

        public double? TongTien { get; set; }

        public int? Tinhtrangdonhang { get; set; }

        [StringLength(100)]
        public string ghichu { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChitietDH> ChitietDHs { get; set; }
    }
}
