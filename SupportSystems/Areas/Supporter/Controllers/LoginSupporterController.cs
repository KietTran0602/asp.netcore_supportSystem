using Microsoft.AspNetCore.Mvc;
using SupportSystems.Services;

namespace SupportSystems.Areas.Supporter.Controllers;
[Area("supporter")]
[Route("supporter")]
[Route("supporter/login")]
public class LoginSupporterController : Controller
{
    AccountService accountService;
    public LoginSupporterController(AccountService _accountService)
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
            if (account.Quyen == 2)
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("index", "home", new { Area = "supporter" });
            }
            else
            {
                TempData["Msg"] = "Restricted";
                return RedirectToAction("index", "login", new { Area = "supporter" });
            }
        }
        else
        {
            TempData["Msg"] = "Wrong username or password";
            return RedirectToAction("index", "login", new { Area = "supporter" });
        }
    }

    [Route("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("username");
        return RedirectToAction("index", "login", new { Area = "supporter" });
    }
}
