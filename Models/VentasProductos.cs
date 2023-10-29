using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//namespace Proyec1.Models;
namespace Productos.Models;

public class VentasProductos
    {
        [Key]
        [Column("Idventa")] // Especifica el nombre de la columna
        public int Idventa { get; set; }
        public int idproducto { get; set; }
        public string? CedulaCliente { get; set; }
        public String? NombreCliente { get; set; }
        public int CantidadVenta { get; set; }
        public string? Nombre { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public decimal Precio { get; set; }
        //public string? descripcion { get; set; }
        //public int Stock { get; set; }
        public string? imgprincipal { get; set; }
        //[NotMapped]
        //public string []? imagenes { get; set; }
        //public int IdCategoria { get; set; }
       // public string? NombreCategoria { get; set; }
    }