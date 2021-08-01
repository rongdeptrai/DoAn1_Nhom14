namespace ModelEF.ModelDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            ChiTietXes = new HashSet<ChiTietXe>();
            DatChoes = new HashSet<DatCho>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short IdKH { get; set; }

        [Key]
        [StringLength(6)]
        public string MaKH { get; set; }

        [StringLength(50)]
        public string TenKH { get; set; }

        [StringLength(40)]
        public string DiaChi { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string SoDienThoai { get; set; }

        [StringLength(4)]
        public string GioiTinh { get; set; }

        [Required]
        [StringLength(75)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(6)]
        public string MaLKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietXe> ChiTietXes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatCho> DatChoes { get; set; }

        public virtual LoaiKhachHang LoaiKhachHang { get; set; }
    }
}
