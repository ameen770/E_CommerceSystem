using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_CommerceSystem.Data;
using E_CommerceSystem.Models;

namespace E_CommerceSystem.Controllers
{
    public class CartItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CartItems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.cartItems.Include(c => c.Carts).Include(c => c.Products);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CartItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cartItems == null)
            {
                return NotFound();
            }

            var cartItem = await _context.cartItems
                .Include(c => c.Carts)
                .Include(c => c.Products)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cartItem == null)
            {
                return NotFound();
            }

            return View(cartItem);
        }

        // GET: CartItems/Create
        public IActionResult Create()
        {
            ViewData["CartID"] = new SelectList(_context.carts, "ID", "ID");
            ViewData["ProductID"] = new SelectList(_context.products, "ID", "Category");
            return View();
        }

        // POST: CartItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Quantity,Price,CartID,ProductID")] CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CartID"] = new SelectList(_context.carts, "ID", "ID", cartItem.CartID);
            ViewData["ProductID"] = new SelectList(_context.products, "ID", "Category", cartItem.ProductID);
            return View(cartItem);
        }

        // GET: CartItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cartItems == null)
            {
                return NotFound();
            }

            var cartItem = await _context.cartItems.FindAsync(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            ViewData["CartID"] = new SelectList(_context.carts, "ID", "ID", cartItem.CartID);
            ViewData["ProductID"] = new SelectList(_context.products, "ID", "Category", cartItem.ProductID);
            return View(cartItem);
        }

        // POST: CartItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Quantity,Price,CartID,ProductID")] CartItem cartItem)
        {
            if (id != cartItem.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartItemExists(cartItem.ID))
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
            ViewData["CartID"] = new SelectList(_context.carts, "ID", "ID", cartItem.CartID);
            ViewData["ProductID"] = new SelectList(_context.products, "ID", "Category", cartItem.ProductID);
            return View(cartItem);
        }

        // GET: CartItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cartItems == null)
            {
                return NotFound();
            }

            var cartItem = await _context.cartItems
                .Include(c => c.Carts)
                .Include(c => c.Products)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cartItem == null)
            {
                return NotFound();
            }

            return View(cartItem);
        }

        // POST: CartItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cartItems == null)
            {
                return Problem("Entity set 'ApplicationDbContext.cartItems'  is null.");
            }
            var cartItem = await _context.cartItems.FindAsync(id);
            if (cartItem != null)
            {
                _context.cartItems.Remove(cartItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartItemExists(int id)
        {
          return (_context.cartItems?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
