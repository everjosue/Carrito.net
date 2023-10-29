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

namespace Proyec1.Controllers
{
    public class ProductosInventarioController : Controller
    {
        private readonly ConexionBD _context;

        public ProductosInventarioController(ConexionBD context)
        {
            _context = context;
        }

        // GET: ModeloPr
        public async Task<IActionResult> Index()
        {
              return _context.ProductosInventario != null ? 
                          View(await _context.ProductosInventario.ToListAsync()) :
                          Problem("Entity set 'ConexionBD.ProductosInventarios'  is null.");
        }

        // GET: ModeloPr/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductosInventario == null)
            {
                return NotFound();
            }

            var productosInventario = await _context.ProductosInventario
                .FirstOrDefaultAsync(m => m.idproducto == id);
            if (productosInventario == null)
            {
                return NotFound();
            }

            return View(productosInventario);
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
        //[Authorize(Roles ="Creador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idproducto,SuminisInventarioidproveedor,Nombre,Marca,Modelo,Precio,descripcion,imgprincipal")] ProductosInventario productosInventario, [Bind("Usuario,Comentario")] Resenias resenia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productosInventario);
                await _context.SaveChangesAsync();

                // Asignar el id del producto a la reseña y guardarla
                resenia.ProductosInventarioidproducto = productosInventario.idproducto;
                _context.Add(resenia);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(productosInventario);
        }

        [Authorize(Roles ="Admin,Visor")]
      public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductosInventario == null)
            {
                return NotFound();
            }

            var productosInventario = await _context.ProductosInventario.FindAsync(id);
            if (productosInventario == null)
            {
                return NotFound();
            }
            return View(productosInventario);
        }

        // POST: ModeloPr/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles ="Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idproducto,SuminisInventarioidproveedor,Nombre,Marca,Modelo,Precio,descripcion,imgprincipal")] ProductosInventario productosInventario)
        {
            if (id != productosInventario.idproducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productosInventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloProductosExists(productosInventario.idproducto))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("TodosLosProveedores", "SuminisInventario");
            }
            return View(productosInventario);
        }



        // GET: ModeloPr/Delete/5
        [Authorize(Roles ="Admin,Visor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductosInventario == null)
            {
                return NotFound();
            }

            var productosInventario = await _context.ProductosInventario
                .FirstOrDefaultAsync(m => m.idproducto == id);
            if (productosInventario == null)
            {
                return NotFound();
            }

            return View(productosInventario);
        }

        // POST: ModeloPr/Delete/5
        [Authorize(Roles ="Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductosInventario == null)
            {
                return Problem("Entity set 'ConexionBD.ProductosInventarios'  is null.");
            }
            var productosInventario = await _context.ProductosInventario.FindAsync(id);
            if (productosInventario != null)
            {
                _context.ProductosInventario.Remove(productosInventario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("TodosLosProveedores", "SuminisInventario");
            //return RedirectToAction(nameof(Index));
        }

        private bool ModeloProductosExists(int id)
        {
          return (_context.ProductosInventario?.Any(e => e.idproducto == id)).GetValueOrDefault();
        }


    
        public IActionResult TodosLosProductos()
        {
            var productos = _context.ProductosInventario.ToList();
            return View(productos);
        }


    public async Task<IActionResult> Detalles(int id)
    {
        var productosInventario = await _context.ProductosInventario
            .Where(p => p.idproducto == id)
            .Include(p => p.Resenias)
            .FirstOrDefaultAsync();

        if (productosInventario == null)
        {
            return NotFound(); // Manejar el caso donde no se encuentra ningún producto con el id especificado
        }

        return View(productosInventario);
    }


 
     



      


        
    }

    
}
