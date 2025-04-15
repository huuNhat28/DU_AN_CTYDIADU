using System;
using System.Collections.Generic;

namespace DUAN_Homestay.Models;

public partial class GioiThieu
{
    public string MaGioiThieu { get; set; } = null!;

    public string TieuDe { get; set; } = null!;

    public string NoiDung { get; set; } = null!;

    public string HinhAnh { get; set; } = null!;

    public DateTime NgayCapNhat { get; set; }

    public DateTime NgayTao { get; set; }
}
