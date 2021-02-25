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
    public class CompanyBranchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyBranchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompanyBranches
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyBranch.ToListAsync());
        }

        // GET: CompanyBranches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyBranch = await _context.CompanyBranch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyBranch == null)
            {
                return NotFound();
            }

            return View(companyBranch);
        }

        // GET: CompanyBranches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyBranches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LocationName,City,Country,DateCreated,DateModified,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] CompanyBranch companyBranch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyBranch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyBranch);
        }

        // GET: CompanyBranches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyBranch = await _context.CompanyBranch.FindAsync(id);
            if (companyBranch == null)
            {
                return NotFound();
            }
            return View(companyBranch);
        }

        // POST: CompanyBranches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LocationName,City,Country,DateCreated,DateModified,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] CompanyBranch companyBranch)
        {
            if (id != companyBranch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyBranch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyBranchExists(companyBranch.Id))
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
            return View(companyBranch);
        }

        // GET: CompanyBranches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyBranch = await _context.CompanyBranch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyBranch == null)
            {
                return NotFound();
            }

            return View(companyBranch);
        }

        // POST: CompanyBranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyBranch = await _context.CompanyBranch.FindAsync(id);
            _context.CompanyBranch.Remove(companyBranch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyBranchExists(int id)
        {
            return _context.CompanyBranch.Any(e => e.Id == id);
        }
    }
}
