using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.LayoutComponent
{
	public class _LayoutSideBarPartialComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();	
		}
	}
}
