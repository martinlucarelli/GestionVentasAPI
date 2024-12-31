using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestionVentasAPI.Migrations
{
    /// <inheritdoc />
    public partial class DatosSemillaProductos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "idProdcuto", "cantidadStock", "categoriaId", "nombreProducto", "precio" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-444444444444"), 80, new Guid("11111111-1111-1111-1111-111111111111"), "Jabon", 800.0 },
                    { new Guid("55555555-5555-5555-5555-555555555555"), 150, new Guid("22222222-2222-2222-2222-222222222222"), "Esprial", 200.0 },
                    { new Guid("66666666-6666-6666-6666-666666666666"), 34, new Guid("33333333-3333-3333-3333-333333333333"), "Lavandina", 2400.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "idProdcuto",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "idProdcuto",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "idProdcuto",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));
        }
    }
}
