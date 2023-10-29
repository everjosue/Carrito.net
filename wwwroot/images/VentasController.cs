using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using VentasProductos.Models;
using Productos.Models;
//using Modelo.Models;

namespace Proyec1.Controllers
{
    public class VentasController : Controller
    {
        private readonly ConexionBD _context;

        public VentasController(ConexionBD context)
        {
            _context = context;
        }

        // GET: ModeloPr
        public async Task<IActionResult> Index()
        {
              return _context.VentasProductos != null ? 
                          View(await _context.VentasProductos.ToListAsync()) :
                          Problem("Entity set 'ConexionBD.VentasProductos'  is null.");
        }

        // GET: ModeloPr/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VentasProductos == null)
            {
                return NotFound();
            }

            var ventasProductos = await _context.VentasProductos
                .FirstOrDefaultAsync(m => m.idproducto == id);
            if (ventasProductos == null)
            {
                return NotFound();
            }

            return View(ventasProductos);
        }

        // GET: ModeloPr/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModeloPr/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idproducto,CedulaCliente,NombreCliente,CantidadVenta,Nombre,Marca,Modelo,Precio,imgprincipal")] VentasProductos ventasProductos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventasProductos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ventasProductos);
        }

        // GET: ModeloPr/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VentasProductos == null)
            {
                return NotFound();
            }

            var ventasProductos = await _context.VentasProductos.FindAsync(id);
            if (ventasProductos == null)
            {
                return NotFound();
            }
            return View(ventasProductos);
        }

        // POST: ModeloPr/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idproducto,CedulaCliente,NombreCliente,CantidadVenta,Nombre,Marca,Modelo,Precio,imgprincipal")] VentasProductos ventasProductos)
        {
            if (id != ventasProductos.idproducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventasProductos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloProductosExists(ventasProductos.idproducto))
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
            return View(ventasProductos);
        }

        // GET: ModeloPr/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VentasProductos == null)
            {
                return NotFound();
            }

            var ventasProductos = await _context.VentasProductos
                .FirstOrDefaultAsync(m => m.idproducto == id);
            if (ventasProductos == null)
            {
                return NotFound();
            }

            return View(ventasProductos);
        }

        // POST: ModeloPr/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VentasProductos == null)
            {
                return Problem("Entity set 'ConexionBD.VentasProductos'  is null.");
            }
            var ventasProductos = await _context.VentasProductos.FindAsync(id);
            if (ventasProductos != null)
            {
                _context.VentasProductos.Remove(ventasProductos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloProductosExists(int id)
        {
          return (_context.VentasProductos?.Any(e => e.idproducto == id)).GetValueOrDefault();
        }

    }

}