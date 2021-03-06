﻿using System;
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

namespace hr_jide.Controllers
{
    public class EmployeeSalaries1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeSalaries1Controller(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> All()
        {
            return View(await _context.EmployeeSalaries.ToListAsync());
        }
        // GET: EmployeeSalaries1
        public async Task<IActionResult> Index()
        {
            string user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.user = user;
            var employed = await _context.EmployeeSalaries
               .FromSqlRaw("select * from EmployeeSalaries").Where(b => b.EmployeeId == user)
               .ToListAsync();

            return View(employed);
        }

        // GET: EmployeeSalaries1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSalary = await _context.EmployeeSalaries
                .Include(e => e.PayFrequeqncy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeSalary == null)
            {
                return NotFound();
            }

            return View(employeeSalary);
        }

        // GET: EmployeeSalaries1/Create
        public IActionResult Create()
        {
            ViewBag.data = HttpContext.Session.GetString("name");
            ViewData["PayGradesId"] = new SelectList(_context.PayGrades, "Id", "Id");
            ViewData["PayFrequencyId"] = new SelectList(_context.PayFrequency, "Id", "Id");
            return View();
        }

        // POST: EmployeeSalaries1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,PayGradeId,PayFrequencyId,Currency,Amount,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeSalary employeeSalary)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("name", employeeSalary.EmployeeId);
                _context.Add(employeeSalary);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                return RedirectToAction("create", "EmployeeMemberships");
            }
            ViewData["PayGradesId"] = new SelectList(_context.PayGrades, "Id", "Id");
            ViewData["PayFrequencyId"] = new SelectList(_context.PayFrequency, "Id", "Id", employeeSalary.PayFrequencyId);
            return View(employeeSalary);
        }

        // GET: EmployeeSalaries1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSalary = await _context.EmployeeSalaries.FindAsync(id);
            if (employeeSalary == null)
            {
                return NotFound();
            }
            ViewData["PayGradesId"] = new SelectList(_context.PayGrades, "Id", "Id" ,employeeSalary.payGrades);
            ViewData["PayFrequencyId"] = new SelectList(_context.PayFrequency, "Id", "Id", employeeSalary.PayFrequencyId);
            return View(employeeSalary);
        }

        // POST: EmployeeSalaries1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,PayGradeId,PayFrequencyId,Currency,Amount,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] EmployeeSalary employeeSalary)
        {
            if (id != employeeSalary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeSalary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeSalaryExists(employeeSalary.Id))
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
            ViewData["PayFrequencyId"] = new SelectList(_context.PayFrequency, "Id", "Id", employeeSalary.PayFrequencyId);
            return View(employeeSalary);
        }

        // GET: EmployeeSalaries1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSalary = await _context.EmployeeSalaries
                .Include(e => e.PayFrequeqncy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeSalary == null)
            {
                return NotFound();
            }

            return View(employeeSalary);
        }

        // POST: EmployeeSalaries1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeSalary = await _context.EmployeeSalaries.FindAsync(id);
            _context.EmployeeSalaries.Remove(employeeSalary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        private bool EmployeeSalaryExists(int id)
        {
            return _context.EmployeeSalaries.Any(e => e.Id == id);
        }
    }
}
