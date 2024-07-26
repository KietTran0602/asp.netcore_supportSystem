using Microsoft.AspNetCore.Mvc;
using SupportSystems.Services;
using System.Globalization;

namespace SupportSystems.Areas.supporter.Controllers;
[Area("supporter")]
[Route("supporter/home")]
public class HomeSupporterController : Controller
{
    YeucauService yeucauService;
    NhanVienService NhanVienService;
    DouutienService DouutienService;
    public HomeSupporterController(YeucauService _yeucauService, NhanVienService _nhanVienService, DouutienService _douutienService)
    {
        yeucauService = _yeucauService;
        NhanVienService = _nhanVienService;
        DouutienService = _douutienService;
    }
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        var currentUser = HttpContext.Session.GetString("username");
        if (currentUser != null)
        {
            ViewBag.douutien = DouutienService.findAll();
            ViewBag.yeucaus = yeucauService.findAllSp(currentUser);
            return View("index");

        }
        else
        {
            return RedirectToAction("index", "login", new { Area = "supporter" });
        }
    }
    [Route("datesearch")]
    public IActionResult Datesearch(string fromdate, string todate)
    {
        var manvxuly = HttpContext.Session.GetString("username");
        var fromDate = DateTime.Now;
        var toDate = DateTime.Now;
        if (fromdate != null)
        {
            fromDate = DateTime.ParseExact(fromdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        if (todate != null)
        {
            toDate = DateTime.ParseExact(todate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        if ((toDate >= fromDate))
        {
            return new JsonResult(yeucauService.findbyDate(fromDate, toDate, manvxuly));
        }
        else
        {
            return new JsonResult(new
            {
                msg = "Invalid time"
            });
        }

    }
    [Route("priority")]
    public IActionResult Priority(string priority)
    {
        var id = int.Parse(priority);
        var manvxuly = HttpContext.Session.GetString("username");


        if (priority != null)
        {
            return new JsonResult(yeucauService.findbyPri(id, manvxuly));


        }
        else
        {
            return new JsonResult(new
            {
                msg = "No Priority selected"
            });

        }
    }
}
