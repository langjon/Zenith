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
    public class OrdersController : Controller
    {
        private readonly finalAssigContext _context;

        public OrdersController(finalAssigContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var finalAssigContext = _context.Orders.Include(o => o.Emp).Include(o => o.Payment).Include(o => o.Prod);
            return View(await finalAssigContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.Emp)
                .Include(o => o.Payment)
                .Include(o => o.Prod)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["EmpId"] = new SelectList(_context.Employee, "EmpId", "EmpId");
            ViewData["PaymentId"] = new SelectList(_context.Payment, "PaymentId", "PaymentId");
            ViewData["ProdId"] = new SelectList(_context.Product, "ProdId", "ProdId");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,PaymentId,EmpId,ProdId,StatusUpdate")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpId"] = new SelectList(_context.Employee, "EmpId", "EmpId", orders.EmpId);
            ViewData["PaymentId"] = new SelectList(_context.Payment, "PaymentId", "PaymentId", orders.PaymentId);
            ViewData["ProdId"] = new SelectList(_context.Product, "ProdId", "ProdId", orders.ProdId);
            return View(orders);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            ViewData["EmpId"] = new SelectList(_context.Employee, "EmpId", "EmpId", orders.EmpId);
            ViewData["PaymentId"] = new SelectList(_context.Payment, "PaymentId", "PaymentId", orders.PaymentId);
            ViewData["ProdId"] = new SelectList(_context.Product, "ProdId", "ProdId", orders.ProdId);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("OrderId,PaymentId,EmpId,ProdId,StatusUpdate")] Orders orders)
        {
            if (id != orders.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.OrderId))
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
            ViewData["EmpId"] = new SelectList(_context.Employee, "EmpId", "EmpId", orders.EmpId);
            ViewData["PaymentId"] = new SelectList(_context.Payment, "PaymentId", "PaymentId", orders.PaymentId);
            ViewData["ProdId"] = new SelectList(_context.Product, "ProdId", "ProdId", orders.ProdId);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.Emp)
                .Include(o => o.Payment)
                .Include(o => o.Prod)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var orders = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(decimal id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
