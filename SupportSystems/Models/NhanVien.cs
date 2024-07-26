using System;
using System.Collections.Generic;

namespace SupportSystems.Models;

public partial class NhanVien
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Hoten { get; set; } = null!;

    public DateOnly? Ngaysinh { get; set; }

    public bool Kichhoat { get; set; }

    public string? Hinhanh { get; set; }

    public int Quyen { get; set; }

    public virtual ICollection<YeuCau> YeuCauManvGuiNavigations { get; set; } = new List<YeuCau>();

    public virtual ICollection<YeuCau> YeuCauManvXulyNavigations { get; set; } = new List<YeuCau>();
}
