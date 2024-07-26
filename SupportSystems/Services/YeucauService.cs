using SupportSystems.Models;

namespace SupportSystems.Services;

public interface YeucauService
{
    public List<YeuCau> findAll();
    public List<YeuCau> findAllSp(string username);


    public List<YeuCau> findbyusername(string username);
    public YeuCau findbyId(int id);
    public bool Add(YeuCau yeucau);
    public bool Update(YeuCau yeucau);

    public dynamic findbyDate(DateTime fromdate, DateTime todate, string manvxuly);
    public dynamic findbyPri(int id, string manvxuly);

    public dynamic findbyDateNv(DateTime fromdate, DateTime todate, string manvxuly);
    public dynamic findbyPriNv(int id, string manvxuly);
    public dynamic findAllAjax();

    public dynamic findAllAjaxDesc();
}
