using DUAN_Homestay.Models;
using Microsoft.EntityFrameworkCore;


namespace DUAN_Homestay.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }
        public virtual DbSet<LienHe> LienHes { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<GioiThieu> GioiThieus { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<DatPhong> DatPhongs { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaiKhoan>()
                .HasOne(tk => tk.KHang)
                .WithMany(kh => kh.TaiKhoans)
                .HasForeignKey(kh => kh.MaKhachHang);

            modelBuilder.Entity<DatPhong>()
                .HasMany(hd => hd.HoaDons)
                .WithOne(dp => dp.DPhong)
                .HasForeignKey(dp => dp.MaDatPhong);

            modelBuilder.Entity<KhachHang>()
               .HasMany(lh => lh.LienHes)
               .WithOne(kh => kh.KHang)
               .HasForeignKey(kh => kh.MaKhachHang);


            modelBuilder.Entity<DatPhong>()
                .HasOne(kh => kh.KHang)
                .WithMany(dp => dp.DatPhongs)
                .HasForeignKey(dp => dp.MaKhachHang);

            modelBuilder.Entity<DatPhong>()
                .HasOne(p => p.P)
                .WithMany(dp => dp.DatPhongs)
                .HasForeignKey(dp => dp.MaPhong);

        }

    }
}
