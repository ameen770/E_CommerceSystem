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
    public class WishlistsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WishlistsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Wishlists
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.wishlists.Include(w => w.Products).Include(w => w.Users);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Wishlists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.wishlists == null)
            {
                return NotFound();
            }

            var wishlist = await _context.wishlists
                .Include(w => w.Products)
                .Include(w => w.Users)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (wishlist == null)
            {
                return NotFound();
            }

            return View(wishlist);
        }

        // GET: Wishlists/Create
        public IActionResult Create()
        {
            ViewData["ProductID"] = new SelectList(_context.products, "ID", "Category");
            ViewData["UserID"] = new SelectList(_context.users, "ID", "Address");
            return View();
        }

        // POST: Wishlists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Date,UserID,ProductID")] Wishlist wishlist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wishlist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductID"] = new SelectList(_context.products, "ID", "Category", wishlist.ProductID);
            ViewData["UserID"] = new SelectList(_context.users, "ID", "Address", wishlist.UserID);
            return View(wishlist);
        }

        // GET: Wishlists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.wishlists == null)
            {
                return NotFound();
            }

            var wishlist = await _context.wishlists.FindAsync(id);
            if (wishlist == null)
            {
                return NotFound();
            }
            ViewData["ProductID"] = new SelectList(_context.products, "ID", "Category", wishlist.ProductID);
            ViewData["UserID"] = new SelectList(_context.users, "ID", "Address", wishlist.UserID);
            return View(wishlist);
        }

        // POST: Wishlists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Date,UserID,ProductID")] Wishlist wishlist)
        {
            if (id != wishlist.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wishlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WishlistExists(wishlist.ID))
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
            ViewData["ProductID"] = new SelectList(_context.products, "ID", "Category", wishlist.ProductID);
            ViewData["UserID"] = new SelectList(_context.users, "ID", "Address", wishlist.UserID);
            return View(wishlist);
        }

        // GET: Wishlists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.wishlists == null)
            {
                return NotFound();
            }

            var wishlist = await _context.wishlists
                .Include(w => w.Products)
                .Include(w => w.Users)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (wishlist == null)
            {
                return NotFound();
            }

            return View(wishlist);
        }

        // POST: Wishlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.wishlists == null)
            {
                return Problem("Entity set 'ApplicationDbContext.wishlists'  is null.");
            }
            var wishlist = await _context.wishlists.FindAsync(id);
            if (wishlist != null)
            {
                _context.wishlists.Remove(wishlist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WishlistExists(int id)
        {
          return (_context.wishlists?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
