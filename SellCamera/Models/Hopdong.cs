namespace SellCamera.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hopdong")]
    public partial class Hopdong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Hợp Đồng")]
        public int IDHopdong { get; set; }
        [Required]
        [DisplayName("Mã Sản Phẩm")]
        public int IDSP { get; set; }
        [Required]
        [DisplayName("Mã NCC")]
        public int IDNhacungcap { get; set; }
        [Required]
        [DisplayName("Ngày Ký")]
        public DateTime? Ngayky { get; set; }
        [Required]
        [DisplayName("Số Lượng")]
        public int? soluong { get; set; }
        [Required]
        [DisplayName("Tổng Tiền")]
        public double? tongtien { get; set; }


        

        public virtual Nhacungcap Nhacungcap { get; set; }

        public virtual Sanpham Sanpham { get; set; }
    }
}
