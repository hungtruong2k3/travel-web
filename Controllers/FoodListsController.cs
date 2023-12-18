using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Btl.Data;
using Btl.Models;

namespace Btl.Controllers
{
    public class FoodListsController : Controller
    {
        private readonly BtlContext _context;

        public FoodListsController(BtlContext context)
        {
            _context = context;
        }

        // GET: FoodLists
        public async Task<IActionResult> Index()
        {
            var btlContext = _context.FoodList.Include(f => f.Local);
            return View(await btlContext.ToListAsync());
        }

        // GET: FoodLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FoodList == null)
            {
                return NotFound();
            }

            var foodList = await _context.FoodList
                .Include(f => f.Local)
                .FirstOrDefaultAsync(m => m.FoodID == id);
            if (foodList == null)
            {
                return NotFound();
            }

            return View(foodList);
        }

        // GET: FoodLists/Create
        public IActionResult Create()
        {
            ViewData["LocalID"] = new SelectList(_context.Local, "LocalID", "LocalDescription");
            return View();
        }

        // POST: FoodLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodID,FoodName,FoodImage,FoodDescription,LocalID")] FoodList foodList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocalID"] = new SelectList(_context.Local, "LocalID", "LocalDescription", foodList.LocalID);
            return View(foodList);
        }

        // GET: FoodLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FoodList == null)
            {
                return NotFound();
            }

            var foodList = await _context.FoodList.FindAsync(id);
            if (foodList == null)
            {
                return NotFound();
            }
            ViewData["LocalID"] = new SelectList(_context.Local, "LocalID", "LocalDescription", foodList.LocalID);
            return View(foodList);
        }

        // POST: FoodLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodID,FoodName,FoodImage,FoodDescription,LocalID")] FoodList foodList)
        {
            if (id != foodList.FoodID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodListExists(foodList.FoodID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocalID"] = new SelectList(_context.Local, "LocalID", "LocalDescription", foodList.LocalID);
            return View(foodList);
        }

        // GET: FoodLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FoodList == null)
            {
                return NotFound();
            }

            var foodList = await _context.FoodList
                .Include(f => f.Local)
                .FirstOrDefaultAsync(m => m.FoodID == id);
            if (foodList == null)
            {
                return NotFound();
            }

            return View(foodList);
        }

        // POST: FoodLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FoodList == null)
            {
                return Problem("Entity set 'BtlContext.FoodList'  is null.");
            }
            var foodList = await _context.FoodList.FindAsync(id);
            if (foodList != null)
            {
                _context.FoodList.Remove(foodList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodListExists(int id)
        {
          return (_context.FoodList?.Any(e => e.FoodID == id)).GetValueOrDefault();
        }
    }
}
