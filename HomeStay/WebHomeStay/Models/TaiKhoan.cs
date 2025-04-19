using System;
using System.Collections.Generic;

namespace WebHomeStay.Models;

public partial class TaiKhoan
{
    public int Id { get; set; }

    public int IdvaiTro { get; set; }

    public int Idhang { get; set; }

    public string? HoTen { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public string? SoCccd { get; set; }

    public string? DiaChi { get; set; }

    public string? MatKhau { get; set; }

    public string? HinhAnh { get; set; }

    public DateOnly? NgayTao { get; set; }

    public bool? TrangThai { get; set; }

    public string? ResetCode { get; set; }

    public virtual ICollection<DatPhong> DatPhongs { get; set; } = new List<DatPhong>();

    public virtual Hang IdhangNavigation { get; set; } = null!;

    public virtual VaiTro IdvaiTroNavigation { get; set; } = null!;
}
