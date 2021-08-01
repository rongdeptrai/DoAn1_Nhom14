namespace ModelEF.ModelDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            DatChoes = new HashSet<DatCho>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short IdNV { get; set; }

        [Key]
        [StringLength(6)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNV { get; set; }

        [StringLength(10)]
        public string SoDienThoai { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(40)]
        public string DiaChi { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        [StringLength(4)]
        public string GioiTinh { get; set; }

        [Required]
        [StringLength(75)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(6)]
        public string MaCV { get; set; }

        public virtual ChucVu ChucVu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatCho> DatChoes { get; set; }
    }
}
