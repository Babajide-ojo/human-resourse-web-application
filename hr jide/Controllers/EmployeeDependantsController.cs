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
    public class EmployeeDependantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeDependantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeDependants
        public async Task<IActionResult> Index()
        {
            string user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.user = user;
            var employed = await _context.EmployeeDependants
               .FromSqlRaw("select * from EmployeeDependants").Where(b => b.EmployeeId == user)
               .ToListAsync();

            return View(employed);
        }

        public async Task<IActionResult> All()
        {
            return View(await _context.EmployeeDependants.ToListAsync());
        }
        // GET: EmployeeDependants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDependant = await _context.EmployeeDependants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeDependant == null)
            {
                return NotFound();
            }

            return View(employeeDependant);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeDependants/Create
        public IActionResult Create()
        {
            ViewBag.data = HttpContext.Session.GetString("name");
            return View();
        }

        // POST: EmployeeDependants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,Name,Relationship,DateOfBirth,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeDependant employeeDependant)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("name", employeeDependant.EmployeeId);
                _context.Add(employeeDependant);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("create", "Employeeimmigrations");
            }
            // return View(employeeDependant);
            return RedirectToAction("create", "EmployeeDependants");
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeDependants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDependant = await _context.EmployeeDependants.FindAsync(id);
            if (employeeDependant == null)
            {
                return NotFound();
            }
            return View(employeeDependant);
        }

        // POST: EmployeeDependants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,Name,Relationship,DateOfBirth,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeDependant employeeDependant)
        {
            if (id != employeeDependant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeDependant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDependantExists(employeeDependant.Id))
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
            return View(employeeDependant);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeDependants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDependant = await _context.EmployeeDependants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeDependant == null)
            {
                return NotFound();
            }

            return View(employeeDependant);
        }

        // POST: EmployeeDependants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeDependant = await _context.EmployeeDependants.FindAsync(id);
            _context.EmployeeDependants.Remove(employeeDependant);
            await _context.SaveChangesAsync();
            // return RedirectToAction(nameof(Index));
            return RedirectToAction(nameof(All));
        }

        private bool EmployeeDependantExists(int id)
        {
            return _context.EmployeeDependants.Any(e => e.Id == id);
        }
    }
}
