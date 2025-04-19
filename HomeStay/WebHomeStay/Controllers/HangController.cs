using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebHomeStay.Models;

namespace WebHomeStay.Controllers
{
    public class HangController : Controller
    {
        private readonly InternWebsiteContext _context;

        public HangController(InternWebsiteContext context)
        {
            _context = context;
        }

        // GET: Hang
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hangs.ToListAsync());
        }

        // GET: Hang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hang = await _context.Hangs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hang == null)
            {
                return NotFound();
            }

            return View(hang);
        }

        // GET: Hang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenHang,SoLanThue,GiamGia,TrangThai")] Hang hang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hang);
        }

        // GET: Hang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hang = await _context.Hangs.FindAsync(id);
            if (hang == null)
            {
                return NotFound();
            }
            return View(hang);
        }

        // POST: Hang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenHang,SoLanThue,GiamGia,TrangThai")] Hang hang)
        {
            if (id != hang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangExists(hang.Id))
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
            return View(hang);
        }

        // GET: Hang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hang = await _context.Hangs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hang == null)
            {
                return NotFound();
            }

            return View(hang);
        }

        // POST: Hang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hang = await _context.Hangs.FindAsync(id);
            if (hang != null)
            {
                _context.Hangs.Remove(hang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HangExists(int id)
        {
            return _context.Hangs.Any(e => e.Id == id);
        }
    }
}
