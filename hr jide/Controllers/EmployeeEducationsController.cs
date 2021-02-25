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
    public class EmployeeEducationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeEducationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeEducations
        public async Task<IActionResult> Index()
        {
            string user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.user = user;
            var employed = await _context.EmployeeEducations
               .FromSqlRaw("select * from EmployeeEducations").Where(b => b.EmployeeId == user)
               .ToListAsync();

            return View(employed);
        }

        public async Task<IActionResult> All()
        {
            return View(await _context.EmployeeEducations.ToListAsync());
        }


       
        // GET: EmployeeEducations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeEducation = await _context.EmployeeEducations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeEducation == null)
            {
                return NotFound();
            }

            return View(employeeEducation);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeEducations/Create
        public IActionResult Create()
        {
            ViewBag.data = HttpContext.Session.GetString("name");
            return View();
        }

        // POST: EmployeeEducations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,Level,Institute,Major,Year,GPA,Title,StartDate,EndDate,Comment,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeEducation employeeEducation)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("name", employeeEducation.EmployeeId);
                _context.Add(employeeEducation);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("create", "EmployeeLanguages");
            }
             return View(employeeEducation);
            //return RedirectToAction("create", "Employeeskills");

        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeEducations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeEducation = await _context.EmployeeEducations.FindAsync(id);
            if (employeeEducation == null)
            {
                return NotFound();
            }
            return View(employeeEducation);
        }

        // POST: EmployeeEducations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,Level,Institute,Major,Year,GPA,Title,StartDate,EndDate,Comment,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeEducation employeeEducation)
        {
            if (id != employeeEducation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeEducation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeEducationExists(employeeEducation.Id))
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
            return View(employeeEducation);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeEducations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeEducation = await _context.EmployeeEducations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeEducation == null)
            {
                return NotFound();
            }

            return View(employeeEducation);
        }

        // POST: EmployeeEducations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeEducation = await _context.EmployeeEducations.FindAsync(id);
            _context.EmployeeEducations.Remove(employeeEducation);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction(nameof(All));
        }

        private bool EmployeeEducationExists(int id)
        {
            return _context.EmployeeEducations.Any(e => e.Id == id);
        }
    }
}
