using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Model.EF
{
    public partial class QlBanSachDbcontext : DbContext
    {
        public QlBanSachDbcontext()
            : base("name=QlBanSachDbcontext")
        {
        }

        public virtual DbSet<CTPhieuNhap> CTPhieuNhaps { get; set; }
        public virtual DbSet<CTPhieuXuat> CTPhieuXuats { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<PhieuXuat> PhieuXuats { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTPhieuNhap>()
                .Property(e => e.MaPN)
                .IsUnicode(false);

            modelBuilder.Entity<CTPhieuNhap>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<CTPhieuNhap>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CTPhieuXuat>()
                .Property(e => e.MaPX)
                .IsUnicode(false);

            modelBuilder.Entity<CTPhieuXuat>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<CTPhieuXuat>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhap>()
                .Property(e => e.MaPN)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhap>()
                .Property(e => e.TongTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PhieuNhap>()
                .HasMany(e => e.CTPhieuNhaps)
                .WithRequired(e => e.PhieuNhap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuXuat>()
                .Property(e => e.MaPX)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuXuat>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuXuat>()
                .Property(e => e.TongTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PhieuXuat>()
                .HasMany(e => e.CTPhieuXuats)
                .WithRequired(e => e.PhieuXuat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.GiaThanh)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaTL)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.CTPhieuNhaps)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.CTPhieuXuats)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TheLoai>()
                .Property(e => e.MaTL)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
