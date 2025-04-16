using System;
using System.Collections.Generic;

namespace DUAN_Homestay.Models;

public partial class DatPhong
{
    public int Id { get; set; }

    public int? IdtaiKhoan { get; set; }

    public int? Idphong { get; set; }

    public DateOnly? NgayDatPhong { get; set; }

    public DateOnly? NgayTraPhong { get; set; }

    public bool? TrangThaiThanhToan { get; set; }

    public bool? TrangThaiDatPhong { get; set; }

    public double? TongTien { get; set; }

    public virtual Phong? IdphongNavigation { get; set; }

    public virtual TaiKhoan? IdtaiKhoanNavigation { get; set; }
}
