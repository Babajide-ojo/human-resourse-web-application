using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hr_jide.Data;
using hr_jide.Models;

namespace hr_jide.Controllers
{
    public class Currencies1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Currencies1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Currencies1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Currencies.ToListAsync());
        }

        // GET: Currencies1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currencies = await _context.Currencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currencies == null)
            {
                return NotFound();
            }

            return View(currencies);
        }

        // GET: Currencies1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Currencies1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CurrencyCode,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] Currencies currencies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(currencies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(currencies);
        }

        // GET: Currencies1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currencies = await _context.Currencies.FindAsync(id);
            if (currencies == null)
            {
                return NotFound();
            }
            return View(currencies);
        }

        // POST: Currencies1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CurrencyCode,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] Currencies currencies)
        {
            if (id != currencies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currencies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurrenciesExists(currencies.Id))
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
            return View(currencies);
        }

        // GET: Currencies1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currencies = await _context.Currencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currencies == null)
            {
                return NotFound();
            }

            return View(currencies);
        }

        // POST: Currencies1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var currencies = await _context.Currencies.FindAsync(id);
            _context.Currencies.Remove(currencies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurrenciesExists(int id)
        {
            return _context.Currencies.Any(e => e.Id == id);
        }
    }
}
