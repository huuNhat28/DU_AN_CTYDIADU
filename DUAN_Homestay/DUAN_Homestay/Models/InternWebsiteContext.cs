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

    public virtual DbSet<BaiViet> BaiViets { get; set; }

    public virtual DbSet<DanhMucBaiViet> DanhMucBaiViets { get; set; }

    public virtual DbSet<DatPhong> DatPhongs { get; set; }

    public virtual DbSet<Hang> Hangs { get; set; }

    public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }

    public virtual DbSet<LichSuDatPhong> LichSuDatPhongs { get; set; }

    public virtual DbSet<LienHe> LienHes { get; set; }

    public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }

    public virtual DbSet<Phong> Phongs { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<VaiTro> VaiTros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=45.119.214.168;Database=Intern_Website;User Id=intern;Password=2025Intern@DDC;TrustServerCertificate=true;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaiViet>(entity =>
        {
            entity.ToTable("BaiViet");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HinhAnhNho).HasMaxLength(255);
            entity.Property(e => e.IddanhMucBaiViet).HasColumnName("IDDanhMucBaiViet");
            entity.Property(e => e.NoiDungNgan).HasMaxLength(255);
            entity.Property(e => e.TieuDe).HasMaxLength(255);

            entity.HasOne(d => d.IddanhMucBaiVietNavigation).WithMany(p => p.BaiViets)
                .HasForeignKey(d => d.IddanhMucBaiViet)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_BaiViet_DanhMucBaiViet");
        });

        modelBuilder.Entity<DanhMucBaiViet>(entity =>
        {
            entity.ToTable("DanhMucBaiViet");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TenDanhMuc).HasMaxLength(255);
        });

        modelBuilder.Entity<DatPhong>(entity =>
        {
            entity.ToTable("DatPhong");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idphong).HasColumnName("IDPhong");
            entity.Property(e => e.IdtaiKhoan).HasColumnName("IDTaiKhoan");

            entity.HasOne(d => d.IdphongNavigation).WithMany(p => p.DatPhongs)
                .HasForeignKey(d => d.Idphong)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DatPhong_Phong");

            entity.HasOne(d => d.IdtaiKhoanNavigation).WithMany(p => p.DatPhongs)
                .HasForeignKey(d => d.IdtaiKhoan)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DatPhong_TaiKhoan");
        });

        modelBuilder.Entity<Hang>(entity =>
        {
            entity.ToTable("Hang");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TenHang).HasMaxLength(255);
        });

        modelBuilder.Entity<KhuyenMai>(entity =>
        {
            entity.ToTable("KhuyenMai");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TenKhuyenMai).HasMaxLength(50);
        });

        modelBuilder.Entity<LichSuDatPhong>(entity =>
        {
            entity.ToTable("LichSuDatPhong");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IddatPhong).HasColumnName("IDDatPhong");
            entity.Property(e => e.IdtaiKhoan).HasColumnName("IDTaiKhoan");
        });

        modelBuilder.Entity<LienHe>(entity =>
        {
            entity.ToTable("LienHe");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .HasColumnName("SDT");
        });

        modelBuilder.Entity<LoaiPhong>(entity =>
        {
            entity.ToTable("LoaiPhong");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TenLoaiPhong).HasMaxLength(255);
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.ToTable("Phong");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AnhNho).HasMaxLength(255);
            entity.Property(e => e.IdloaiPhong).HasColumnName("IDLoaiPhong");
            entity.Property(e => e.MoTaNgan).HasMaxLength(255);

            entity.HasOne(d => d.IdloaiPhongNavigation).WithMany(p => p.Phongs)
                .HasForeignKey(d => d.IdloaiPhong)
                .HasConstraintName("FK_Phong_LoaiPhong");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.ToTable("TaiKhoan");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.HoTen).HasMaxLength(255);
            entity.Property(e => e.Idhang).HasColumnName("IDHang");
            entity.Property(e => e.IdvaiTro).HasColumnName("IDVaiTro");
            entity.Property(e => e.MatKhau).HasMaxLength(255);
            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .HasColumnName("SDT");
            entity.Property(e => e.SoCccd)
                .HasMaxLength(50)
                .HasColumnName("SoCCCD");

            entity.HasOne(d => d.IdhangNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.Idhang)
                .HasConstraintName("FK_TaiKhoan_Hang");

            entity.HasOne(d => d.IdvaiTroNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.IdvaiTro)
                .HasConstraintName("FK_TaiKhoan_VaiTro");
        });

        modelBuilder.Entity<VaiTro>(entity =>
        {
            entity.ToTable("VaiTro");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TenVaiTro).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
