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

            var ventas = await _context.VentasProductos
                .FirstOrDefaultAsync(m => m.Idventa == id);
            if (ventas == null)
            {
                return NotFound();
            }

            return View(ventas);
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
        public async Task<IActionResult> Create([Bind("Idventa,idproducto,CedulaCliente,NombreCliente,CantidadVenta,Nombre,Marca,Modelo,Precio,imgprincipal")] VentasProductos ventas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ventas);
        }

        // GET: ModeloPr/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VentasProductos == null)
            {
                return NotFound();
            }

            var ventas = await _context.VentasProductos.FindAsync(id);
            if (ventas == null)
            {
                return NotFound();
            }
            return View(ventas);
        }

        // POST: ModeloPr/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idventa,idproducto,CedulaCliente,NombreCliente,CantidadVenta,Nombre,Marca,Modelo,Precio,imgprincipal")] VentasProductos ventas)
        {
            if (id != ventas.Idventa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloProductosExists(ventas.Idventa))
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
            return View(ventas);
        }

        // GET: ModeloPr/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VentasProductos == null)
            {
                return NotFound();
            }

            var ventas = await _context.VentasProductos
                .FirstOrDefaultAsync(m => m.Idventa == id);
            if (ventas == null)
            {
                return NotFound();
            }

            return View(ventas);
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
            var ventas = await _context.VentasProductos.FindAsync(id);
            if (ventas != null)
            {
                _context.VentasProductos.Remove(ventas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloProductosExists(int id)
        {
          return (_context.VentasProductos?.Any(e => e.Idventa == id)).GetValueOrDefault();
        }

        public IActionResult ArticuloMasVendido()
        {
            var articuloMasVendido = _context.VentasProductos
                .OrderByDescending(vp => vp.CantidadVenta)
                .FirstOrDefault();

            ViewBag.ArticuloMasVendido = articuloMasVendido;

            return View();
        }










    }

}