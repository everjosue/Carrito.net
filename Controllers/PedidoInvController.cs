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
    public class PedidoInvController : Controller
    {
        private readonly ConexionBD _context;

        public PedidoInvController(ConexionBD context)
        {
            _context = context;
        }

        // GET: ModeloPr
        public async Task<IActionResult> Index()
        {
              return _context.PedidoInv != null ? 
                          View(await _context.PedidoInv.ToListAsync()) :
                          Problem("Entity set 'ConexionBD.PedidoInv'  is null.");
        }

        // GET: ModeloPr/Details/5
        [Authorize(Roles ="Admin,Visor")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PedidoInv == null)
            {
                return NotFound();
            }

            var pedidoInv = await _context.PedidoInv
                .FirstOrDefaultAsync(m => m.idpedido == id);
            if (pedidoInv == null)
            {
                return NotFound();
            }

            return View(pedidoInv);
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
        [Authorize(Roles ="Admin,Visor,Creador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idpedido,ClienteInvidcliente,Monto,Estado,Direccion_Entrega,Precio,imgpedido")] PedidoInv pedidoInv)
        {
            if (ModelState.IsValid)
            {
                pedidoInv.Fecha = DateTime.Now;
                _context.Add(pedidoInv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedidoInv);
        }

        // GET: ModeloPr/Edit/5
        [Authorize(Roles ="Admin,Visor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PedidoInv == null)
            {
                return NotFound();
            }

            var pedidoInv = await _context.PedidoInv.FindAsync(id);
            if (pedidoInv == null)
            {
                return NotFound();
            }
            return View(pedidoInv);
        }

        // POST: ModeloPr/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles ="Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idpedido,Fecha,ClienteInvidcliente,Monto,Estado,Direccion_Entrega,Precio,imgpedido")] PedidoInv pedidoInv)
        {
            if (id != pedidoInv.idpedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    pedidoInv.Fecha = DateTime.Now;
                    _context.Update(pedidoInv);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloProductosExists(pedidoInv.idpedido))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("TodosLosClientes", "ClienteInv");
            }
            return View(pedidoInv);
        }

        // GET: ModeloPr/Delete/5
        [Authorize(Roles ="Admin,Visor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PedidoInv == null)
            {
                return NotFound();
            }

            var pedidoInv = await _context.PedidoInv
                .FirstOrDefaultAsync(m => m.idpedido == id);
            if (pedidoInv == null)
            {
                return NotFound();
            }

            return View(pedidoInv);
        }

        // POST: ModeloPr/Delete/5
        [Authorize(Roles ="Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PedidoInv == null)
            {
                return Problem("Entity set 'ConexionBD.PedidoInv'  is null.");
            }
            var pedidoInv = await _context.PedidoInv.FindAsync(id);
            if (pedidoInv != null)
            {
                _context.PedidoInv.Remove(pedidoInv);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloProductosExists(int id)
        {
          return (_context.PedidoInv?.Any(e => e.idpedido == id)).GetValueOrDefault();
        }


        [Authorize(Roles ="Admin,Visor")]

        public async Task<IActionResult> Detalles(int id)
        {
            var pedidosInv = await _context.PedidoInv
                .Where(p => p.idpedido == id)
                .Include(p => p.ClienteInv)
                .FirstOrDefaultAsync();

            if (pedidosInv == null)
            {
                return NotFound(); // Manejar el caso donde no se encuentra ningún producto con el id especificado
            }

            return View(pedidosInv);
        }

        public IActionResult TodosLosPedidos()
        {
            var pedidosInv = _context.PedidoInv.ToList();
            return View(pedidosInv);
        }

      


        
    }
}
