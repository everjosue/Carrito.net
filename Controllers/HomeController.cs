using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proyec1.Models;
using Productos.Models;
using Newtonsoft.Json;
namespace Proyec1.Controllers;

public class HomeController : Controller
{

    //public List<ModeloProductos> productos = new List<ModeloProductos>();
    public List<ModeloProductos> lstproductos = null;

    public HomeController()
    {
        //lstproductos = JsonConvert.DeserializeObject<List<ModeloProductos>>(System.IO.File.ReadAllText("Models/DatosProductos.json"));
        //productos = JsonConvert.DeserializeObject<List<ModeloProductos>>(System.IO.File.ReadAllText("productos.json"));
        var myJsonString = System.IO.File.ReadAllText("Models/DatosProductos.json");
        lstproductos = JsonConvert.DeserializeObject<List<ModeloProductos>>(myJsonString);
    }

    /*private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }*/

    public IActionResult Index()
    {
        return View(lstproductos);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Buscar(String busqueda)
    {
        //var producto = lstproductos.Where(x => x.Id == id).FirstOrDefault();
        //return View(producto);
        List<ModeloProductos> lstResultProductos = new List<ModeloProductos>();
        foreach (var item in lstproductos)
        {
            if (item.Nombre.ToLower().Contains(busqueda.ToLower()))
            {
                lstResultProductos.Add(item);
            }

        }

        return View("Index", lstResultProductos);
    }

    public IActionResult Detalles(int id)
    {
        //var producto = lstproductos.Where(x => x.Id == id).FirstOrDefault();
        //return View(producto);
        //List<ModeloProductos> lstResultProductos = new List<ModeloProductos>();
        foreach (var item in lstproductos)
        {
            if (item.idproducto == id)
            {
                return View(item);
            }

        }

        return View(new ModeloProductos());
    }

    public IActionResult Login()
    {
        return View();
    }
}
