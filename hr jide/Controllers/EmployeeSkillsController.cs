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
    public class EmployeeSkillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeSkillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeSkills
        public async Task<IActionResult> Index()
        {
            string user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.user = user;
            var employed = await _context.EmployeeSkills
               .FromSqlRaw("select * from EmployeeSkills").Where(b => b.EmployeeId == user)
               .ToListAsync();

            return View(employed);
        }
        public async Task<IActionResult> All()
        {
            return View(await _context.EmployeeSkills.ToListAsync());
        }
        // GET: EmployeeSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSkills = await _context.EmployeeSkills
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeSkills == null)
            {
                return NotFound();
            }

            return View(employeeSkills);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeSkills/Create
        public IActionResult Create()
        {
            ViewBag.data = HttpContext.Session.GetString("name");
            return View();
        }

        // POST: EmployeeSkills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,SkillId,YearsOfExperience,Comment,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeSkills employeeSkills)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("name", employeeSkills.EmployeeId);
                _context.Add(employeeSkills);
                await _context.SaveChangesAsync();
               // return RedirectToAction(nameof(Index));
                return RedirectToAction("listRoles", "Admin");
            }
            return View(employeeSkills);
            //return RedirectToAction("create", "Employeelanguages");

        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSkills = await _context.EmployeeSkills.FindAsync(id);
            if (employeeSkills == null)
            {
                return NotFound();
            }
            return View(employeeSkills);
        }

        // POST: EmployeeSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,SkillId,YearsOfExperience,Comment,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeSkills employeeSkills)
        {
            if (id != employeeSkills.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeSkills);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeSkillsExists(employeeSkills.Id))
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
            return View(employeeSkills);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSkills = await _context.EmployeeSkills
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeSkills == null)
            {
                return NotFound();
            }

            return View(employeeSkills);
        }

        // POST: EmployeeSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeSkills = await _context.EmployeeSkills.FindAsync(id);
            _context.EmployeeSkills.Remove(employeeSkills);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        private bool EmployeeSkillsExists(int id)
        {
            return _context.EmployeeSkills.Any(e => e.Id == id);
        }
    }
}
