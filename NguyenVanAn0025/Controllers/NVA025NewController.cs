using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenVanAn0025.Models;

namespace NguyenVanAn0025.Controllers
{
    public class NVA025NewController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NVA025NewController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NVA025New
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NVA025New.Include(n => n.NVA025SanPham);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: NVA025New/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NVA025New == null)
            {
                return NotFound();
            }

            var nVA025New = await _context.NVA025New
                .Include(n => n.NVA025SanPham)
                .FirstOrDefaultAsync(m => m.NewID == id);
            if (nVA025New == null)
            {
                return NotFound();
            }

            return View(nVA025New);
        }

        // GET: NVA025New/Create
        public IActionResult Create()
        {
            ViewData["TenSanPham"] = new SelectList(_context.NVA025SanPham, "MaSanPham", "MaSanPham");
            return View();
        }

        // POST: NVA025New/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewID,NewMa,TenSanPham")] NVA025New nVA025New)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nVA025New);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenSanPham"] = new SelectList(_context.NVA025SanPham, "MaSanPham", "MaSanPham", nVA025New.TenSanPham);
            return View(nVA025New);
        }

        // GET: NVA025New/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NVA025New == null)
            {
                return NotFound();
            }

            var nVA025New = await _context.NVA025New.FindAsync(id);
            if (nVA025New == null)
            {
                return NotFound();
            }
            ViewData["TenSanPham"] = new SelectList(_context.NVA025SanPham, "MaSanPham", "MaSanPham", nVA025New.TenSanPham);
            return View(nVA025New);
        }

        // POST: NVA025New/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("NewID,NewMa,TenSanPham")] NVA025New nVA025New)
        {
            if (id != nVA025New.NewID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nVA025New);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NVA025NewExists(nVA025New.NewID))
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
            ViewData["TenSanPham"] = new SelectList(_context.NVA025SanPham, "MaSanPham", "MaSanPham", nVA025New.TenSanPham);
            return View(nVA025New);
        }

        // GET: NVA025New/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NVA025New == null)
            {
                return NotFound();
            }

            var nVA025New = await _context.NVA025New
                .Include(n => n.NVA025SanPham)
                .FirstOrDefaultAsync(m => m.NewID == id);
            if (nVA025New == null)
            {
                return NotFound();
            }

            return View(nVA025New);
        }

        // POST: NVA025New/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.NVA025New == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NVA025New'  is null.");
            }
            var nVA025New = await _context.NVA025New.FindAsync(id);
            if (nVA025New != null)
            {
                _context.NVA025New.Remove(nVA025New);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NVA025NewExists(int? id)
        {
          return (_context.NVA025New?.Any(e => e.NewID == id)).GetValueOrDefault();
        }
    }
}
