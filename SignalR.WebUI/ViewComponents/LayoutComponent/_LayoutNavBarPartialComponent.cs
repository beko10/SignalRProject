﻿using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.LayoutComponent
{
	public class _LayoutNavBarPartialComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();	
		}
	}
}
