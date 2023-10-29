using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//namespace Proyec1.Models;
namespace Productos.Models;

public class ClienteInv
{

    [Key]
    [Column("idcliente")] // Especifica el nombre de la columna
    public int idcliente { get; set; }
    public string? Nombre { get; set; }
    public string? Correo { get; set; }
    public string? Telefono { get; set; }
    public string? Direccion { get; set; }
    public string? imgcliente { get; set; }

    public List<PedidoInv>? PedidoInv{ get; set; }

    public ClienteInv()
    {
        PedidoInv = new List<PedidoInv>();
    }


}