using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Productos.Models;
//using Modelo.Models;

namespace Proyec1.Controllers
{
    public class ModeloPrController : Controller
    {
        private readonly ConexionBD _context;

        public ModeloPrController(ConexionBD context)
        {
            _context = context;
        }

        // GET: ModeloPr
        public async Task<IActionResult> Index()
        {
              return _context.Productos != null ? 
                          View(await _context.Productos.ToListAsync()) :
                          Problem("Entity set 'ConexionBD.Productos'  is null.");
        }

        // GET: ModeloPr/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var modeloProductos = await _context.Productos
                .FirstOrDefaultAsync(m => m.idproducto == id);
            if (modeloProductos == null)
            {
                return NotFound();
            }

            return View(modeloProductos);
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
        public async Task<IActionResult> Create([Bind("idproducto,Nombre,Marca,Modelo,Precio,descripcion,imgprincipal")] ModeloProductos modeloProductos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modeloProductos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modeloProductos);
        }

        // GET: ModeloPr/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var modeloProductos = await _context.Productos.FindAsync(id);
            if (modeloProductos == null)
            {
                return NotFound();
            }
            return View(modeloProductos);
        }

        // POST: ModeloPr/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idproducto,Nombre,Marca,Modelo,Precio,descripcion,imgprincipal")] ModeloProductos modeloProductos)
        {
            if (id != modeloProductos.idproducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modeloProductos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloProductosExists(modeloProductos.idproducto))
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
            return View(modeloProductos);
        }

        // GET: ModeloPr/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var modeloProductos = await _context.Productos
                .FirstOrDefaultAsync(m => m.idproducto == id);
            if (modeloProductos == null)
            {
                return NotFound();
            }

            return View(modeloProductos);
        }

        // POST: ModeloPr/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'ConexionBD.Productos'  is null.");
            }
            var modeloProductos = await _context.Productos.FindAsync(id);
            if (modeloProductos != null)
            {
                _context.Productos.Remove(modeloProductos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloProductosExists(int id)
        {
          return (_context.Productos?.Any(e => e.idproducto == id)).GetValueOrDefault();
        }


      


        
    }
}
