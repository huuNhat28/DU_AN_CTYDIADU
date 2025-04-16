using System;
using System.Collections.Generic;

namespace DUAN_Homestay.Models;

public partial class DanhMucBaiViet
{
    public int Id { get; set; }

    public string? TenDanhMuc { get; set; }

    public bool? TrangThai { get; set; }

    public virtual ICollection<BaiViet> BaiViets { get; set; } = new List<BaiViet>();
}
