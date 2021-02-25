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
    public class PayGradesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PayGradesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PayGrades
        public async Task<IActionResult> Index()
        {
            return View(await _context.PayGrades.ToListAsync());
        }

        // GET: PayGrades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payGrades = await _context.PayGrades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payGrades == null)
            {
                return NotFound();
            }

            return View(payGrades);
        }

        // GET: PayGrades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PayGrades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Currency,MinimumSalary,MaximumSalary,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] PayGrades payGrades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payGrades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(payGrades);
        }

        // GET: PayGrades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payGrades = await _context.PayGrades.FindAsync(id);
            if (payGrades == null)
            {
                return NotFound();
            }
            return View(payGrades);
        }

        // POST: PayGrades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Currency,MinimumSalary,MaximumSalary,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] PayGrades payGrades)
        {
            if (id != payGrades.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payGrades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayGradesExists(payGrades.Id))
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
            return View(payGrades);
        }

        // GET: PayGrades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payGrades = await _context.PayGrades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payGrades == null)
            {
                return NotFound();
            }

            return View(payGrades);
        }

        // POST: PayGrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payGrades = await _context.PayGrades.FindAsync(id);
            _context.PayGrades.Remove(payGrades);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PayGradesExists(int id)
        {
            return _context.PayGrades.Any(e => e.Id == id);
        }
    }
}
