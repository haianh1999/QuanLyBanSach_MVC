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
        public string MaPX { get; set; }

        [Required]
        [StringLength(10)]
        public string MaSach { get; set; }

        public int? SoLuong { get; set; }

        public decimal? DonGia { get; set; }

        public long ID { get; set; }

        public virtual PhieuXuat PhieuXuat { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
