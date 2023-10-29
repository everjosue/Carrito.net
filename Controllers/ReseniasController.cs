using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using Proveedores.Models;
using Productos.Models;
//using Modelo.Models;

namespace Productos.Controllers
{
    public class ReseniasController : Controller
    {
        private readonly ConexionBD _context;

        public ReseniasController(ConexionBD context)
        {
            _context = context;
        }

        // GET: ModeloPr
        public async Task<IActionResult> Index()
        {
              return _context.Proveedores != null ? 
                          View(await _context.Proveedores.ToListAsync()) :
                          Problem("Entity set 'ConexionBD.Proveedores'  is null.");
        }

        public async Task<IActionResult> Save(Resenias model)
        {
            if (ModelState.IsValid)
            {
                model.Date = DateTime.Now;
                _context.Resenias.Add(model);
                await _context.SaveChangesAsync();
                return Redirect("/ProductosInventario/Detalles/" + model.ProductosInventarioidproducto);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Resenias model)
        {
            if (ModelState.IsValid)
            {
                var existingResenia = await _context.Resenias.FindAsync(model.idresena);
                if (existingResenia != null)
                {
                    existingResenia.Usuario = model.Usuario;
                    existingResenia.Comentario = model.Comentario;
                    _context.Entry(existingResenia).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                //return RedirectToAction(nameof(Index));
                return Redirect("/ProductosInventario/Detalles/" + model.ProductosInventarioidproducto);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int idresena)
        {
            var resenia = await _context.Resenias.FindAsync(idresena);
            
            if (resenia != null)
            {
                int idProducto = resenia.ProductosInventarioidproducto; // Guarda el ID del producto antes de eliminar la reseña
                
                _context.Resenias.Remove(resenia);
                await _context.SaveChangesAsync();

                // Redirige a la vista "Detalles" con el ID del producto
                //return RedirectToAction("Detalles", "ProductosInventario", new { idproducto = idProducto });
                //return RedirectToAction("ProductosInventario", "Detalles", new { idproducto = resenia.ProductosInventarioidproducto });
                //string url = Url.Action("Detalles", "ProductosInventario", new { idproducto = resenia.ProductosInventarioidproducto });
                //return Redirect(url);
                return RedirectToAction("Detalles", "ProductosInventario", new { id = resenia.ProductosInventarioidproducto });

            }
            
            // Si la reseña no existe, redirige a algún lugar según tu lógica
            return RedirectToAction("Index");
        }




    }

}