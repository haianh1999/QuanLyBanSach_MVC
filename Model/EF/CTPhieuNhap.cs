namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPhieuNhap")]
    public partial class CTPhieuNhap
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaPN { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaSach { get; set; }

        public long? SoLuong { get; set; }

        public decimal? DonGia { get; set; }

        public virtual PhieuNhap PhieuNhap { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
