using Btl.Infrastructure;
using Btl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Btl.Controllers
{
	public class CartWidget: ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			
			return View(HttpContext.Session.GetJson<Cart>("cart"));
		}
	}
}
