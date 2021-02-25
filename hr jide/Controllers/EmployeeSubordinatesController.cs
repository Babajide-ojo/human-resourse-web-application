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
    public class EmployeeSubordinatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeSubordinatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeSubordinates
        public async Task<IActionResult> Index()
        {
            string user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.user = user;
            var employed = await _context.EmployeeSubordinates
               .FromSqlRaw("select * from EmployeeSubordinates").Where(b => b.EmployeeId == user)
               .ToListAsync();

            return View(employed);
        }
        public async Task<IActionResult> All()
        {
            return View(await _context.EmployeeSubordinates.ToListAsync());
        }
        // GET: EmployeeSubordinates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSubordinate = await _context.EmployeeSubordinates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeSubordinate == null)
            {
                return NotFound();
            }

            return View(employeeSubordinate);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeSubordinates/Create
        public IActionResult Create()
        {
            ViewBag.data = HttpContext.Session.GetString("name");
            return View();
        }

        // POST: EmployeeSubordinates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,Name,ReportingMethod,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeSubordinate employeeSubordinate)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("name", employeeSubordinate.EmployeeId);
                _context.Add(employeeSubordinate);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("create", "Employeeworkexperiences");
            }
            return View(employeeSubordinate);
           // return RedirectToAction("create", "Employeeworkexperiences");
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeSubordinates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSubordinate = await _context.EmployeeSubordinates.FindAsync(id);
            if (employeeSubordinate == null)
            {
                return NotFound();
            }
            return View(employeeSubordinate);
        }

        // POST: EmployeeSubordinates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,Name,ReportingMethod,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeSubordinate employeeSubordinate)
        {
            if (id != employeeSubordinate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeSubordinate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeSubordinateExists(employeeSubordinate.Id))
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
            return View(employeeSubordinate);
        }

        // GET: EmployeeSubordinates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSubordinate = await _context.EmployeeSubordinates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeSubordinate == null)
            {
                return NotFound();
            }

            return View(employeeSubordinate);
        }
        [Authorize(Roles = "Admin")]
        // POST: EmployeeSubordinates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeSubordinate = await _context.EmployeeSubordinates.FindAsync(id);
            _context.EmployeeSubordinates.Remove(employeeSubordinate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        private bool EmployeeSubordinateExists(int id)
        {
            return _context.EmployeeSubordinates.Any(e => e.Id == id);
        }
    }
}
