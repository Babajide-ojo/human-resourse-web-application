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
    public class EmployeeJobsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeJobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeJobs
        public async Task<IActionResult> Index()
        {
            string user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.user = user;
            var employed = await _context.EmployeeJobs
               .FromSqlRaw("select * from EmployeeJobs").Where(b => b.EmployeeId == user)
               .ToListAsync();

            return View(employed);
        }
        public async Task<IActionResult> All()
        {
            return View(await _context.EmployeeJobs.ToListAsync());
        }
        // GET: EmployeeJobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeJob = await _context.EmployeeJobs
                .Include(e => e.CompanyBranch)
                .Include(e => e.Department)
                .Include(e => e.JobCategories)
                .Include(e => e.JobTitles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeJob == null)
            {
                return NotFound();
            }

            return View(employeeJob);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeJobs/Create
        public IActionResult Create()
        {
            ViewBag.data = HttpContext.Session.GetString("name");
            ViewData["CompanyBranchId"] = new SelectList(_context.CompanyBranch, "Id", "City");
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name");
            ViewData["JobCategoriesId"] = new SelectList(_context.JobCategories, "Id", "Name");
            ViewData["JobTitlesId"] = new SelectList(_context.JobTitles, "Id", "Title");
            ViewData["EmploymentStatusId"] = new SelectList(_context.EmployementStatus, "Id", "Id");
            return View();
        }

        // POST: EmployeeJobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,JobTitlesId,EmploymentStatusId,DepartmentId,JobCategoriesId,CompanyBranchId,JoinedDate,ContractStartDate,ContractEndDate,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeJob employeeJob)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("name", employeeJob.EmployeeId);
                _context.Add(employeeJob);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                return RedirectToAction("create", "Employeesalaries");
            }
            ViewData["CompanyBranchId"] = new SelectList(_context.CompanyBranch, "Id", "Id", employeeJob.CompanyBranchId);
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Id", employeeJob.DepartmentId);
            ViewData["JobCategoriesId"] = new SelectList(_context.JobCategories, "Id", "Id", employeeJob.JobCategoriesId);
            ViewData["JobTitlesId"] = new SelectList(_context.JobTitles, "Id", "Id", employeeJob.JobTitlesId);
            ViewData["EmploymentStatusId"] = new SelectList(_context.EmployementStatus, "Id", "Id", employeeJob.EmploymentStatusId);
            return View(employeeJob);
           
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeJobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeJob = await _context.EmployeeJobs.FindAsync(id);
            if (employeeJob == null)
            {
                return NotFound();
            }
            ViewData["CompanyBranchId"] = new SelectList(_context.CompanyBranch, "Id", "Id", employeeJob.CompanyBranchId);
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Id", employeeJob.DepartmentId);
            ViewData["JobCategoriesId"] = new SelectList(_context.JobCategories, "Id", "Id", employeeJob.JobCategoriesId);
            ViewData["JobTitlesId"] = new SelectList(_context.JobTitles, "Id", "Id", employeeJob.JobTitlesId);
            ViewData["EmploymentStatusId"] = new SelectList(_context.EmployementStatus, "Id", "Id", employeeJob.EmploymentStatusId);
            return View(employeeJob);
        }

        // POST: EmployeeJobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,JobTitlesId,EmploymentStatusId,DepartmentId,JobCategoriesId,CompanyBranchId,JoinedDate,ContractStartDate,ContractEndDate,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeJob employeeJob)
        {
            if (id != employeeJob.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeJob);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeJobExists(employeeJob.Id))
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
            ViewData["CompanyBranchId"] = new SelectList(_context.CompanyBranch, "Id", "Id", employeeJob.CompanyBranchId);
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Id", employeeJob.DepartmentId);
            ViewData["JobCategoriesId"] = new SelectList(_context.JobCategories, "Id", "Id", employeeJob.JobCategoriesId);
            ViewData["JobTitlesId"] = new SelectList(_context.JobTitles, "Id", "Id", employeeJob.JobTitlesId);
            return View(employeeJob);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeJobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeJob = await _context.EmployeeJobs
                .Include(e => e.CompanyBranch)
                .Include(e => e.Department)
                .Include(e => e.JobCategories)
                .Include(e => e.JobTitles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeJob == null)
            {
                return NotFound();
            }

            return View(employeeJob);
        }

        // POST: EmployeeJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeJob = await _context.EmployeeJobs.FindAsync(id);
            _context.EmployeeJobs.Remove(employeeJob);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        private bool EmployeeJobExists(int id)
        {
            return _context.EmployeeJobs.Any(e => e.Id == id);
        }
    }
}
