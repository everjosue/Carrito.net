using Microsoft.AspNetCore.Mvc;
using Productos.Models;
using Microsoft.EntityFrameworkCore;


namespace Productos.Controllers;
public class ProdctsController : Controller
{
    private readonly ConexionBD _context;
    public ProdctsController(ConexionBD context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        /*return _context.Prodcts != null ?
                    View(_context.Prodcts.ToList()) :
                    Problem("Entity set 'ConexionBD.Prodcts'  is null.");*/
    
        List<Prodcts> prodcts = await _context.Prodcts.ToListAsync();
        return View(prodcts);

    }

    public IActionResult Create()
    {
        return View();
    }

    // POST: ModeloPr/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("idproducto,Nombre,descripcion")] Prodcts prodcts)
    {
        if (ModelState.IsValid)
        {
            _context.Add(prodcts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(prodcts);
    }


}