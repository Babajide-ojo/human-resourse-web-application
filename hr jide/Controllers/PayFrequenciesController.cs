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
    public class PayFrequenciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PayFrequenciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PayFrequencies
        public async Task<IActionResult> Index()
        {
            return View(await _context.PayFrequency.ToListAsync());
        }

        // GET: PayFrequencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payFrequency = await _context.PayFrequency
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payFrequency == null)
            {
                return NotFound();
            }

            return View(payFrequency);
        }

        // GET: PayFrequencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PayFrequencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] PayFrequency payFrequency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payFrequency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(payFrequency);
        }

        // GET: PayFrequencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payFrequency = await _context.PayFrequency.FindAsync(id);
            if (payFrequency == null)
            {
                return NotFound();
            }
            return View(payFrequency);
        }

        // POST: PayFrequencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] PayFrequency payFrequency)
        {
            if (id != payFrequency.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payFrequency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayFrequencyExists(payFrequency.Id))
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
            return View(payFrequency);
        }

        // GET: PayFrequencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payFrequency = await _context.PayFrequency
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payFrequency == null)
            {
                return NotFound();
            }

            return View(payFrequency);
        }

        // POST: PayFrequencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payFrequency = await _context.PayFrequency.FindAsync(id);
            _context.PayFrequency.Remove(payFrequency);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PayFrequencyExists(int id)
        {
            return _context.PayFrequency.Any(e => e.Id == id);
        }
    }
}
