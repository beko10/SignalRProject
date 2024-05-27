using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.MenuComponents
{
    public class _MenuNavBarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
