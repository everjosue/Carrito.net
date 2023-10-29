using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//namespace Proyec1.Models;
namespace Productos.Models;

    public class ModeloProductos
    {
        [Key]
        [Column("Idproducto")] // Especifica el nombre de la columna
        public int idproducto { get; set; }
        public string? Nombre { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }

        public string? controller { get; set; }

        public string? accion { get; set; }
        public decimal Precio { get; set; }
        public string? descripcion { get; set; }
        //public int Stock { get; set; }
        public string? imgprincipal { get; set; }
        [NotMapped]
        public string []? imagenes { get; set; }
        //public int IdCategoria { get; set; }
       // public string? NombreCategoria { get; set; }
    }
