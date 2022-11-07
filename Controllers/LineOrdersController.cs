using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POSebda3.Data;
using POSebda3.Models.SalesModels;

namespace POSebda3.Controllers
{
    public class LineOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LineOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LineOrders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LineOrders.Include(l => l.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LineOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineOrder = await _context.LineOrders
                .Include(l => l.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lineOrder == null)
            {
                return NotFound();
            }

            return View(lineOrder);
        }

        // GET: LineOrders/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: LineOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,Quantity,Rate,Amount,OrderDate")] LineOrder lineOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lineOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", lineOrder.ProductId);
            return View(lineOrder);
        }

        // GET: LineOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineOrder = await _context.LineOrders.FindAsync(id);
            if (lineOrder == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", lineOrder.ProductId);
            return View(lineOrder);
        }

        // POST: LineOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Quantity,Rate,Amount,OrderDate")] LineOrder lineOrder)
        {
            if (id != lineOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lineOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineOrderExists(lineOrder.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", lineOrder.ProductId);
            return View(lineOrder);
        }

        // GET: LineOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lineOrder = await _context.LineOrders
                .Include(l => l.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lineOrder == null)
            {
                return NotFound();
            }

            return View(lineOrder);
        }

        // POST: LineOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lineOrder = await _context.LineOrders.FindAsync(id);
            _context.LineOrders.Remove(lineOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LineOrderExists(int id)
        {
            return _context.LineOrders.Any(e => e.Id == id);
        }
    }
}
