using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultTestimonialComponentParial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
