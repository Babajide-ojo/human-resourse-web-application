using hr_jide.Data;
using hr_jide.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace hr_jide.Controllers
{
    public class EmployeeImmigrationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeImmigrationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeImmigrations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmployeeImmigrations.Include(e => e.Country).Include(e => e.DocumentType);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> All()
        {
            var applicationDbContext = _context.EmployeeImmigrations.Include(e => e.Country).Include(e => e.DocumentType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EmployeeImmigrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeImmigration = await _context.EmployeeImmigrations
                .Include(e => e.Country)
                .Include(e => e.DocumentType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeImmigration == null)
            {
                return NotFound();
            }

            return View(employeeImmigration);
        }

        // GET: EmployeeImmigrations/Create
        public IActionResult Create()
        {
            ViewBag.data = HttpContext.Session.GetString("name");
            ViewData["CountryId"] = new SelectList(_context.Set<Country>(), "Id", "Name");
            ViewData["DocumentTypeId"] = new SelectList(_context.Set<DocumentType>(), "Id", "Name");
            return View();
        }

        // POST: EmployeeImmigrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,DocumentTypeId,IssuedDate,ExpiryDate,DocumentNumber,CountryId,EligibleReviewDate,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeImmigration employeeImmigration)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("name", employeeImmigration.EmployeeId);
                _context.Add(employeeImmigration);
                await _context.SaveChangesAsync();
                return RedirectToAction("create", "EmployeeJobs");
                //return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Set<Country>(), "Id", "Id", employeeImmigration.CountryId);
            ViewData["DocumentTypeId"] = new SelectList(_context.Set<DocumentType>(), "Id", "Id", employeeImmigration.DocumentTypeId);
            return View(employeeImmigration);
        }

        // GET: EmployeeImmigrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeImmigration = await _context.EmployeeImmigrations.FindAsync(id);
            if (employeeImmigration == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Set<Country>(), "Id", "Id", employeeImmigration.CountryId);
            ViewData["DocumentTypeId"] = new SelectList(_context.Set<DocumentType>(), "Id", "Id", employeeImmigration.DocumentTypeId);
            return View(employeeImmigration);
        }

        // POST: EmployeeImmigrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,DocumentTypeId,IssuedDate,ExpiryDate,DocumentNumber,CountryId,EligibleReviewDate,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeImmigration employeeImmigration)
        {
            if (id != employeeImmigration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeImmigration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeImmigrationExists(employeeImmigration.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Set<Country>(), "Id", "Id", employeeImmigration.CountryId);
            ViewData["DocumentTypeId"] = new SelectList(_context.Set<DocumentType>(), "Id", "Id", employeeImmigration.DocumentTypeId);
            return View(employeeImmigration);
        }

        // GET: EmployeeImmigrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeImmigration = await _context.EmployeeImmigrations
                .Include(e => e.Country)
                .Include(e => e.DocumentType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeImmigration == null)
            {
                return NotFound();
            }

            return View(employeeImmigration);
        }

        // POST: EmployeeImmigrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeImmigration = await _context.EmployeeImmigrations.FindAsync(id);
            _context.EmployeeImmigrations.Remove(employeeImmigration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        private bool EmployeeImmigrationExists(int id)
        {
            return _context.EmployeeImmigrations.Any(e => e.Id == id);
        }
    }
}
