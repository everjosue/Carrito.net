using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//namespace Proyec1.Models;
namespace Productos.Models;

public class PedidoInv
{

    [Key]
    [Column("idpedido")] // Especifica el nombre de la columna
    public int idpedido { get; set; }
    public DateTime Fecha { get; set; }
    public string? Monto { get; set; }
    public string? Estado { get; set; }
    public string? Direccion_Entrega { get; set; }
    public string? imgpedido { get; set; }

    [ForeignKey("ClienteInv")]
    [Column("ClienteInvidcliente")]

    public int ClienteInvidcliente { get; set; }

    [ForeignKey("ClienteInvidcliente")]
    [InverseProperty("PedidoInv")]

    public ClienteInv? ClienteInv { get; set; }


}