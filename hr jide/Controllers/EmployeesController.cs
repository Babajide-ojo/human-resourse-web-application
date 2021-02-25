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
using System.IO;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace hr_jide.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostEnvironment hostEnvironment;
        public EmployeesController(ApplicationDbContext context, IHostEnvironment hostEnvironment)
        {
            _context = context;
            this.hostEnvironment = hostEnvironment;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            string user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.user = user;
            var employed = await _context.Employee
               .FromSqlRaw("select * from Employee").Where(b => b.EmployeeId == user)
               .ToListAsync();

            return View(employed);
            //return View(await _context.Employee.ToListAsync());
        }
        public async Task<IActionResult> All()
        {
            return View(await _context.Employee.ToListAsync());
        }
        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        [Authorize(Roles = "Admin")]
        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewBag.data = HttpContext.Session.GetString("name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,FirstName,MiddleName,LastName,Photograph,Gender,Nationality,MaritalStatus,DateOfBirth,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photograph != null)
                {

                    string uploadsFolder = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot/images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photograph.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photograph.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Employee newEmployee = new Employee
                {
                    EmployeeId = model.EmployeeId,
                    Photograph = uniqueFileName
                };
                HttpContext.Session.SetString("name", model.EmployeeId);
                _context.Add(newEmployee);
                await _context.SaveChangesAsync();
                int id = newEmployee.Id;
                return RedirectToAction("create", "Employeecontactdetails");
                //return RedirectToAction("details", new { id = newEmployee.Id });
                //return Redirect("/Identity/Account/Register");
            }
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,FirstName,MiddleName,LastName,Photograph,Gender,Nationality,MaritalStatus,DateOfBirth,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            return View(employee);
        }
        [Authorize(Roles = "Admin")]
        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
