using System;
using System.Collections.Generic;

namespace DUAN_Homestay.Models;

public partial class DatPhong
{
    public string MaDatPhong { get; set; } = null!;

    public DateTime NgayNhanPhong { get; set; }

    public DateTime NgayTraPhong { get; set; }

    public string TrangThaiDat { get; set; } = null!;

    public long TongTien { get; set; }

    public DateTime NgayTao { get; set; }

    public string MaKhachHang { get; set; } = null!;

    public string MaPhong { get; set; } = null!;

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;

    public virtual Phong MaPhongNavigation { get; set; } = null!;
}
