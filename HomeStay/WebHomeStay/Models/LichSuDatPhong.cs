using System;
using System.Collections.Generic;

namespace WebHomeStay.Models;

public partial class LichSuDatPhong
{
    public int Id { get; set; }

    public int IdtaiKhoan { get; set; }

    public DateOnly IddatPhong { get; set; }
}
