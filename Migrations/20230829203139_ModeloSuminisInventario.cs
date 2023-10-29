using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyec1.Migrations
{
    /// <inheritdoc />
    public partial class ModeloSuminisInventario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SuminisInventarioidproveedor",
                table: "ProductosInventario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SuminisInventario",
                columns: table => new
                {
                    idproveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaisProveedor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    imgproveedor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuminisInventario", x => x.idproveedor);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosInventario_SuminisInventarioidproveedor",
                table: "ProductosInventario",
                column: "SuminisInventarioidproveedor");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosInventario_SuminisInventario_SuminisInventarioidpro~",
                table: "ProductosInventario",
                column: "SuminisInventarioidproveedor",
                principalTable: "SuminisInventario",
                principalColumn: "idproveedor",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductosInventario_SuminisInventario_SuminisInventarioidpro~",
                table: "ProductosInventario");

            migrationBuilder.DropTable(
                name: "SuminisInventario");

            migrationBuilder.DropIndex(
                name: "IX_ProductosInventario_SuminisInventarioidproveedor",
                table: "ProductosInventario");

            migrationBuilder.DropColumn(
                name: "SuminisInventarioidproveedor",
                table: "ProductosInventario");
        }
    }
}
