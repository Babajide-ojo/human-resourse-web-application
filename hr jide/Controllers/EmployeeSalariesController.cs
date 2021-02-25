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
    public class EmployeeSalariesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeSalariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeSalaries
        public async Task<IActionResult> Index()
        {
            string user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.user = user;
            var employed = await _context.EmployeeSalaries
               .FromSqlRaw("select * from EmployeeSalaries").Where(b => b.EmployeeId == user)
               .ToListAsync();

            return View(employed);
        }
        public async Task<IActionResult> All()
        {
            return View(await _context.EmployeeSalaries.ToListAsync());
        }
        // GET: EmployeeSalaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSalary = await _context.EmployeeSalaries
                .Include(e => e.PayFrequeqncy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeSalary == null)
            {
                return NotFound();
            }

            return View(employeeSalary);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeSalaries/Create
        public IActionResult Create()
        {
            ViewBag.data = HttpContext.Session.GetString("name");
            ViewData["PayGradesId"] = new SelectList(_context.PayGrades, "Id", "Id");
            ViewData["PayFrequencyId"] = new SelectList(_context.PayFrequency, "Id", "Id");
            return View();
        }

        // POST: EmployeeSalaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,PayGradeId,PayFrequencyId,Currency,Amount,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeSalary employeeSalary)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("name", employeeSalary.EmployeeId);
                _context.Add(employeeSalary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PayGradesId"] = new SelectList(_context.PayGrades, "Id", "Id", employeeSalary.payGrades);
            ViewData["PayFrequencyId"] = new SelectList(_context.PayFrequency, "Id", "Id", employeeSalary.PayFrequencyId);
            return View(employeeSalary);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeSalaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSalary = await _context.EmployeeSalaries.FindAsync(id);
            if (employeeSalary == null)
            {
                return NotFound();
            }
            ViewData["PayGradesId"] = new SelectList(_context.PayGrades, "Id", "Id", employeeSalary.payGrades);
            ViewData["PayFrequencyId"] = new SelectList(_context.PayFrequency, "Id", "Id", employeeSalary.PayFrequencyId);
            return View(employeeSalary);
        }

        // POST: EmployeeSalaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,PayGradeId,PayFrequencyId,Currency,Amount,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeSalary employeeSalary)
        {
            if (id != employeeSalary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeSalary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeSalaryExists(employeeSalary.Id))
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
            ViewData["PayGradesId"] = new SelectList(_context.PayGrades, "Id", "Id", employeeSalary.payGrades);
            ViewData["PayFrequencyId"] = new SelectList(_context.PayFrequency, "Id", "Id", employeeSalary.PayFrequencyId);
            return View(employeeSalary);
        }
        [Authorize(Roles = "Admin")]

        // GET: EmployeeSalaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSalary = await _context.EmployeeSalaries
                .Include(e => e.PayFrequeqncy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeSalary == null)
            {
                return NotFound();
            }

            return View(employeeSalary);
        }

        // POST: EmployeeSalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeSalary = await _context.EmployeeSalaries.FindAsync(id);
            _context.EmployeeSalaries.Remove(employeeSalary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeSalaryExists(int id)
        {
            return _context.EmployeeSalaries.Any(e => e.Id == id);
        }
    }
}
