using Microsoft.AspNetCore.Mvc;

namespace SupportSystems.Controllers;
[Route("home")]
public class HomeController : Controller
{
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        var currentUser = HttpContext.Session.GetString("username");
        if (currentUser != null)
        {
            return View("index");

        }
        else
        {
            return RedirectToAction("index", "login");
        }
    }
}
