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
    public class EmployeeContactDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeContactDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeContactDetails
        public async Task<IActionResult> Index()
        {
            string user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.user = user;
            var employed = await _context.EmployeeContactDetails
               .FromSqlRaw("select * from EmployeeContactDetails").Where(b => b.EmployeeId == user)
               .ToListAsync();

            return View(employed);
        }

        public async Task<IActionResult> All()
        {
            return View(await _context.EmployeeContactDetails.ToListAsync());
        }

        // GET: EmployeeContactDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeContactDetails = await _context.EmployeeContactDetails
                .Include(e => e.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeContactDetails == null)
            {
                return NotFound();
            }

            return View(employeeContactDetails);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeContactDetails/Create
        public IActionResult Create()
        {
            ViewBag.data = HttpContext.Session.GetString("name");
            ViewData["CountryId"] = new SelectList(_context.Set<Country>(), "Id", "Id");
            return View();
        }

        // POST: EmployeeContactDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,PhoneNumber,Mobile,WorkTelephone,Fax,WorkEmail,OtherEmail,CountryId,Address,City_or_state_or_province,PostalCode,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeContactDetails employeeContactDetails)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("name", employeeContactDetails.EmployeeId);
                _context.Add(employeeContactDetails);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("create", "Employeeemergencycontacts");
            }
            ViewData["CountryId"] = new SelectList(_context.Set<Country>(), "Id", "Id", employeeContactDetails.CountryId);
            return View(employeeContactDetails);
           // return RedirectToAction("create", "Employeeemergencycontacts");
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeContactDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeContactDetails = await _context.EmployeeContactDetails.FindAsync(id);
            if (employeeContactDetails == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Set<Country>(), "Id", "Id", employeeContactDetails.CountryId);
            return View(employeeContactDetails);
        }

        // POST: EmployeeContactDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,PhoneNumber,Mobile,WorkTelephone,Fax,WorkEmail,OtherEmail,CountryId,Address,City_or_state_or_province,PostalCode,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeContactDetails employeeContactDetails)
        {
            if (id != employeeContactDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeContactDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeContactDetailsExists(employeeContactDetails.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Set<Country>(), "Id", "Id", employeeContactDetails.CountryId);
            return View(employeeContactDetails);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeContactDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeContactDetails = await _context.EmployeeContactDetails
                .Include(e => e.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeContactDetails == null)
            {
                return NotFound();
            }

            return View(employeeContactDetails);
        }
        [Authorize(Roles = "Admin")]
        // POST: EmployeeContactDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeContactDetails = await _context.EmployeeContactDetails.FindAsync(id);
            _context.EmployeeContactDetails.Remove(employeeContactDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        private bool EmployeeContactDetailsExists(int id)
        {
            return _context.EmployeeContactDetails.Any(e => e.Id == id);
        }
    }
}
