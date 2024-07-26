using Microsoft.AspNetCore.Mvc;
using SupportSystems.Helpers;
using SupportSystems.Models;
using SupportSystems.Services;

namespace SupportSystems.Controllers;
[Route("nhanvien")]
public class NhanvienController : Controller
{
    private AccountService accountService;
    private IWebHostEnvironment webHostEnvironment;
    public NhanvienController(AccountService _accountService, IWebHostEnvironment _webHostEnvironment)
    {
        accountService = _accountService;
        webHostEnvironment = _webHostEnvironment;
    }
    [HttpGet]
    [Route("edit")]
    public IActionResult Edit()
    {
        var username = HttpContext.Session.GetString("username");
        var account = accountService.findByUsername(username);
        return View("edit", account);
    }

    [HttpPost]
    [Route("edit")]
    public IActionResult Edit(NhanVien nhanVien, IFormFile file)
    {
        var username = HttpContext.Session.GetString("username");
        var currentaccount = accountService.findByUsername(username);

        if (file != null && file.Length > 0)
        {
            var fileName = FileHelper.generateFileName(file.FileName);
            var path = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            currentaccount.Hinhanh = fileName;
        }
        else
        {
            currentaccount.Hinhanh = nhanVien.Hinhanh;
        }


        if (!string.IsNullOrEmpty(nhanVien.Password))
        {
            currentaccount.Password = BCrypt.Net.BCrypt.HashPassword(nhanVien.Password);
        }
        currentaccount.Hoten = nhanVien.Hoten;
        currentaccount.Ngaysinh = nhanVien.Ngaysinh;
        if (accountService.Update(currentaccount))
        {
            return RedirectToAction("Index", "home");
        }
        else
        {
            TempData["msg"] = "Update failed";
            return RedirectToAction("edit", "nhanvien");
        }
    }
}
