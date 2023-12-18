using Btl.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Btl.Controllers
{
	[ViewComponent(Name = "_Local")]
	public class LocalViewComponent : ViewComponent
	{
		private readonly BtlContext _context;

		public LocalViewComponent(BtlContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			var _Local = _context.Local.ToList();
			return View("Local",_Local); 
		}
	}
}
