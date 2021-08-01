namespace ModelEF.ModelDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatCho")]
    public partial class DatCho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DatCho()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short IdDatCho { get; set; }

        [Key]
        [StringLength(6)]
        public string MaDatCho { get; set; }

        [Required]
        [StringLength(6)]
        public string MaODo { get; set; }

        [Required]
        [StringLength(6)]
        public string MaKH { get; set; }

        [Required(ErrorMessage = "Tên không được để trống !")]
        [StringLength(50)]
        public string TenKH { get; set; }

        [Required(ErrorMessage = "Số Điện Thoại không được để trống !")]
        [StringLength(10)]
        public string SoDienThoai { get; set; }

        [Required(ErrorMessage = "Biển số xe không được để trống !")]
        [StringLength(15)]
        public string BienSoXe { get; set; }

        [StringLength(6)]
        public string MaNV { get; set; }

        public DateTime? NgayDangKy { get; set; }

        public DateTime? ThoiGianVao { get; set; }

        public DateTime? ThoiGianRaDuKien { get; set; }

        public DateTime? NgayBatDauApDung { get; set; }

        public DateTime? HanCuoiHetPhi { get; set; }

        public decimal? ThanhTienDuKien { get; set; }

        public decimal? Discount { get; set; }

        public bool? TrangThaiThanhToan { get; set; }

        public bool? TrangThaiVaoBai { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual ODo ODo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
