using Microsoft.AspNetCore.Mvc;
using SupportSystems.Services;
//using SupportSystem.Services;

namespace SupportSystems.Areas.Admin.Controllers;

[Area("admin")]
[Route("admin")]
[Route("admin/login")]
public class LoginAdminController : Controller
{
    AccountService accountService;
    public LoginAdminController(AccountService _accountService)
    {
        accountService = _accountService;
    }

    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost]
    [Route("process")]
    public IActionResult Process(string username, string password)
    {
        if (accountService.Login(username, password))
        {
            var account = accountService.findByUsername(username);
            if (account.Quyen == 3)
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("index", "home", new { Area = "admin" });
            }
            else
            {
                TempData["Msg"] = "Restricted";
                return RedirectToAction("index", "login", new { Area = "admin" });
            }
        }
        else
        {
            TempData["Msg"] = "Wrong username or password";
            return RedirectToAction("index", "login", new { Area = "admin" });
        }
    }

    [Route("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("username");
        return RedirectToAction("index", "login", new { Area = "admin" });
    }
}
