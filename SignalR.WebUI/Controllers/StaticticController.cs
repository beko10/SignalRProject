using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.Controllers
{
    public class StaticticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
