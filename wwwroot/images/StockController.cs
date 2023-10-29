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
    public class StockController : Controller
    {
        private readonly ConexionBD _context;

        public StockController(ConexionBD context)
        {
            _context = context;
        }

        // GET: ModeloPr
        // Aca inician los metodos para stock
        //Separadores
        //separadores
        //Separadores

        public async Task<IActionResult> InicioStock()
        {
              return _context.Stokc != null ? 
                          View(await _context.Stokc.ToListAsync()) :
                          Problem("Entity set 'ConexionBD.Productos'  is null.");
        }

        /*public string PrecioFormateado
        {
            get { return Precio.ToString("N2"); }
        }*/

        
        public async Task<IActionResult> DetallesStock(int? id)
        {
            if (id == null || _context.Stokc == null)
            {
                return NotFound();
            }

            var stock = await _context.Stokc
                .FirstOrDefaultAsync(m => m.idproducto == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

      public IActionResult CrearRegStock()
        {
            return View();
        }

        // POST: ModeloPr/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearRegStock([Bind("idproducto,NumBodega,TipoProducto,Cantidad,Nombre,Marca,Modelo,Precio,imgprincipal")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(InicioStock));
            }
            return View(stock);
        }


        public async Task<IActionResult> EditarStock(int? id)
        {
            if (id == null || _context.Stokc == null)
            {
                return NotFound();
            }

            var stock = await _context.Stokc.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return View(stock);
        }

        // POST: ModeloPr/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarStock(int id, [Bind("idproducto,NumBodega,TipoProducto,Cantidad,Nombre,Marca,Precio,imgprincipal")] Stock stock)
        {
            if (id != stock.idproducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockExists(stock.idproducto))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(InicioStock));
            }
            return View(stock);
        }

       // GET: ModeloPr/Delete/5
        public async Task<IActionResult> BorrarStokc(int? id)
        {
            if (id == null || _context.Stokc == null)
            {
                return NotFound();
            }

            var stock = await _context.Stokc
            .FirstOrDefaultAsync(m => m.idproducto == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // POST: ModeloPr/Delete/5
        [HttpPost, ActionName("BorrarStokc")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarStockConfirmado(int id)
        {
            if (_context.Stokc == null)
            {
                return Problem("Entity set 'ConexionBD.Stock'  is null.");
            }
            var stock = await _context.Stokc.FindAsync(id);
            if (stock != null)
            {
                _context.Stokc.Remove(stock);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(InicioStock));
        }

        private bool StockExists(int id)
        {
          return (_context.Stokc?.Any(e => e.idproducto == id)).GetValueOrDefault();
        }



        
    }
}
