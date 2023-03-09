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
    public class AjustesController : Controller
    {
        private readonly SgaSolutionContext _context;

        public AjustesController(SgaSolutionContext context)
        {
            _context = context;
        }

        // GET: Ajustes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Ajustes.ToListAsync());
        }

        // GET: Ajustes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ajustes == null)
            {
                return NotFound();
            }

            var ajuste = await _context.Ajustes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ajuste == null)
            {
                return NotFound();
            }

            return View(ajuste);
        }

        // GET: Ajustes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ajustes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovimientoR,Fecha,CodigoA,NombreA,CantidadS,PrecioU,Caducidad")] Ajuste ajuste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ajuste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ajuste);
        }

        // GET: Ajustes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ajustes == null)
            {
                return NotFound();
            }

            var ajuste = await _context.Ajustes.FindAsync(id);
            if (ajuste == null)
            {
                return NotFound();
            }
            return View(ajuste);
        }

        // POST: Ajustes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovimientoR,Fecha,CodigoA,NombreA,CantidadS,PrecioU,Caducidad")] Ajuste ajuste)
        {
            if (id != ajuste.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ajuste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AjusteExists(ajuste.Id))
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
            return View(ajuste);
        }

        // GET: Ajustes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ajustes == null)
            {
                return NotFound();
            }

            var ajuste = await _context.Ajustes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ajuste == null)
            {
                return NotFound();
            }

            return View(ajuste);
        }

        // POST: Ajustes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ajustes == null)
            {
                return Problem("Entity set 'SgaSolutionContext.Ajustes'  is null.");
            }
            var ajuste = await _context.Ajustes.FindAsync(id);
            if (ajuste != null)
            {
                _context.Ajustes.Remove(ajuste);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AjusteExists(int id)
        {
          return _context.Ajustes.Any(e => e.Id == id);
        }
    }
}
