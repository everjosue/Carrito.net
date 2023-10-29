using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//namespace Proyec1.Models;
namespace Productos.Models;

    public class Resenias
    {
        [Key]
        [Column("idresena")] // Especifica el nombre de la columna
        public int idresena { get; set; }
        public string? Usuario { get; set; }
        public DateTime Date { get; set; }
        public string? Comentario { get; set; }

        public int ProductosInventarioidproducto { get; set; }

        public ProductosInventario? ProductosInventario { get; set; }

    }
