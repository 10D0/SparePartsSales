using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChiVauVa.Data;
using ChiVauVa.Models;

namespace ChiVauVa.Controllers
{
    public class PriceHistoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PriceHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PriceHistory
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PriceHistories.Include(p => p.Part);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PriceHistory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceHistory = await _context.PriceHistories
                .Include(p => p.Part)
                .FirstOrDefaultAsync(m => m.PriceId == id);
            if (priceHistory == null)
            {
                return NotFound();
            }

            return View(priceHistory);
        }

        // GET: PriceHistory/Create
        public IActionResult Create()
        {
            ViewData["PartId"] = new SelectList(_context.Parts, "PartId", "PartId");
            return View();
        }

        // POST: PriceHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PriceId,PartId,Price,EffectiveDate,EndDate")] PriceHistory priceHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(priceHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartId"] = new SelectList(_context.Parts, "PartId", "PartId", priceHistory.PartId);
            return View(priceHistory);
        }

        // GET: PriceHistory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceHistory = await _context.PriceHistories.FindAsync(id);
            if (priceHistory == null)
            {
                return NotFound();
            }
            ViewData["PartId"] = new SelectList(_context.Parts, "PartId", "PartId", priceHistory.PartId);
            return View(priceHistory);
        }

        // POST: PriceHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PriceId,PartId,Price,EffectiveDate,EndDate")] PriceHistory priceHistory)
        {
            if (id != priceHistory.PriceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(priceHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriceHistoryExists(priceHistory.PriceId))
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
            ViewData["PartId"] = new SelectList(_context.Parts, "PartId", "PartId", priceHistory.PartId);
            return View(priceHistory);
        }

        // GET: PriceHistory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceHistory = await _context.PriceHistories
                .Include(p => p.Part)
                .FirstOrDefaultAsync(m => m.PriceId == id);
            if (priceHistory == null)
            {
                return NotFound();
            }

            return View(priceHistory);
        }

        // POST: PriceHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var priceHistory = await _context.PriceHistories.FindAsync(id);
            if (priceHistory != null)
            {
                _context.PriceHistories.Remove(priceHistory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PriceHistoryExists(int id)
        {
            return _context.PriceHistories.Any(e => e.PriceId == id);
        }
    }
}
