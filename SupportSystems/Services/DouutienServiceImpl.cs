using SupportSystems.Models;

namespace SupportSystems.Services;

public class DouutienServiceImpl : DouutienService
{
    private DatabaseContext db;
    public DouutienServiceImpl(DatabaseContext _db)
    {
        db = _db;
    }
    public List<DoUuTien> findAll()
    {
        return db.DoUuTiens.ToList();
    }
}
