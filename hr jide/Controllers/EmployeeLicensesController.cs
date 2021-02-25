using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hr_jide.Data;
using hr_jide.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace hr_jide.Controllers
{
    public class EmployeeLicensesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeLicensesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeLicenses
        public async Task<IActionResult> Index()
        {
            string user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.user = user;
            var employed = await _context.EmployeeLicenses
               .FromSqlRaw("select * from EmployeeLicenses").Where(b => b.EmployeeId == user)
               .ToListAsync();

            return View(employed);
        }
        public async Task<IActionResult> All()
        {
            return View(await _context.EmployeeLicenses.ToListAsync());
        }
        // GET: EmployeeLicenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeLicense = await _context.EmployeeLicenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeLicense == null)
            {
                return NotFound();
            }

            return View(employeeLicense);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeLicenses/Create
        public IActionResult Create()
        {
            ViewBag.data = HttpContext.Session.GetString("name");
            return View();
        }

        // POST: EmployeeLicenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,LicenseId,LicenseNumber,IssuedDate,ExpiryDate,Comment,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeLicense employeeLicense)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("name", employeeLicense.EmployeeId);
                _context.Add(employeeLicense);
                await _context.SaveChangesAsync();
                return RedirectToAction("create", "EmployeeSkills");
            }
            return View(employeeLicense);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeLicenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeLicense = await _context.EmployeeLicenses.FindAsync(id);
            if (employeeLicense == null)
            {
                return NotFound();
            }
            return View(employeeLicense);
        }

        // POST: EmployeeLicenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,LicenseId,LicenseNumber,IssuedDate,ExpiryDate,Comment,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeLicense employeeLicense)
        {
            if (id != employeeLicense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeLicense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeLicenseExists(employeeLicense.Id))
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
            return View(employeeLicense);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeLicenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeLicense = await _context.EmployeeLicenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeLicense == null)
            {
                return NotFound();
            }

            return View(employeeLicense);
        }

        // POST: EmployeeLicenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeLicense = await _context.EmployeeLicenses.FindAsync(id);
            _context.EmployeeLicenses.Remove(employeeLicense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        private bool EmployeeLicenseExists(int id)
        {
            return _context.EmployeeLicenses.Any(e => e.Id == id);
        }
    }
}
