using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Productos.Models;
using Microsoft.AspNetCore.Authorization;
//using Modelo.Models;

namespace Productos.Controllers
{
    [Authorize(Roles ="Admin,Visor,Creador")]
    public class SuminisInventarioController : Controller
    {
        private readonly ConexionBD _context;

        public SuminisInventarioController(ConexionBD context)
        {
            _context = context;
        }

        // GET: ModeloPr
        public async Task<IActionResult> Index()
        {
              return _context.SuminisInventario != null ? 
                          View(await _context.SuminisInventario.ToListAsync()) :
                          Problem("Entity set 'ConexionBD.SuminisInventario'  is null.");
        }

        // GET: ModeloPr/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SuminisInventario == null)
            {
                return NotFound();
            }

            var suminisInventario = await _context.SuminisInventario
                .FirstOrDefaultAsync(m => m.idproveedor == id);
            if (suminisInventario == null)
            {
                return NotFound();
            }

            return View(suminisInventario);
        }

        // GET: ModeloPr/Create
        [Authorize(Roles ="Admin,Visor,Creador")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModeloPr/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles ="Admin,Creador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idproveedor,Nombre,PaisProveedor,descripcion,imgproveedor")] SuminisInventario suminisInventario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suminisInventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suminisInventario);
        }

        // GET: ModeloPr/Edit/5
        [Authorize(Roles ="Admin,Visor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SuminisInventario == null)
            {
                return NotFound();
            }

            var suminisInventario = await _context.SuminisInventario.FindAsync(id);
            if (suminisInventario == null)
            {
                return NotFound();
            }
            return View(suminisInventario);
        }

        // POST: ModeloPr/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles ="Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idproveedor,Nombre,PaisProveedor,descripcion,imgproveedor")] SuminisInventario suminisInventario)
        {
            if (id != suminisInventario.idproveedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suminisInventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloProductosExists(suminisInventario.idproveedor))
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
            return View(suminisInventario);
        }

        // GET: ModeloPr/Delete/5
        [Authorize(Roles ="Admin,Visor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SuminisInventario == null)
            {
                return NotFound();
            }

            var suminisInventario = await _context.SuminisInventario
                .FirstOrDefaultAsync(m => m.idproveedor == id);
            if (suminisInventario == null)
            {
                return NotFound();
            }

            return View(suminisInventario);
        }

        // POST: ModeloPr/Delete/5
        [Authorize(Roles ="Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SuminisInventario == null)
            {
                return Problem("Entity set 'ConexionBD.SuminisInventario'  is null.");
            }
            var suminisInventario = await _context.SuminisInventario.FindAsync(id);
            if (suminisInventario != null)
            {
                _context.SuminisInventario.Remove(suminisInventario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloProductosExists(int id)
        {
          return (_context.SuminisInventario?.Any(e => e.idproveedor == id)).GetValueOrDefault();
        }

        public IActionResult TodosLosProveedores()
        {
            var proveedores = _context.SuminisInventario.ToList();
            return View(proveedores);
        }

        public async Task<IActionResult> Detalles(int id)
        {
            var suminisInventario = await _context.SuminisInventario
                .Where(p => p.idproveedor == id)
                .Include(p => p.ProductosInventario)
                .FirstOrDefaultAsync();

            if (suminisInventario == null)
            {
                return NotFound(); // Manejar el caso donde no se encuentra ningún producto con el id especificado
            }

            return View(suminisInventario);
        }


        
    }
}
