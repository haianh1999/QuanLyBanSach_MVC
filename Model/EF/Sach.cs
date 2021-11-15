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
            CTPhieuXuats = new HashSet<CTPhieuXuat>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "Mã sách")]
        public string MaSach { get; set; }

        [StringLength(500)]
        [Display(Name = "Tên sách")]
        [Required(ErrorMessage = "Bạn phải nhập tên sách")]
        public string TenSach { get; set; }

        [Column("Mieu ta", TypeName = "ntext")]
        [Display(Name = "Miêu tả")]
        public string Mieu_ta { get; set; }

        [StringLength(250)]
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

        [Display(Name = "Giá")]
        public decimal? GiaThanh { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày thêm")]
        public DateTime? NgayThem { get; set; }

        public long? LuotXem { get; set; }

        [StringLength(10)]
        [Display(Name = "Thể loại")]
        public string MaTL { get; set; }

     

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPhieuXuat> CTPhieuXuats { get; set; }

        public virtual TheLoai TheLoai { get; set; }
        [NotMapped]
        public virtual List<TheLoai> TheLoaiCollection { get; set; }
    }
}
