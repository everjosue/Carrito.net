using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyec1.Migrations
{
    /// <inheritdoc />
    public partial class actualizacion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resenias_ProductosInventarios_ProductosInventarioidproducto",
                table: "Resenias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductosInventarios",
                table: "ProductosInventarios");

            migrationBuilder.RenameTable(
                name: "ProductosInventarios",
                newName: "ProductosInventario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductosInventario",
                table: "ProductosInventario",
                column: "Idproducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Resenias_ProductosInventario_ProductosInventarioidproducto",
                table: "Resenias",
                column: "ProductosInventarioidproducto",
                principalTable: "ProductosInventario",
                principalColumn: "Idproducto",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resenias_ProductosInventario_ProductosInventarioidproducto",
                table: "Resenias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductosInventario",
                table: "ProductosInventario");

            migrationBuilder.RenameTable(
                name: "ProductosInventario",
                newName: "ProductosInventarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductosInventarios",
                table: "ProductosInventarios",
                column: "Idproducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Resenias_ProductosInventarios_ProductosInventarioidproducto",
                table: "Resenias",
                column: "ProductosInventarioidproducto",
                principalTable: "ProductosInventarios",
                principalColumn: "Idproducto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
