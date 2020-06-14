namespace SellCamera.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nhacungcap")]
    public partial class Nhacungcap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nhacungcap()
        {
            Hopdongs = new HashSet<Hopdong>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDNhacungcap { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNhaungcap { get; set; }

        [Required]
        [StringLength(15)]
        public string phonenumber { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hopdong> Hopdongs { get; set; }
    }
}
