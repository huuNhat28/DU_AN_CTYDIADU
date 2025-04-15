using System;
using System.Collections.Generic;

namespace DUAN_Homestay.Models;

public partial class KhachHang
{
    public string MaKhachHang { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public string SoDienThoai { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string SoCccd { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string HinhAnh { get; set; } = null!;

    public DateTime NgayTao { get; set; }

    public virtual ICollection<DatPhong> DatPhongs { get; set; } = new List<DatPhong>();

    public virtual ICollection<LienHe> LienHes { get; set; } = new List<LienHe>();

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
