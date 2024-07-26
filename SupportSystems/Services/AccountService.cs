using SupportSystems.Models;

namespace SupportSystems.Services;

public interface AccountService
{
    public bool Create(NhanVien nhanvien);

    public bool Update(NhanVien nhanvien);
    public bool Login(string username, string password);

    public NhanVien findByUsername(string username);


}
