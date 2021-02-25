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
    public class EmployeeMembershipsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeMembershipsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeMemberships
        public async Task<IActionResult> Index()
        {
            string user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.user = user;
            var employed = await _context.EmployeeMemberships
               .FromSqlRaw("select * from EmployeeMemberships").Where(b => b.EmployeeId == user)
               .ToListAsync();

            return View(employed);
        }
        public async Task<IActionResult> All()
        {
            return View(await _context.EmployeeMemberships.ToListAsync());
        }
        // GET: EmployeeMemberships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeMembership = await _context.EmployeeMemberships
                .Include(e => e.Membership)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeMembership == null)
            {
                return NotFound();
            }

            return View(employeeMembership);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeMemberships/Create
        public IActionResult Create()
        {
            ViewBag.data = HttpContext.Session.GetString("name");
            ViewData["MembershipId"] = new SelectList(_context.Membership, "Id", "Id");
            return View();
        }

        // POST: EmployeeMemberships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,MembershipId,ReportMethodId,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeMembership employeeMembership)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("name", employeeMembership.EmployeeId);
                _context.Add(employeeMembership);
                await _context.SaveChangesAsync();
                return RedirectToAction("create", "Employeesupervisors");
                // return RedirectToAction(nameof(Index));
            }
            ViewData["MembershipId"] = new SelectList(_context.Membership, "Id", "Id", employeeMembership.MembershipId);
            return View(employeeMembership);
           // return RedirectToAction("create", "Employeesupervisors");
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeMemberships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeMembership = await _context.EmployeeMemberships.FindAsync(id);
            if (employeeMembership == null)
            {
                return NotFound();
            }
            ViewData["MembershipId"] = new SelectList(_context.Membership, "Id", "Id", employeeMembership.MembershipId);
            return View(employeeMembership);
        }

        // POST: EmployeeMemberships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,MembershipId,ReportMethodId,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeMembership employeeMembership)
        {
            if (id != employeeMembership.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeMembership);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeMembershipExists(employeeMembership.Id))
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
            ViewData["MembershipId"] = new SelectList(_context.Membership, "Id", "Id", employeeMembership.MembershipId);
            return View(employeeMembership);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeMemberships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeMembership = await _context.EmployeeMemberships
                .Include(e => e.Membership)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeMembership == null)
            {
                return NotFound();
            }

            return View(employeeMembership);
        }

        // POST: EmployeeMemberships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeMembership = await _context.EmployeeMemberships.FindAsync(id);
            _context.EmployeeMemberships.Remove(employeeMembership);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        private bool EmployeeMembershipExists(int id)
        {
            return _context.EmployeeMemberships.Any(e => e.Id == id);
        }
    }
}
