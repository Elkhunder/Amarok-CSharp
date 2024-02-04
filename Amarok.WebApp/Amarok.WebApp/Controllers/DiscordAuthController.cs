using Microsoft.AspNetCore.Mvc;

namespace Amarok.WebApp.Server.Controllers
{
    public class DiscordAuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
