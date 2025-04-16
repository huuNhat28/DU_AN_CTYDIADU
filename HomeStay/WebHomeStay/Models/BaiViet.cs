using System;
using System.Collections.Generic;

namespace WebHomeStay.Models;

public partial class BaiViet
{
    public int Id { get; set; }

    public int? IddanhMucBaiViet { get; set; }

    public string? TieuDe { get; set; }

    public string? NoiDung { get; set; }

    public string? NoiDungNgan { get; set; }

    public string? HinhAnh { get; set; }

    public string? HinhAnhNho { get; set; }

    public DateOnly? NgayDang { get; set; }

    public DateOnly? NgayCapNhat { get; set; }

    public bool? TrangThai { get; set; }

    public virtual DanhMucBaiViet? IddanhMucBaiVietNavigation { get; set; }
}
