namespace SellCamera.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sanpham")]
    public partial class Sanpham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sanpham()
        {
            Binhluans = new HashSet<Binhluan>();
            ChitietDHs = new HashSet<ChitietDH>();
            Hopdongs = new HashSet<Hopdong>();
            SPkhuyenmais = new HashSet<SPkhuyenmai>();
            Thongsokythuats = new HashSet<Thongsokythuat>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSP { get; set; }

        [StringLength(500)]
        public string TenSP { get; set; }

        public int LoaiSP { get; set; }

        public int HangSX { get; set; }

        [Required]
        [StringLength(50)]
        public string Xuatxu { get; set; }

        public double Gia { get; set; }

        [StringLength(100)]
        public string Mota { get; set; }

        [StringLength(500)]
        public string Anh { get; set; }

        public int? Isnew { get; set; }

        public int? Ishot { get; set; }

        public int? SoLuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Binhluan> Binhluans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChitietDH> ChitietDHs { get; set; }

        public virtual HangSX HangSX1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hopdong> Hopdongs { get; set; }

        public virtual LoaiSP LoaiSP1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPkhuyenmai> SPkhuyenmais { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Thongsokythuat> Thongsokythuats { get; set; }
    }
}
