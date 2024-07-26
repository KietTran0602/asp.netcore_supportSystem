using SupportSystems.Models;

namespace SupportSystems.Services;

public class YeucauServiceImpl : YeucauService
{
    private DatabaseContext db;
    public YeucauServiceImpl(DatabaseContext _db)
    {
        db = _db;
    }

    public bool Add(YeuCau yeucau)
    {
        try
        {
            db.YeuCaus.Add(yeucau);
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

    public List<YeuCau> findAll()
    {
        return db.YeuCaus.ToList();
    }

    public dynamic findAllAjax()
    {
        return db.YeuCaus.Select(y => new
        {
            Mayeucau = y.Mayeucau,
            Tieude = y.Tieude,
            Noidung = y.Noidung,
            Ngaygui = y.Ngaygui,
            Madouutien = y.Madouutien,
            Manvgui = y.ManvGui,
            Manvxuly = y.ManvXuly
        }).OrderBy(y => y.Madouutien).ToList();
    }

    public dynamic findAllAjaxDesc()
    {
        return db.YeuCaus.Select(y => new
        {
            Mayeucau = y.Mayeucau,
            Tieude = y.Tieude,
            Noidung = y.Noidung,
            Ngaygui = y.Ngaygui,
            Madouutien = y.Madouutien,
            Manvgui = y.ManvGui,
            Manvxuly = y.ManvXuly
        }).OrderByDescending(y => y.Madouutien).ToList();
    }

    public List<YeuCau> findAllSp(string username)
    {
        return db.YeuCaus.Where(y => y.ManvXuly == username).ToList();
    }

    public dynamic findbyDate(DateTime fromdate, DateTime todate, string manvxuly)
    {
        return db.YeuCaus.Select(y => new
        {
            mayeucau = y.Mayeucau,
            tieude = y.Tieude,
            noidung = y.Noidung,
            ngaygui = y.Ngaygui,
            tendouutien = y.MadouutienNavigation.Tendouutien,
            tennvgui = y.ManvGuiNavigation.Hoten,
            tennvxuly = y.ManvXulyNavigation.Hoten,
            madouutien = y.Madouutien,
            manvgui = y.ManvGui,
            manvxuly = y.ManvXuly
        }).Where(y => y.ngaygui >= fromdate && y.ngaygui <= todate && y.manvxuly == manvxuly).ToList();
    }

    public dynamic findbyDateNv(DateTime fromdate, DateTime todate, string manvgui)
    {
        return db.YeuCaus.Select(y => new
        {
            mayeucau = y.Mayeucau,
            tieude = y.Tieude,
            noidung = y.Noidung,
            ngaygui = y.Ngaygui,
            tendouutien = y.MadouutienNavigation.Tendouutien,
            tennvgui = y.ManvGuiNavigation.Hoten,
            tennvxuly = y.ManvXulyNavigation.Hoten,
            madouutien = y.Madouutien,
            manvgui = y.ManvGui,
            manvxuly = y.ManvXuly
        }).Where(y => y.ngaygui >= fromdate && y.ngaygui <= todate && y.manvgui == manvgui).ToList();
    }

    public YeuCau findbyId(int id)
    {
        return db.YeuCaus.Find(id);
    }

    public dynamic findbyPri(int id, string manvxuly)
    {
        return db.YeuCaus.Select(y => new
        {
            mayeucau = y.Mayeucau,
            tieude = y.Tieude,
            noidung = y.Noidung,
            ngaygui = y.Ngaygui,
            tendouutien = y.MadouutienNavigation.Tendouutien,
            tennvgui = y.ManvGuiNavigation.Hoten,
            tennvxuly = y.ManvXulyNavigation.Hoten,
            madouutien = y.Madouutien,
            manvgui = y.ManvGui,
            manvxuly = y.ManvXuly
        }).Where(y => y.manvxuly == manvxuly && y.madouutien == id).ToList();
    }

    public dynamic findbyPriNv(int id, string manvgui)
    {
        return db.YeuCaus.Select(y => new
        {
            mayeucau = y.Mayeucau,
            tieude = y.Tieude,
            noidung = y.Noidung,
            ngaygui = y.Ngaygui,
            tendouutien = y.MadouutienNavigation.Tendouutien,
            tennvgui = y.ManvGuiNavigation.Hoten,
            tennvxuly = y.ManvXulyNavigation.Hoten,
            madouutien = y.Madouutien,
            manvgui = y.ManvGui,
            manvxuly = y.ManvXuly
        }).Where(y => y.manvgui == manvgui && y.madouutien == id).ToList();
    }

    public List<YeuCau> findbyusername(string username)
    {
        return db.YeuCaus.Where(y => y.ManvGui == username).ToList();
    }

    public bool Update(YeuCau yeucau)
    {
        try
        {
            db.Entry(yeucau).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
}
