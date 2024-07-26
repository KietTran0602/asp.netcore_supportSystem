using Microsoft.AspNetCore.Mvc;
using SupportSystems.Models;
using SupportSystems.Services;
using System.Diagnostics;
using System.Globalization;

namespace SupportSystems.Controllers;
[Route("yeucau")]
public class YeucauController : Controller
{
    private YeucauService yeucauService;
    private AccountService accountService;
    private DouutienService douutienService;
    public YeucauController(YeucauService _yeucauService, AccountService _accountService, DouutienService _douutienService)
    {
        yeucauService = _yeucauService;
        accountService = _accountService;
        douutienService = _douutienService;
    }
    [HttpGet]
    [Route("add")]
    public IActionResult Add()
    {
        ViewBag.douutien = douutienService.findAll();
        var yeucau = new YeuCau();
        return View("Add", yeucau);
    }

    [HttpPost]
    [Route("add")]
    public IActionResult Add(YeuCau yeucau)
    {
        var username = HttpContext.Session.GetString("username");
        yeucau.Ngaygui = DateTime.Now;
        yeucau.ManvGui = username;

        if (yeucauService.Add(yeucau))
        {
            TempData["msg"] = "Success";
            return RedirectToAction("index", "home");
        }
        else
        {
            TempData["msg"] = "Failed";
            return RedirectToAction("add", "yeucau");
        }

    }

    [HttpGet]
    [Route("list")]
    public IActionResult List()
    {
        var username = HttpContext.Session.GetString("username");
        ViewBag.douutien = douutienService.findAll();
        ViewBag.yeucaus = yeucauService.findbyusername(username);
        return View("list", "yeucau");
    }

    [Route("datesearch")]
    public IActionResult Datesearch(string fromdate, string todate)
    {
        var manvgui = HttpContext.Session.GetString("username");
        var fromDate = DateTime.Now;
        var toDate = DateTime.Now;
        Debug.WriteLine(manvgui);
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
            return new JsonResult(yeucauService.findbyDateNv(fromDate, toDate, manvgui));
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
        var manvgui = HttpContext.Session.GetString("username");


        if (priority != null)
        {
            return new JsonResult(yeucauService.findbyPriNv(id, manvgui));


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
