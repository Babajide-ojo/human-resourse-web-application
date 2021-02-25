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
    public class ReportingMethodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportingMethodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReportingMethods
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReportingMethod.ToListAsync());
        }

        // GET: ReportingMethods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportingMethod = await _context.ReportingMethod
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportingMethod == null)
            {
                return NotFound();
            }

            return View(reportingMethod);
        }

        // GET: ReportingMethods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReportingMethods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] ReportingMethod reportingMethod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportingMethod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reportingMethod);
        }

        // GET: ReportingMethods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportingMethod = await _context.ReportingMethod.FindAsync(id);
            if (reportingMethod == null)
            {
                return NotFound();
            }
            return View(reportingMethod);
        }

        // POST: ReportingMethods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] ReportingMethod reportingMethod)
        {
            if (id != reportingMethod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportingMethod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportingMethodExists(reportingMethod.Id))
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
            return View(reportingMethod);
        }

        // GET: ReportingMethods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportingMethod = await _context.ReportingMethod
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportingMethod == null)
            {
                return NotFound();
            }

            return View(reportingMethod);
        }

        // POST: ReportingMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportingMethod = await _context.ReportingMethod.FindAsync(id);
            _context.ReportingMethod.Remove(reportingMethod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportingMethodExists(int id)
        {
            return _context.ReportingMethod.Any(e => e.Id == id);
        }
    }
}
