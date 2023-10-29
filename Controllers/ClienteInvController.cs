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
    public class ClienteInvController : Controller
    {
        
        private readonly ConexionBD _context;

        public ClienteInvController(ConexionBD context)
        {
            _context = context;
        }

        // GET: ModeloPr
        //[Authorize(Roles ="Root")]
        public async Task<IActionResult> Index()
        {
              return _context.ClienteInv != null ? 
                          View(await _context.ClienteInv.ToListAsync()) :
                          Problem("Entity set 'ConexionBD.ClienteInv'  is null.");
        }

        // GET: ModeloPr/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClienteInv == null)
            {
                return NotFound();
            }

            var clientesInv = await _context.ClienteInv
                .FirstOrDefaultAsync(m => m.idcliente == id);
            if (clientesInv == null)
            {
                return NotFound();
            }

            return View(clientesInv);
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
        public async Task<IActionResult> Create([Bind("idcliente,Nombre,Correo,Telefono,Direccion,imgcliente")] ClienteInv clientesInv)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientesInv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientesInv);
        }

        // GET: ModeloPr/Edit/5
        [Authorize(Roles ="Admin,Visor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClienteInv == null)
            {
                return NotFound();
            }

            var clientesInv = await _context.ClienteInv.FindAsync(id);
            if (clientesInv == null)
            {
                return NotFound();
            }
            return View(clientesInv);
        }

        // POST: ModeloPr/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles ="Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idcliente,Nombre,Correo,Telefono,Direccion,imgcliente")] ClienteInv clientesInv)
        {
            if (id != clientesInv.idcliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientesInv);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloProductosExists(clientesInv.idcliente))
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
            return View(clientesInv);
        }

        // GET: ModeloPr/Delete/5
        [Authorize(Roles ="Admin,Visor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClienteInv == null)
            {
                return NotFound();
            }

            var clientesInv = await _context.ClienteInv
                .FirstOrDefaultAsync(m => m.idcliente == id);
            if (clientesInv == null)
            {
                return NotFound();
            }

            return View(clientesInv);
        }

        // POST: ModeloPr/Delete/5
        [Authorize(Roles ="Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClienteInv == null)
            {
                return Problem("Entity set 'ConexionBD.ClienteInv'  is null.");
            }
            var clientesInv = await _context.ClienteInv.FindAsync(id);
            if (clientesInv != null)
            {
                _context.ClienteInv.Remove(clientesInv);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloProductosExists(int id)
        {
          return (_context.ClienteInv?.Any(e => e.idcliente == id)).GetValueOrDefault();
        }


        public IActionResult TodosLosClientes()
        {
            var clienteInv = _context.ClienteInv.ToList();
            return View(clienteInv);
        }

    [Authorize(Roles ="Admin,Visor")]
    public async Task<IActionResult> Detalles(int id)
    {
        var clientesInv = await _context.ClienteInv
            .Where(p => p.idcliente == id)
            .Include(p => p.PedidoInv)
            .FirstOrDefaultAsync();

        if (clientesInv == null)
        {
            return NotFound(); // Manejar el caso donde no se encuentra ningún producto con el id especificado
        }

        return View(clientesInv);
    }


      


        
    }
}
