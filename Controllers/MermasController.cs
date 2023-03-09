using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGA_Solution.Models;

namespace SGA_Solution.Controllers
{
    public class MermasController : Controller
    {
        private readonly SgaSolutionContext _context;

        public MermasController(SgaSolutionContext context)
        {
            _context = context;
        }

        // GET: Mermas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Mermas.ToListAsync());
        }

        // GET: Mermas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mermas == null)
            {
                return NotFound();
            }

            var merma = await _context.Mermas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merma == null)
            {
                return NotFound();
            }

            return View(merma);
        }

        // GET: Mermas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mermas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovimientoR,Fecha,CodigoA,Cantidad,Total")] Merma merma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(merma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(merma);
        }

        // GET: Mermas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mermas == null)
            {
                return NotFound();
            }

            var merma = await _context.Mermas.FindAsync(id);
            if (merma == null)
            {
                return NotFound();
            }
            return View(merma);
        }

        // POST: Mermas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovimientoR,Fecha,CodigoA,Cantidad,Total")] Merma merma)
        {
            if (id != merma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MermaExists(merma.Id))
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
            return View(merma);
        }

        // GET: Mermas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mermas == null)
            {
                return NotFound();
            }

            var merma = await _context.Mermas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merma == null)
            {
                return NotFound();
            }

            return View(merma);
        }

        // POST: Mermas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mermas == null)
            {
                return Problem("Entity set 'SgaSolutionContext.Mermas'  is null.");
            }
            var merma = await _context.Mermas.FindAsync(id);
            if (merma != null)
            {
                _context.Mermas.Remove(merma);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MermaExists(int id)
        {
          return _context.Mermas.Any(e => e.Id == id);
        }
    }
}
