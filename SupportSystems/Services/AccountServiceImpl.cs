using SupportSystems.Models;

namespace SupportSystems.Services;

public class AccountServiceImpl : AccountService
{
    private DatabaseContext db;
    public AccountServiceImpl(DatabaseContext _db)
    {
        db = _db;
    }

    public bool Create(NhanVien nhanvien)
    {
        try
        {
            db.NhanViens.Add(nhanvien);
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }



    public NhanVien findByUsername(string username)
    {
        return db.NhanViens.SingleOrDefault(n => n.Username == username);
    }

    public bool Login(string username, string password)
    {
        var account = db.NhanViens.SingleOrDefault(n => n.Username == username);
        if (account != null)
        {
            return BCrypt.Net.BCrypt.Verify(password, account.Password);
        }
        return false;
    }

    public bool Update(NhanVien nhanvien)
    {
        try
        {
            db.Entry(nhanvien).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
}
