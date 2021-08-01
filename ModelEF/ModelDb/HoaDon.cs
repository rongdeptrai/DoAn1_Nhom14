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
        public string MaDatCho { get; set; }

        [Required]
        [StringLength(6)]
        public string MaNV { get; set; }

        [StringLength(50)]
        public string TenKH { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLap { get; set; }

        public DateTime? ThoiGianRa { get; set; }

        public decimal? TienPhat { get; set; }

        public decimal? TongTien { get; set; }

        public virtual DatCho DatCho { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
