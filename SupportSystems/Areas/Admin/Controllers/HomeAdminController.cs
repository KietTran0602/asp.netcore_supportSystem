using Microsoft.AspNetCore.Mvc;
using SupportSystems.Services;
//using SupportSystem.Services;

namespace SupportSystems.Areas.Admin.Controllers;
[Area("admin")]
[Route("admin/home")]
public class HomeAdminController : Controller
{
    YeucauService yeucauService;
    NhanVienService NhanVienService;
    public HomeAdminController(YeucauService _yeucauService, NhanVienService _nhanVienService)
    {
        yeucauService = _yeucauService;
        NhanVienService = _nhanVienService;
    }
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("username") != null)
        {
            ViewBag.yeucaus = yeucauService.findAll().OrderBy(y => y.Ngaygui);
            ViewBag.nhanviens = NhanVienService.findAll().Where(n => n.Quyen == 2);
            return View("index");

        }
        else
        {
            return RedirectToAction("index", "login", new { Area = "admin" });
        }
    }

    [HttpGet]
    [Route("prioritysort")]
    public IActionResult Prioritysort(string id)
    {
        var nhanviens = NhanVienService.findSpAjax();
        if (id == "0")
        {
            var yeucaus = yeucauService.findAllAjax();
            var data = new
            {
                nhanviens = nhanviens,
                yeucaus = yeucaus
            };
            return new JsonResult(data);
        }
        else if (id == "1")
        {
            var yeucaus = yeucauService.findAllAjaxDesc();
            var data = new
            {
                nhanviens = nhanviens,
                yeucaus = yeucaus
            };
            return new JsonResult(data);

        }
        else
        {
            return new JsonResult(new
            {
                msg = "doesn't have that option"
            });
        }
    }
}
