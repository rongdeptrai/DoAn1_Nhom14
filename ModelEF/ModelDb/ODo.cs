namespace ModelEF.ModelDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODo")]
    public partial class ODo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ODo()
        {
            DatChoes = new HashSet<DatCho>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short IdODo { get; set; }

        [Key]
        [StringLength(6)]
        public string MaODo { get; set; }

        [Required]
        [StringLength(5)]
        public string ViTriODo { get; set; }

        [Required]
        [StringLength(50)]
        public string TrangThai { get; set; }

        public int Tang { get; set; }

        [Required]
        [StringLength(6)]
        public string MaLoaiO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatCho> DatChoes { get; set; }

        public virtual LoaiODo LoaiODo { get; set; }
    }
}
