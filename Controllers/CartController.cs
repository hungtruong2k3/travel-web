using Btl.Data;
using Btl.Infrastructure;
using Btl.Models;
using Microsoft.AspNetCore.Mvc;

namespace Btl.Controllers
{
    public class CartController : Controller
    {
        public Cart Cart { get; set; }
		private readonly BtlContext _context;

		public CartController(BtlContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View("cart", HttpContext.Session.GetJson<Cart>("cart"));
		}
		public IActionResult AddToCart(int ProductId)
        {
            Product? product= _context.Product.FirstOrDefault(p=>p.ProductId ==ProductId);
            if(product != null) { 
                Cart=HttpContext.Session.GetJson<Cart>("cart")?? new Cart();
                Cart.AddItem(product, 1);
                HttpContext.Session.SetJson("cart", Cart);
            
            }
			return View("Cart",Cart);
		}
		public IActionResult RemoveFromCart(int ProductId)
		{
			Product? product = _context.Product.FirstOrDefault(p => p.ProductId == ProductId);
			if (product != null)
			{
				Cart = HttpContext.Session.GetJson<Cart>("cart");
				Cart.RemoveLine(product);
				HttpContext.Session.SetJson("cart", Cart);

			}
			return View("Cart", Cart);
		}
	}
}
