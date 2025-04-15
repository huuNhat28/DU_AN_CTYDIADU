using System;
using System.Collections.Generic;

namespace DUAN_Homestay.Models;

public partial class TinTuc
{
    public string MaTinTuc { get; set; } = null!;

    public string TieuDe { get; set; } = null!;

    public string NoiDung { get; set; } = null!;

    public string HinhAnh { get; set; } = null!;

    public string LoaiTin { get; set; } = null!;

    public DateTime NgayDang { get; set; }

    public DateTime NgayCapNhat { get; set; }

    public bool HienThi { get; set; }
}
