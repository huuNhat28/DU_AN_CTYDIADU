using System;
using System.Collections.Generic;

namespace WebHomeStay.Models;

public partial class VaiTro
{
    public int Id { get; set; }

    public string? TenVaiTro { get; set; }

    public bool? TrangThai { get; set; }

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
