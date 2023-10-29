using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Productos.Models;

    public class ConexionBD : IdentityDbContext<IdentityUser>
    {

        public ConexionBD(DbContextOptions<ConexionBD> options) : base(options)
        {
        }

        public DbSet<ModeloProductos> Productos { get; set; }
        public DbSet<Prodcts> Prodcts { get; set; }

        public DbSet<Proveedores> Proveedores { get; set; }

        public DbSet<VentasProductos> VentasProductos { get; set; }

        public DbSet<Stock> Stokc { get; set; }

        public DbSet<ProductosInventario> ProductosInventario { get; set; }

        public DbSet<Resenias> Resenias { get; set; }

        public DbSet<SuminisInventario> SuminisInventario { get; set; }

        public DbSet<ClienteInv> ClienteInv { get; set; }

        public DbSet<PedidoInv> PedidoInv { get; set; }

    }