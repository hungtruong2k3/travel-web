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
    public class TravelLocationsController : Controller
    {
        private readonly BtlContext _context;

        public TravelLocationsController(BtlContext context)
        {
            _context = context;
        }

        // GET: TravelLocations
        public async Task<IActionResult> Index()
        {
              return _context.TravelLocation != null ? 
                          View(await _context.TravelLocation.ToListAsync()) :
                          Problem("Entity set 'BtlContext.TravelLocation'  is null.");
        }

        // GET: TravelLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TravelLocation == null)
            {
                return NotFound();
            }

            var travelLocation = await _context.TravelLocation
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (travelLocation == null)
            {
                return NotFound();
            }

            return View(travelLocation);
        }

        // GET: TravelLocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TravelLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationId,LocationName,LocationDescription,LocationImage")] TravelLocation travelLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(travelLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(travelLocation);
        }

        // GET: TravelLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TravelLocation == null)
            {
                return NotFound();
            }

            var travelLocation = await _context.TravelLocation.FindAsync(id);
            if (travelLocation == null)
            {
                return NotFound();
            }
            return View(travelLocation);
        }

        // POST: TravelLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationId,LocationName,LocationDescription,LocationImage")] TravelLocation travelLocation)
        {
            if (id != travelLocation.LocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travelLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelLocationExists(travelLocation.LocationId))
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
            return View(travelLocation);
        }

        // GET: TravelLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TravelLocation == null)
            {
                return NotFound();
            }

            var travelLocation = await _context.TravelLocation
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (travelLocation == null)
            {
                return NotFound();
            }

            return View(travelLocation);
        }

        // POST: TravelLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TravelLocation == null)
            {
                return Problem("Entity set 'BtlContext.TravelLocation'  is null.");
            }
            var travelLocation = await _context.TravelLocation.FindAsync(id);
            if (travelLocation != null)
            {
                _context.TravelLocation.Remove(travelLocation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelLocationExists(int id)
        {
          return (_context.TravelLocation?.Any(e => e.LocationId == id)).GetValueOrDefault();
        }
    }
}
