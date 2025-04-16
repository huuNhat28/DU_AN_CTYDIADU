using System;
using System.Collections.Generic;

namespace DUAN_Homestay.Models;

public partial class LoaiPhong
{
    public int Id { get; set; }

    public string? TenLoaiPhong { get; set; }

    public virtual ICollection<Phong> Phongs { get; set; } = new List<Phong>();
}
