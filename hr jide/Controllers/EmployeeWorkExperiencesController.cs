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
    public class EmployeeWorkExperiencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeWorkExperiencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeWorkExperiences
        public async Task<IActionResult> Index()
        {
            string user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.user = user;
            var employed = await _context.EmployeeWorkExperiences
               .FromSqlRaw("select * from EmployeeWorkExperiences").Where(b => b.EmployeeId == user)
               .ToListAsync();

            return View(employed);
        }
        public async Task<IActionResult> All()
        {
            return View(await _context.EmployeeWorkExperiences.ToListAsync());
        }
        // GET: EmployeeWorkExperiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeWorkExperience = await _context.EmployeeWorkExperiences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeWorkExperience == null)
            {
                return NotFound();
            }

            return View(employeeWorkExperience);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeWorkExperiences/Create
        public IActionResult Create()
        {
            ViewBag.data = HttpContext.Session.GetString("name");
            return View();
        }

        // POST: EmployeeWorkExperiences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,CompanyName,JobTitle,From,To,Comment,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeWorkExperience employeeWorkExperience)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("name", employeeWorkExperience.EmployeeId);
                _context.Add(employeeWorkExperience);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                return RedirectToAction("create", "Employeeeducations");
            }
            return View(employeeWorkExperience);
            //return RedirectToAction("create", "Employeeeducations");
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeWorkExperiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeWorkExperience = await _context.EmployeeWorkExperiences.FindAsync(id);
            if (employeeWorkExperience == null)
            {
                return NotFound();
            }
            return View(employeeWorkExperience);
        }

        // POST: EmployeeWorkExperiences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,CompanyName,JobTitle,From,To,Comment,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeWorkExperience employeeWorkExperience)
        {
            if (id != employeeWorkExperience.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeWorkExperience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeWorkExperienceExists(employeeWorkExperience.Id))
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
            return View(employeeWorkExperience);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeWorkExperiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeWorkExperience = await _context.EmployeeWorkExperiences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeWorkExperience == null)
            {
                return NotFound();
            }

            return View(employeeWorkExperience);
        }

        // POST: EmployeeWorkExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeWorkExperience = await _context.EmployeeWorkExperiences.FindAsync(id);
            _context.EmployeeWorkExperiences.Remove(employeeWorkExperience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        private bool EmployeeWorkExperienceExists(int id)
        {
            return _context.EmployeeWorkExperiences.Any(e => e.Id == id);
        }
    }
}
