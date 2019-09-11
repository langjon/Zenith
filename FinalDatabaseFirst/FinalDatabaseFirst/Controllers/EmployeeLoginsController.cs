using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalDatabaseFirst.Models;

namespace FinalDatabaseFirst.Controllers
{
    public class EmployeeLoginsController : Controller
    {
        private readonly finalAssigContext _context;

        public EmployeeLoginsController(finalAssigContext context)
        {
            _context = context;
        }

        // GET: EmployeeLogins
        public async Task<IActionResult> Index()
        {
            var finalAssigContext = _context.EmployeeLogin.Include(e => e.Emp);
            return View(await finalAssigContext.ToListAsync());
        }

        // GET: EmployeeLogins/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeLogin = await _context.EmployeeLogin
                .Include(e => e.Emp)
                .FirstOrDefaultAsync(m => m.EmployeeLoginId == id);
            if (employeeLogin == null)
            {
                return NotFound();
            }

            return View(employeeLogin);
        }

        // GET: EmployeeLogins/Create
        public IActionResult Create()
        {
            ViewData["EmpId"] = new SelectList(_context.Employee, "EmpId", "EmpId");
            return View();
        }

        // POST: EmployeeLogins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeLoginId,EmpId,Pass")] EmployeeLogin employeeLogin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeLogin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpId"] = new SelectList(_context.Employee, "EmpId", "EmpId", employeeLogin.EmpId);
            return View(employeeLogin);
        }

        // GET: EmployeeLogins/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeLogin = await _context.EmployeeLogin.FindAsync(id);
            if (employeeLogin == null)
            {
                return NotFound();
            }
            ViewData["EmpId"] = new SelectList(_context.Employee, "EmpId", "EmpId", employeeLogin.EmpId);
            return View(employeeLogin);
        }

        // POST: EmployeeLogins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("EmployeeLoginId,EmpId,Pass")] EmployeeLogin employeeLogin)
        {
            if (id != employeeLogin.EmployeeLoginId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeLogin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeLoginExists(employeeLogin.EmployeeLoginId))
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
            ViewData["EmpId"] = new SelectList(_context.Employee, "EmpId", "EmpId", employeeLogin.EmpId);
            return View(employeeLogin);
        }

        // GET: EmployeeLogins/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeLogin = await _context.EmployeeLogin
                .Include(e => e.Emp)
                .FirstOrDefaultAsync(m => m.EmployeeLoginId == id);
            if (employeeLogin == null)
            {
                return NotFound();
            }

            return View(employeeLogin);
        }

        // POST: EmployeeLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var employeeLogin = await _context.EmployeeLogin.FindAsync(id);
            _context.EmployeeLogin.Remove(employeeLogin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeLoginExists(decimal id)
        {
            return _context.EmployeeLogin.Any(e => e.EmployeeLoginId == id);
        }
    }
}
