namespace ModelEF.ModelDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietXe")]
    public partial class ChiTietXe
    {
        [Key]
        [StringLength(15)]
        public string BienSoXe { get; set; }

        [Required]
        [StringLength(15)]
        public string LoaiXe { get; set; }

        [Required]
        [StringLength(15)]
        public string HangXe { get; set; }

        [Required]
        [StringLength(6)]
        public string MaKH { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
