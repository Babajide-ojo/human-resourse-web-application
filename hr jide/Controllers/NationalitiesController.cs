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
    public class NationalitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NationalitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nationalities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nationalities.ToListAsync());
        }

        // GET: Nationalities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationalities = await _context.Nationalities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nationalities == null)
            {
                return NotFound();
            }

            return View(nationalities);
        }

        // GET: Nationalities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nationalities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] Nationalities nationalities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nationalities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nationalities);
        }

        // GET: Nationalities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationalities = await _context.Nationalities.FindAsync(id);
            if (nationalities == null)
            {
                return NotFound();
            }
            return View(nationalities);
        }

        // POST: Nationalities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] Nationalities nationalities)
        {
            if (id != nationalities.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nationalities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NationalitiesExists(nationalities.Id))
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
            return View(nationalities);
        }

        // GET: Nationalities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationalities = await _context.Nationalities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nationalities == null)
            {
                return NotFound();
            }

            return View(nationalities);
        }

        // POST: Nationalities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nationalities = await _context.Nationalities.FindAsync(id);
            _context.Nationalities.Remove(nationalities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NationalitiesExists(int id)
        {
            return _context.Nationalities.Any(e => e.Id == id);
        }
    }
}
