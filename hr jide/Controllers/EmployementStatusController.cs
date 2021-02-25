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
    public class EmployementStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployementStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployementStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployementStatus.ToListAsync());
        }

        // GET: EmployementStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employementStatus = await _context.EmployementStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employementStatus == null)
            {
                return NotFound();
            }

            return View(employementStatus);
        }

        // GET: EmployementStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployementStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployementStatus employementStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employementStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employementStatus);
        }

        // GET: EmployementStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employementStatus = await _context.EmployementStatus.FindAsync(id);
            if (employementStatus == null)
            {
                return NotFound();
            }
            return View(employementStatus);
        }

        // POST: EmployementStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployementStatus employementStatus)
        {
            if (id != employementStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employementStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployementStatusExists(employementStatus.Id))
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
            return View(employementStatus);
        }

        // GET: EmployementStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employementStatus = await _context.EmployementStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employementStatus == null)
            {
                return NotFound();
            }

            return View(employementStatus);
        }

        // POST: EmployementStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employementStatus = await _context.EmployementStatus.FindAsync(id);
            _context.EmployementStatus.Remove(employementStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployementStatusExists(int id)
        {
            return _context.EmployementStatus.Any(e => e.Id == id);
        }
    }
}
