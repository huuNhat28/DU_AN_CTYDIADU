using System;
using System.Collections.Generic;

namespace DUAN_Homestay.Models;

public partial class Phong
{
    public string MaPhong { get; set; } = null!;

    public int SoPhong { get; set; }

    public string LoaiPhong { get; set; } = null!;

    public long Gia { get; set; }

    public string TrangThai { get; set; } = null!;

    public string MoTa { get; set; } = null!;

    public string HinhAnh { get; set; } = null!;

    public virtual ICollection<DatPhong> DatPhongs { get; set; } = new List<DatPhong>();
}
