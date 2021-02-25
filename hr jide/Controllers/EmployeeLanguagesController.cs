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
    public class EmployeeLanguagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeLanguagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeLanguages
        public async Task<IActionResult> Index()
        {
            string user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.user = user;
            var employed = await _context.EmployeeLanguages
               .FromSqlRaw("select * from EmployeeLanguages").Where(b => b.EmployeeId == user)
               .ToListAsync();

            return View(employed);
        }
        public async Task<IActionResult> All()
        {
            return View(await _context.EmployeeLanguages.ToListAsync());
        }
        // GET: EmployeeLanguages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeLanguage = await _context.EmployeeLanguages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeLanguage == null)
            {
                return NotFound();
            }

            return View(employeeLanguage);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeLanguages/Create
        public IActionResult Create()
        {
            ViewData["LanguageId"] = new SelectList(_context.Set<Languages>(), "Id", "Name");
            ViewBag.data = HttpContext.Session.GetString("name");
            return View();
        }

        // POST: EmployeeLanguages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,Language,Fluency,Competency,Comments,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeLanguage employeeLanguage)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("name", employeeLanguage.EmployeeId);
                _context.Add(employeeLanguage);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("create", "Employeelicenses");
            }
            return View(employeeLanguage);
            //return RedirectToAction("create", "Employeelicenses");

        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeLanguages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeLanguage = await _context.EmployeeLanguages.FindAsync(id);
            if (employeeLanguage == null)
            {
                return NotFound();
            }
            return View(employeeLanguage);
        }

        // POST: EmployeeLanguages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,Language,Fluency,Competency,Comments,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeLanguage employeeLanguage)
        {
            if (id != employeeLanguage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeLanguage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeLanguageExists(employeeLanguage.Id))
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
            return View(employeeLanguage);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeLanguages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeLanguage = await _context.EmployeeLanguages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeLanguage == null)
            {
                return NotFound();
            }

            return View(employeeLanguage);
        }

        // POST: EmployeeLanguages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeLanguage = await _context.EmployeeLanguages.FindAsync(id);
            _context.EmployeeLanguages.Remove(employeeLanguage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        private bool EmployeeLanguageExists(int id)
        {
            return _context.EmployeeLanguages.Any(e => e.Id == id);
        }
    }
}
