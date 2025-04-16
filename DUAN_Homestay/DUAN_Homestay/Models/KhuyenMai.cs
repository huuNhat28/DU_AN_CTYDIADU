using System;
using System.Collections.Generic;

namespace DUAN_Homestay.Models;

public partial class KhuyenMai
{
    public int Id { get; set; }

    public string? TenKhuyenMai { get; set; }

    public DateOnly? ThoiGian { get; set; }

    public double? SoTienGiam { get; set; }

    public bool? TrangThai { get; set; }
}
