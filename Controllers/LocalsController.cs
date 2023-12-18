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
    public class LocalsController : Controller
    {
        private readonly BtlContext _context;

        public LocalsController(BtlContext context)
        {
            _context = context;
        }

        // GET: Locals
        public async Task<IActionResult> Index()
        {
              return _context.Local != null ? 
                          View(await _context.Local.ToListAsync()) :
                          Problem("Entity set 'BtlContext.Local'  is null.");
        }

        // GET: Locals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Local == null)
            {
                return NotFound();
            }

            var local = await _context.Local
                .FirstOrDefaultAsync(m => m.LocalID == id);
            if (local == null)
            {
                return NotFound();
            }

            return View(local);
        }

        // GET: Locals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocalID,LocalName,LocalDescription")] Local local)
        {
            if (ModelState.IsValid)
            {
                _context.Add(local);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(local);
        }

        // GET: Locals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Local == null)
            {
                return NotFound();
            }

            var local = await _context.Local.FindAsync(id);
            if (local == null)
            {
                return NotFound();
            }
            return View(local);
        }

        // POST: Locals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocalID,LocalName,LocalDescription")] Local local)
        {
            if (id != local.LocalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(local);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalExists(local.LocalID))
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
            return View(local);
        }

        // GET: Locals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Local == null)
            {
                return NotFound();
            }

            var local = await _context.Local
                .FirstOrDefaultAsync(m => m.LocalID == id);
            if (local == null)
            {
                return NotFound();
            }

            return View(local);
        }

        // POST: Locals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Local == null)
            {
                return Problem("Entity set 'BtlContext.Local'  is null.");
            }
            var local = await _context.Local.FindAsync(id);
            if (local != null)
            {
                _context.Local.Remove(local);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalExists(int id)
        {
          return (_context.Local?.Any(e => e.LocalID == id)).GetValueOrDefault();
        }
    }
}
