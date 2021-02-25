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
    public class JobCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobCategories.ToListAsync());
        }

        // GET: JobCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCategories = await _context.JobCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobCategories == null)
            {
                return NotFound();
            }

            return View(jobCategories);
        }

        // GET: JobCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] JobCategories jobCategories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobCategories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobCategories);
        }

        // GET: JobCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCategories = await _context.JobCategories.FindAsync(id);
            if (jobCategories == null)
            {
                return NotFound();
            }
            return View(jobCategories);
        }

        // POST: JobCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] JobCategories jobCategories)
        {
            if (id != jobCategories.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobCategories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobCategoriesExists(jobCategories.Id))
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
            return View(jobCategories);
        }

        // GET: JobCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCategories = await _context.JobCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobCategories == null)
            {
                return NotFound();
            }

            return View(jobCategories);
        }

        // POST: JobCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobCategories = await _context.JobCategories.FindAsync(id);
            _context.JobCategories.Remove(jobCategories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobCategoriesExists(int id)
        {
            return _context.JobCategories.Any(e => e.Id == id);
        }
    }
}
