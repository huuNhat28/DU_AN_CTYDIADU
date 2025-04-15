using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DUAN_Homestay.Models;

public partial class InternWebsiteContext : DbContext
{
    public InternWebsiteContext()
    {
    }

    public InternWebsiteContext(DbContextOptions<InternWebsiteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DatPhong> DatPhongs { get; set; }

    public virtual DbSet<GioiThieu> GioiThieus { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LienHe> LienHes { get; set; }

    public virtual DbSet<Phong> Phongs { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<TinTuc> TinTucs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=45.119.214.168;Database=Intern_Website;User Id=intern;Password=2025Intern@DDC;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DatPhong>(entity =>
        {
            entity.HasKey(e => e.MaDatPhong);

            entity.HasIndex(e => e.MaKhachHang, "IX_DatPhongs_MaKhachHang");

            entity.HasIndex(e => e.MaPhong, "IX_DatPhongs_MaPhong");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.DatPhongs).HasForeignKey(d => d.MaKhachHang);

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.DatPhongs).HasForeignKey(d => d.MaPhong);
        });

        modelBuilder.Entity<GioiThieu>(entity =>
        {
            entity.HasKey(e => e.MaGioiThieu);

            entity.Property(e => e.HinhAnh).HasMaxLength(100);
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon);

            entity.HasIndex(e => e.MaDatPhong, "IX_HoaDons_MaDatPhong");

            entity.HasOne(d => d.MaDatPhongNavigation).WithMany(p => p.HoaDons).HasForeignKey(d => d.MaDatPhong);
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang);

            entity.Property(e => e.HinhAnh).HasMaxLength(100);
            entity.Property(e => e.SoCccd)
                .HasMaxLength(12)
                .HasColumnName("SoCCCD");
            entity.Property(e => e.SoDienThoai).HasMaxLength(10);
        });

        modelBuilder.Entity<LienHe>(entity =>
        {
            entity.HasKey(e => e.MaLienHe);

            entity.HasIndex(e => e.MaKhachHang, "IX_LienHes_MaKhachHang");

            entity.Property(e => e.SoDienThoai).HasMaxLength(10);

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.LienHes).HasForeignKey(d => d.MaKhachHang);
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.HasKey(e => e.MaPhong);

            entity.Property(e => e.HinhAnh).HasMaxLength(100);
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaTaiKhoan);

            entity.HasIndex(e => e.MaKhachHang, "IX_TaiKhoans_MaKhachHang");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.TaiKhoans).HasForeignKey(d => d.MaKhachHang);
        });

        modelBuilder.Entity<TinTuc>(entity =>
        {
            entity.HasKey(e => e.MaTinTuc);

            entity.Property(e => e.HinhAnh).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
