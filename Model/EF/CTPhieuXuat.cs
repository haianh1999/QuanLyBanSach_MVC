namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPhieuXuat")]
    public partial class CTPhieuXuat
    {
        [Required]
        [StringLength(10)]
        [Display(Name ="Mã phiếu xuất")]
        public string MaPX { get; set; }
        
        [Required]
        [StringLength(10)]
        [Display(Name = "Mã sách")]
        public string MaSach { get; set; }
        [Display(Name = "Số lượng")]
        public int? SoLuong { get; set; }

        [Display(Name = "Giá")]
        public decimal? DonGia { get; set; }

        public long ID { get; set; }

        public virtual PhieuXuat PhieuXuat { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
