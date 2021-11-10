namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuXuat")]
    public partial class PhieuXuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuXuat()
        {
            CTPhieuXuats = new HashSet<CTPhieuXuat>();
        }

        [Key]
        [StringLength(10)]
        public string MaPX { get; set; }

        [StringLength(10)]
        public string MaKH { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTao { get; set; }

        public decimal? TongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPhieuXuat> CTPhieuXuats { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
