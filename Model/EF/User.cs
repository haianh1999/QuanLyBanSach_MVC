namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            PhieuXuats = new HashSet<PhieuXuat>();
        }

        [Key]
        [StringLength(50)]
        [Display(Name ="Tài khoản")]
        [Required(ErrorMessage ="Bạn phải nhập username")]
        public string UserName { get; set; }

        [StringLength(50)]
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string password { get; set; }

        [StringLength(100)]
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Bạn phải nhập họ tên")]
        public string HoTen { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(100)]
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Bạn phải nhập địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(10)]
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại")]
        public string SDT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTao { get; set; }

        public int? PhanQuyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuXuat> PhieuXuats { get; set; }
    }
}
