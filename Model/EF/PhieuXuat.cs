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
        [Display(Name = "Mã phiếu xuất")]
        public string MaPX { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã khách hàng")]
        public string UserName { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày tạo")]
        public DateTime? NgayTao { get; set; }
        [Display(Name = "Tổng tiền")]
        public decimal? TongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPhieuXuat> CTPhieuXuats { get; set; }

        public virtual User User { get; set; }
    }
}
