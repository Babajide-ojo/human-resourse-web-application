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
    public class EmployeeSupervisorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeSupervisorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeSupervisors
        public async Task<IActionResult> Index()
        {

            string user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.user = user;
            var employed = await _context.EmployeeSupervisors
               .FromSqlRaw("select * from EmployeeSupervisors").Where(b => b.EmployeeId == user)
               .ToListAsync();

            return View(employed);

        }
        public async Task<IActionResult> All()
        {
            return View(await _context.EmployeeSupervisors.ToListAsync());
        }
        // GET: EmployeeSupervisors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSupervisor = await _context.EmployeeSupervisors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeSupervisor == null)
            {
                return NotFound();
            }

            return View(employeeSupervisor);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeSupervisors/Create
        public IActionResult Create()
        {
            ViewBag.data = HttpContext.Session.GetString("name");
            return View();
        }

        // POST: EmployeeSupervisors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,Name,ReportingMethod,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeSupervisor employeeSupervisor)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("name", employeeSupervisor.EmployeeId);
                _context.Add(employeeSupervisor);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("create", "Employeesubordinates");
            }
            return View(employeeSupervisor);
           // return RedirectToAction("create", "Employeesubordinates");
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeSupervisors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSupervisor = await _context.EmployeeSupervisors.FindAsync(id);
            if (employeeSupervisor == null)
            {
                return NotFound();
            }
            return View(employeeSupervisor);
        }

        // POST: EmployeeSupervisors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,Name,ReportingMethod,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeSupervisor employeeSupervisor)
        {
            if (id != employeeSupervisor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeSupervisor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeSupervisorExists(employeeSupervisor.Id))
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
            return View(employeeSupervisor);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeSupervisors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSupervisor = await _context.EmployeeSupervisors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeSupervisor == null)
            {
                return NotFound();
            }

            return View(employeeSupervisor);
        }

        // POST: EmployeeSupervisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeSupervisor = await _context.EmployeeSupervisors.FindAsync(id);
            _context.EmployeeSupervisors.Remove(employeeSupervisor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        private bool EmployeeSupervisorExists(int id)
        {
            return _context.EmployeeSupervisors.Any(e => e.Id == id);
        }
    }
}
