namespace SupportSystems.Models;

public partial class YeuCau
{
    public int Mayeucau { get; set; }

    public string Tieude { get; set; } = null!;

    public string Noidung { get; set; } = null!;

    public DateTime? Ngaygui { get; set; }

    public int? Madouutien { get; set; }

    public string ManvGui { get; set; } = null!;

    public string? ManvXuly { get; set; }

    public virtual DoUuTien MadouutienNavigation { get; set; }

    public virtual NhanVien ManvGuiNavigation { get; set; } = null!;

    public virtual NhanVien ManvXulyNavigation { get; set; } = null!;
}
