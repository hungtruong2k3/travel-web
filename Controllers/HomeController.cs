using Btl.Data;
using Btl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Btl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly BtlContext _context;
        public int PageSize = 3;
		public HomeController(BtlContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var _food = _context.FoodList.Include(p => p.Local).ToList();
            var _location = _context.TravelLocation.ToList();
            var _blog = _context.Blog.ToList();

            var listModels = new ListModels
            {
                FoodLists = _food,
                Locations = _location,
                Blogs = _blog
            };

            return View(listModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult IndexProduct( int productPage=1)
        {
			var _product = _context.Product.Include(p => p.Local).Skip((productPage-1)*PageSize).Take(PageSize);
			return View(_product.ToList()); ;
        }
        public async Task<IActionResult> LocationDetail(int? id)
        {
            if (id == null || _context.TravelLocation == null)
            {
                return NotFound();
            }

            var location = await _context.TravelLocation.FirstOrDefaultAsync(m => m.LocationId == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }
        public async Task<IActionResult> BlogDetail(int? id)
        {
            if (id == null || _context.Blog == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog.FirstOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }
        public async Task<IActionResult> Contact([Bind("IdContact,ContactName,ContactEmail,ContactDescription")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (!IsValidEmail(contact.ContactEmail))
                {
                    ModelState.AddModelError("ContactEmail", "Email is not in a valid format.");
                    return View();
                }

                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction("Contact", "Home");
            }
            return View();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public async Task<IActionResult> Checkout([Bind("CheckoutId,CheckoutFistName,CheckoutLastName,CheckoutEmail,CheckoutPhone,CheckoutCity,CheckoutCountry,CheckoutAddress,CheckoutTotal")] Checkout checkout)
		{
			if (ModelState.IsValid)
			{
				_context.Checkouts.Add(checkout);
				await _context.SaveChangesAsync();
				return RedirectToAction("Checkout", "Home");
			}
			return View();
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}