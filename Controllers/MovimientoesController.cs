using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGA_Solution.Models;

namespace SGA_Solution.Controllers
{
    public class MovimientoesController : Controller
    {
        private readonly SgaSolutionContext _context;

        public MovimientoesController(SgaSolutionContext context)
        {
            _context = context;
        }

        // GET: Movimientoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Movimientos.ToListAsync());
        }

        // GET: Movimientoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movimientos == null)
            {
                return NotFound();
            }

            var movimiento = await _context.Movimientos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimiento == null)
            {
                return NotFound();
            }

            return View(movimiento);
        }

        // GET: Movimientoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movimientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Referencia,Fecha,Tipo,Total")] Movimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movimiento);
        }

        // GET: Movimientoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movimientos == null)
            {
                return NotFound();
            }

            var movimiento = await _context.Movimientos.FindAsync(id);
            if (movimiento == null)
            {
                return NotFound();
            }
            return View(movimiento);
        }

        // POST: Movimientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Referencia,Fecha,Tipo,Total")] Movimiento movimiento)
        {
            if (id != movimiento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimientoExists(movimiento.Id))
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
            return View(movimiento);
        }

        // GET: Movimientoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movimientos == null)
            {
                return NotFound();
            }

            var movimiento = await _context.Movimientos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimiento == null)
            {
                return NotFound();
            }

            return View(movimiento);
        }

        // POST: Movimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movimientos == null)
            {
                return Problem("Entity set 'SgaSolutionContext.Movimientos'  is null.");
            }
            var movimiento = await _context.Movimientos.FindAsync(id);
            if (movimiento != null)
            {
                _context.Movimientos.Remove(movimiento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimientoExists(int id)
        {
          return _context.Movimientos.Any(e => e.Id == id);
        }

        /*public IActionResult RegistrarA()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarA([Bind("Id,Referencia, Tipo,Total,MovimientoR,Proveedor,CodigoA,Cantidad,CostoU,Caducidad")] Movimiento movimiento, Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                var articulo = await _context.Articulos.SingleOrDefaultAsync(a => a.Codigo == entrada.CodigoA);
                if (articulo != null)
                {
                    // Sumar la cantidad de la entrada al stock actual del artículo
                    articulo.Stock += entrada.Cantidad;

                    // Actualizar el artículo en la base de datos
                    _context.Articulos.Update(articulo);
                }
                entrada.Fecha = DateTime.Now;
                movimiento.Fecha = DateTime.Now;
                _context.Add(movimiento);
                _context.Add(entrada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new MyViewModelEntrada()
            {
                Movimiento = movimiento,
                Entrada = entrada
            };

            return View(viewModel);
        }*/

        public IActionResult RegistrarA()
        {
            var viewModel = new MyViewModelEntrada();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarA([Bind("Id,Referencia, Tipo,Total,MovimientoR,Proveedor")] Movimiento movimiento, List<Entrada> entradas)

        {
            foreach (var entrada in entradas)
            {
                if (ModelState.IsValid)
                {
                    var articulo = await _context.Articulos.SingleOrDefaultAsync(a => a.Codigo == entrada.CodigoA);
                    if (articulo != null)
                    {
                        // Sumar la cantidad de la entrada al stock actual del artículo
                        articulo.Stock += entrada.Cantidad;

                        // Actualizar el artículo en la base de datos
                        _context.Articulos.Update(articulo);
                    }
                    entrada.Fecha = DateTime.Now;
                    movimiento.Fecha = DateTime.Now;
                    _context.Add(movimiento);
                    _context.Add(entrada);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult RegistrarS()
        {
            var viewModel = new MyViewModelSalida();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarS([Bind("Id,Referencia, Tipo,Total")] Movimiento movimiento, List<Salida> salidas)

        {
            foreach (var salida in salidas)
            {
                if (ModelState.IsValid)
                {
                    var articulo = await _context.Articulos.SingleOrDefaultAsync(a => a.Codigo == salida.CodigoA);
                    if (articulo != null)
                    {
                        articulo.Stock -= salida.Cantidad;

                        _context.Articulos.Update(articulo);
                    }
                    salida.Fecha = DateTime.Now;
                    movimiento.Fecha = DateTime.Now;
                    _context.Add(movimiento);
                    _context.Add(salida);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
