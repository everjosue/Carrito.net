using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//namespace Proyec1.Models;
namespace Productos.Models;

public class SuminisInventario
    {
        [Key]
        [Column("idproveedor")] // Especifica el nombre de la columna

        public int idproveedor { get; set; }
        public string? Nombre { get; set; }

        public string? PaisProveedor { get; set; }
      
        public string? imgproveedor { get; set; }

        public string? descripcion { get; set; }

        public List<ProductosInventario>? ProductosInventario{ get; set; }

       public SuminisInventario()
       {
           ProductosInventario = new List<ProductosInventario>();
       }

       
    }