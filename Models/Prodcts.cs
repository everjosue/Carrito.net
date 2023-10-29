using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//namespace Proyec1.Models;
namespace Productos.Models;

    public class Prodcts
    {
        [Key]
        [Column("Idproducto")] // Especifica el nombre de la columna
        public int idproducto { get; set; }
        public string? Nombre { get; set; }
        public string? descripcion { get; set; }

       // public string? NombreCategoria { get; set; }
    }