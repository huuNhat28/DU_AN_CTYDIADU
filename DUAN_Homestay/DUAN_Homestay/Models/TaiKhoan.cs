using System;
using System.Collections.Generic;

namespace DUAN_Homestay.Models;

public partial class TaiKhoan
{
    public string MaTaiKhoan { get; set; } = null!;

    public string TenDangNhap { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string VaiTro { get; set; } = null!;

    public string MaKhachHang { get; set; } = null!;

    public string NgayTao { get; set; } = null!;

    public bool TrangThai { get; set; }

    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;
}
