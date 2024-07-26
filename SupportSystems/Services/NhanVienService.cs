using SupportSystems.Models;

namespace SupportSystems.Services;

public interface NhanVienService
{
    public List<NhanVien> findAll();

    public NhanVien findbyid(string username);

    public bool Add(NhanVien nhanvien);

    public bool Update(NhanVien nhanvien);

    public dynamic findSpAjax();
}
