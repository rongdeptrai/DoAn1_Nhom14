namespace ModelEF.ModelDb
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyParkingContext : DbContext
    {
        public MyParkingContext()
            : base("name=MyParkingContext")
        {
        }

        public virtual DbSet<ChiTietXe> ChiTietXes { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<DatCho> DatChoes { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiKhachHang> LoaiKhachHangs { get; set; }
        public virtual DbSet<LoaiODo> LoaiODoes { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<ODo> ODoes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietXe>()
                .Property(e => e.MaCTX)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietXe>()
                .Property(e => e.BienSoXe)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietXe>()
                .Property(e => e.MaKH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChucVu>()
                .Property(e => e.MaCV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChucVu>()
                .HasMany(e => e.NhanViens)
                .WithRequired(e => e.ChucVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DatCho>()
                .Property(e => e.MaDatCho)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DatCho>()
                .Property(e => e.MaODo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DatCho>()
                .Property(e => e.MaKH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DatCho>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DatCho>()
                .Property(e => e.BienSoXe)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DatCho>()
                .Property(e => e.MaNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DatCho>()
                .Property(e => e.ThanhTienDuKien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DatCho>()
                .Property(e => e.Discount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DatCho>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.DatCho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaHD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaDatCho)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TienPhat)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TongTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaKH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.GioiTinh)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaLKH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.ChiTietXes)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.DatChoes)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiKhachHang>()
                .Property(e => e.MaLKH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LoaiKhachHang>()
                .HasMany(e => e.KhachHangs)
                .WithRequired(e => e.LoaiKhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiODo>()
                .Property(e => e.MaLoaiO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LoaiODo>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LoaiODo>()
                .HasMany(e => e.ODoes)
                .WithRequired(e => e.LoaiODo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.GioiTinh)
                .IsFixedLength();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaCV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ODo>()
                .Property(e => e.MaODo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ODo>()
                .Property(e => e.ViTriODo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ODo>()
                .Property(e => e.MaLoaiO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ODo>()
                .HasMany(e => e.DatChoes)
                .WithRequired(e => e.ODo)
                .WillCascadeOnDelete(false);
        }
    }
}
