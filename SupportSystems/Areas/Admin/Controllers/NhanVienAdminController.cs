using Microsoft.AspNetCore.Mvc;
using SupportSystems.Models;
using SupportSystems.Services;

namespace SupportSystems.Areas.Admin.Controllers;
[Area("admin")]
[Route("admin/nhanvien")]
public class NhanVienAdminController : Controller
{
    NhanVienService nhanVienService;
    YeucauService yeucauService;
    public NhanVienAdminController(NhanVienService _nhanVienService, YeucauService _yeucauService)
    {
        nhanVienService = _nhanVienService;
        yeucauService = _yeucauService;
    }
    [HttpGet]
    [Route("add")]
    public IActionResult Add()
    {
        var nhanvien = new NhanVien();
        return View("Add", nhanvien);
    }

    [HttpPost]
    [Route("add")]
    public IActionResult Add(NhanVien nhanvien)
    {
        if (nhanVienService.findbyid(nhanvien.Username) == null)
        {
            nhanvien.Password = BCrypt.Net.BCrypt.HashPassword(nhanvien.Password);
            if (nhanVienService.Add(nhanvien))
            {
                TempData["msg"] = "Add Successfully";
                return RedirectToAction("Add");
            }
            else
            {
                TempData["msg"] = "Add Failed";
                return RedirectToAction("Add");
            }
        }
        else
        {
            TempData["msg"] = "Already have this user";
            return RedirectToAction("Add");
        }

    }
    [Route("list")]

    public IActionResult List()
    {
        ViewBag.NhanViens = nhanVienService.findAll();
        return View("List");
    }
    [Route("nvdetails")]
    public IActionResult nvDetails(string username)
    {
        ViewBag.nhanvien = nhanVienService.findbyid(username);
        ViewBag.yeucaus = yeucauService.findbyusername(username);
        ViewBag.nhanviens = nhanVienService.findAll().Where(n => n.Quyen == 2).ToList();
        return View("nvDetails");
    }
    [HttpPost]
    [Route("asign")]
    public IActionResult Asign(string username, int YeuCauId)
    {
        var yeuCau = yeucauService.findbyId(YeuCauId);
        yeuCau.ManvXuly = username;
        if (yeucauService.Update(yeuCau))
        {
            return new JsonResult(new
            {
                msg = "Asign success"
            });
        }
        else
        {
            return new JsonResult(new
            {
                msg = "Asign fail"
            });
        }
    }
}
