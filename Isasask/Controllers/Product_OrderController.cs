using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Isasask.Models;

namespace Isasask.Controllers
{
    public class Product_OrderController : Controller
    {
        private readonly OrdersDbContext _context;

        public Product_OrderController(OrdersDbContext context)
        {
            _context = context;
        }

        // GET: Product_Order
        public async Task<IActionResult> Index()
        {
            var ordersDbContext = _context.Product_Orders.Include(p => p.Order).Include(p => p.Product);
            return View(await ordersDbContext.ToListAsync());
        }

        // GET: Product_Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Order = await _context.Product_Orders
                .Include(p => p.Order)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product_Order == null)
            {
                return NotFound();
            }

            return View(product_Order);
        }

        // GET: Product_Order/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "ClientName");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            return View();
        }

        // POST: Product_Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,OrderId,Quantity")] Product_Order product_Order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product_Order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "ClientName", product_Order.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", product_Order.ProductId);
            return View(product_Order);
        }

        // GET: Product_Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Order = await _context.Product_Orders.FindAsync(id);
            if (product_Order == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "ClientName", product_Order.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", product_Order.ProductId);
            return View(product_Order);
        }

        // POST: Product_Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,OrderId,Quantity")] Product_Order product_Order)
        {
            if (id != product_Order.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product_Order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Product_OrderExists(product_Order.ProductId))
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
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "ClientName", product_Order.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", product_Order.ProductId);
            return View(product_Order);
        }

        // GET: Product_Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Order = await _context.Product_Orders
                .Include(p => p.Order)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product_Order == null)
            {
                return NotFound();
            }

            return View(product_Order);
        }

        // POST: Product_Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product_Order = await _context.Product_Orders.FindAsync(id);
            _context.Product_Orders.Remove(product_Order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Product_OrderExists(int id)
        {
            return _context.Product_Orders.Any(e => e.ProductId == id);
        }
    }
}
