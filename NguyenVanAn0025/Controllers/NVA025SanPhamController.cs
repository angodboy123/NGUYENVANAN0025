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
    public class NVA025SanPhamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NVA025SanPhamController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NVA025SanPham
        public async Task<IActionResult> Index()
        {
              return _context.NVA025SanPham != null ? 
                          View(await _context.NVA025SanPham.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.NVA025SanPham'  is null.");
        }

        // GET: NVA025SanPham/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NVA025SanPham == null)
            {
                return NotFound();
            }

            var nVA025SanPham = await _context.NVA025SanPham
                .FirstOrDefaultAsync(m => m.MaSanPham == id);
            if (nVA025SanPham == null)
            {
                return NotFound();
            }

            return View(nVA025SanPham);
        }

        // GET: NVA025SanPham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NVA025SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSanPham,TenSanPham,GiaSanPham")] NVA025SanPham nVA025SanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nVA025SanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nVA025SanPham);
        }

        // GET: NVA025SanPham/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NVA025SanPham == null)
            {
                return NotFound();
            }

            var nVA025SanPham = await _context.NVA025SanPham.FindAsync(id);
            if (nVA025SanPham == null)
            {
                return NotFound();
            }
            return View(nVA025SanPham);
        }

        // POST: NVA025SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSanPham,TenSanPham,GiaSanPham")] NVA025SanPham nVA025SanPham)
        {
            if (id != nVA025SanPham.MaSanPham)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nVA025SanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NVA025SanPhamExists(nVA025SanPham.MaSanPham))
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
            return View(nVA025SanPham);
        }

        // GET: NVA025SanPham/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NVA025SanPham == null)
            {
                return NotFound();
            }

            var nVA025SanPham = await _context.NVA025SanPham
                .FirstOrDefaultAsync(m => m.MaSanPham == id);
            if (nVA025SanPham == null)
            {
                return NotFound();
            }

            return View(nVA025SanPham);
        }

        // POST: NVA025SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NVA025SanPham == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NVA025SanPham'  is null.");
            }
            var nVA025SanPham = await _context.NVA025SanPham.FindAsync(id);
            if (nVA025SanPham != null)
            {
                _context.NVA025SanPham.Remove(nVA025SanPham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NVA025SanPhamExists(string id)
        {
          return (_context.NVA025SanPham?.Any(e => e.MaSanPham == id)).GetValueOrDefault();
        }
    }
}
