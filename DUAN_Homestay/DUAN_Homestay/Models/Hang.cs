using System;
using System.Collections.Generic;

namespace DUAN_Homestay.Models;

public partial class Hang
{
    public int Id { get; set; }

    public string? TenHang { get; set; }

    public int? SoLanThue { get; set; }

    public double? GiamGia { get; set; }

    public bool? TrangThai { get; set; }

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
