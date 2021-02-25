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
    public class EmployeeEmergencyContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeEmergencyContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeEmergencyContacts
        public async Task<IActionResult> Index()
        {
            string user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.user = user;
            var employed = await _context.EmployeeEmergencyContacts
               .FromSqlRaw("select * from EmployeeEmergencyContacts").Where(b => b.EmployeeId == user).ToListAsync();

            return View(employed);
            //return View(await _context.EmployeeEmergencyContacts.ToListAsync());
        }

        public async Task<IActionResult> All()
        {
            return View(await _context.EmployeeEmergencyContacts.ToListAsync());
        }
        // GET: EmployeeEmergencyContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeEmergencyContact = await _context.EmployeeEmergencyContacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeEmergencyContact == null)
            {
                return NotFound();
            }

            return View(employeeEmergencyContact);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeEmergencyContacts/Create
        public IActionResult Create()
        {
            ViewBag.data = HttpContext.Session.GetString("name");
            return View();
        }

        // POST: EmployeeEmergencyContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,Name,Relationship,HomeTelephone,Mobile,WorkTelephone,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeEmergencyContact employeeEmergencyContact)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("name", employeeEmergencyContact.EmployeeId);
                _context.Add(employeeEmergencyContact);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("create", "Employeedependants");
            }
            // return View(employeeEmergencyContact);
            return RedirectToAction("create", "Employeedependants");
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeEmergencyContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeEmergencyContact = await _context.EmployeeEmergencyContacts.FindAsync(id);
            if (employeeEmergencyContact == null)
            {
                return NotFound();
            }
            return View(employeeEmergencyContact);
        }

        // POST: EmployeeEmergencyContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,Name,Relationship,HomeTelephone,Mobile,WorkTelephone,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeEmergencyContact employeeEmergencyContact)
        {
            if (id != employeeEmergencyContact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeEmergencyContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeEmergencyContactExists(employeeEmergencyContact.Id))
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
            return View(employeeEmergencyContact);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeEmergencyContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeEmergencyContact = await _context.EmployeeEmergencyContacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeEmergencyContact == null)
            {
                return NotFound();
            }

            return View(employeeEmergencyContact);
        }

        // POST: EmployeeEmergencyContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeEmergencyContact = await _context.EmployeeEmergencyContacts.FindAsync(id);
            _context.EmployeeEmergencyContacts.Remove(employeeEmergencyContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(All));
            //return RedirectToAction(nameof(Index));
        }

        private bool EmployeeEmergencyContactExists(int id)
        {
            return _context.EmployeeEmergencyContacts.Any(e => e.Id == id);
        }
    }
}
