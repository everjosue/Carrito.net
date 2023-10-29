using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//namespace Proyec1.Models;
namespace Productos.Models;

    public class ProductosInventario
    {
        [Key]
        [Column("Idproducto")] // Especifica el nombre de la columna
        public int idproducto { get; set; }
        public string? Nombre { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public decimal Precio { get; set; }
        public string? descripcion { get; set; }
        //public int Stock { get; set; }
        public string? imgprincipal { get; set; }

        [ForeignKey("SuminisInventario")]
        [Column("SuminisInventarioidproveedor")]

        public int SuminisInventarioidproveedor { get; set; }

        [ForeignKey("SuminisInventarioidproveedor")]
        [InverseProperty("ProductosInventario")]

        public SuminisInventario? SuminisInventario { get; set; }

       public List<Resenias>? Resenias{ get; set; }

       public ProductosInventario()
       {
           Resenias = new List<Resenias>();
       }
    }
