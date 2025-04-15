using System;
using System.Collections.Generic;

namespace DUAN_Homestay.Models;

public partial class HoaDon
{
    public string MaHoaDon { get; set; } = null!;

    public long TongTien { get; set; }

    public string TrangThaiThanhToan { get; set; } = null!;

    public string PhuongThucThanhToan { get; set; } = null!;

    public DateTime NgayTao { get; set; }

    public string MaDatPhong { get; set; } = null!;

    public virtual DatPhong MaDatPhongNavigation { get; set; } = null!;
}
