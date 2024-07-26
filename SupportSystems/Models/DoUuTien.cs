using System;
using System.Collections.Generic;

namespace SupportSystems.Models;

public partial class DoUuTien
{
    public int Madouutien { get; set; }

    public string Tendouutien { get; set; } = null!;

    public virtual ICollection<YeuCau> YeuCaus { get; set; } = new List<YeuCau>();
}
