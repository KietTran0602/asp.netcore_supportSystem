using SupportSystems.Models;

namespace SupportSystems.Services;

public class NhanVienServiceImpl : NhanVienService
{
    private DatabaseContext db;
    public NhanVienServiceImpl(DatabaseContext _db)
    {
        db = _db;
    }

    public bool Add(NhanVien nhanvien)
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

    public List<NhanVien> findAll()
    {
        return db.NhanViens.ToList();
    }

    public dynamic findSpAjax()
    {
        return db.NhanViens.Select(n => new
        {
            Username = n.Username,
            Password = n.Password,
            Hoten = n.Hoten,
            Ngaysinh = n.Ngaysinh,
            Kichhoat = n.Kichhoat,
            Hinhanh = n.Hinhanh,
            Quyen = n.Quyen
        }).Where(n => n.Quyen == 2).ToList();
    }

    public NhanVien findbyid(string username)
    {
        return db.NhanViens.Find(username);
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
