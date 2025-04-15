using System;
using System.Collections.Generic;

namespace DUAN_Homestay.Models;

public partial class LienHe
{
    public string MaLienHe { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string SoDienThoai { get; set; } = null!;

    public string NoiDung { get; set; } = null!;

    public string TrangThai { get; set; } = null!;

    public DateTime NgayTao { get; set; }

    public string MaKhachHang { get; set; } = null!;

    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;
}
