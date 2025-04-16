using System;
using System.Collections.Generic;

namespace DUAN_Homestay.Models;

public partial class Phong
{
    public int Id { get; set; }

    public int IdloaiPhong { get; set; }

    public int? SoPhong { get; set; }

    public double? Gia { get; set; }

    public string? MoTa { get; set; }

    public string? MoTaNgan { get; set; }

    public string? HinhAnh { get; set; }

    public string? AnhNho { get; set; }

    public bool? TrangThai { get; set; }

    public virtual ICollection<DatPhong> DatPhongs { get; set; } = new List<DatPhong>();

    public virtual LoaiPhong IdloaiPhongNavigation { get; set; } = null!;
}
