namespace ModelEF.ModelDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiODo")]
    public partial class LoaiODo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiODo()
        {
            ODoes = new HashSet<ODo>();
        }

        [Key]
        [StringLength(6)]
        public string MaLoaiO { get; set; }

        [Required]
        [StringLength(30)]
        public string TenloaiO { get; set; }

        public int? SoLuongODo { get; set; }

        public decimal DonGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ODo> ODoes { get; set; }
    }
}
