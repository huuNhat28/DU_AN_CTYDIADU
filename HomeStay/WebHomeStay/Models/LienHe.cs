using System;
using System.Collections.Generic;

namespace WebHomeStay.Models;

public partial class LienHe
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Sdt { get; set; }

    public bool? TrangThai { get; set; }
}
