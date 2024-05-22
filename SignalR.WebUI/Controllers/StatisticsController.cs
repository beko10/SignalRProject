using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
