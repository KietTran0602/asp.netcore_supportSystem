using Microsoft.AspNetCore.Mvc;
using SupportSystems.Services;

namespace SupportSystems.Controllers;
[Route("login")]
public class LoginController : Controller
{
    private AccountService accountService;
    public LoginController(AccountService _accountService)
    {
        accountService = _accountService;
    }
    [Route("~/")]
    [Route("")]
    public IActionResult Index()
    {
        return View("Index");
    }
    [HttpGet]
    [Route("choosing")]
    public IActionResult Choosing(string choose)
    {
        if (choose == "0")
        {
            return RedirectToAction("index", "login", new { Area = "supporter" });
        }
        else if (choose == "1")
        {
            return RedirectToAction("login");
        }
        else
        {
            TempData["msg"] = "please choose your login type";
            return View("Index");

        }
    }
    [HttpGet]
    [Route("login")]
    public IActionResult login()
    {
        return View("login");
    }


    [HttpPost]
    [Route("process")]
    public IActionResult Process(string username, string password)
    {
        if (accountService.Login(username, password))
        {
            var account = accountService.findByUsername(username);
            if (account.Quyen == 1)
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("index", "home");
            }
            else
            {
                TempData["Msg"] = "Restricted";
                return RedirectToAction("login", "login");
            }
        }
        else
        {
            TempData["Msg"] = "Wrong username or password";
            return RedirectToAction("login", "login");
        }
    }

    [Route("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("username");
        return RedirectToAction("index", "login");
    }
}
