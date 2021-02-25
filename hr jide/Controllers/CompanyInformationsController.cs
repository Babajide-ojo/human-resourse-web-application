using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hr_jide.Data;
using hr_jide.Models;

namespace hr_jide.Controllers
{
    public class CompanyInformationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyInformationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompanyInformations
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyInformation.ToListAsync());
        }

        // GET: CompanyInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyInformation = await _context.CompanyInformation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyInformation == null)
            {
                return NotFound();
            }

            return View(companyInformation);
        }

        // GET: CompanyInformations/Create
      
        // GET: CompanyInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyInformation = await _context.CompanyInformation.FindAsync(id);
            if (companyInformation == null)
            {
                return NotFound();
            }
            return View(companyInformation);
        }

        // POST: CompanyInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrganizationName,TaxId,NumberOfEmployees,RegistrationNumber,PhoneNumber,Fax,Email,Address,City,PostalCode,Country,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] CompanyInformation companyInformation)
        {
            if (id != companyInformation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyInformationExists(companyInformation.Id))
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
            return View(companyInformation);
        }

        // GET: CompanyInformations/Delete/5
       

        private bool CompanyInformationExists(int id)
        {
            return _context.CompanyInformation.Any(e => e.Id == id);
        }
    }
}
