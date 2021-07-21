namespace ModelEF.ModelDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short IdHd { get; set; }

        [Key]
        [StringLength(6)]
        public string MaHD { get; set; }

        [Required]
        [StringLength(6)]
        public string MaKH { get; set; }

        [Required]
        [StringLength(6)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(6)]
        public string MaODo { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLap { get; set; }

        public DateTime? ThoiGianVao { get; set; }

        public DateTime? ThoiGianRaDuKien { get; set; }

        public DateTime? ThoiGianRa { get; set; }

        public decimal? TienPhat { get; set; }

        public decimal? ThanhTienDuKien { get; set; }

        public decimal? TongTien { get; set; }

        public DateTime? NgayBatDauApDung { get; set; }

        public DateTime? HanCuoiHetPhi { get; set; }

        public decimal? Discount { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual ODo ODo { get; set; }
    }
}
