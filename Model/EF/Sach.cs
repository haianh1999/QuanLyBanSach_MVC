namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            CTPhieuNhaps = new HashSet<CTPhieuNhap>();
            CTPhieuXuats = new HashSet<CTPhieuXuat>();
        }

        [Key]
        [StringLength(10)]
        public string MaSach { get; set; }

        [StringLength(500)]
        public string TenSach { get; set; }

        [Column("Mieu ta", TypeName = "ntext")]
        public string Mieu_ta { get; set; }

        [StringLength(250)]
        public string HinhAnh { get; set; }

        public decimal? GiaThanh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThem { get; set; }

        public long? LuotXem { get; set; }

        [StringLength(10)]
        public string MaTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPhieuNhap> CTPhieuNhaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPhieuXuat> CTPhieuXuats { get; set; }

        public virtual TheLoai TheLoai { get; set; }
    }
}
