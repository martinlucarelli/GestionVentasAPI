using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestionVentasAPI.Migrations
{
    /// <inheritdoc />
    public partial class DatosSemillaDetalleVentas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DetalleVenta",
                columns: new[] { "idDetalleVenta", "cantidad", "productoId", "subtotal", "ventaId" },
                values: new object[,]
                {
                    { new Guid("5b90d7e7-ac3d-406d-9123-ba234b3acde7"), 2, new Guid("55555555-5555-5555-5555-555555555555"), 400m, new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("8c81f71e-8d65-4352-a341-252d4661e0c6"), 2, new Guid("44444444-4444-4444-4444-444444444444"), 1600m, new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("c4b45d34-5fac-4682-8f64-1ee3c66ac118"), 3, new Guid("44444444-4444-4444-4444-444444444444"), 2400m, new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("e60f793a-0d18-4ebd-a74f-4ebcdbac55ce"), 2, new Guid("66666666-6666-6666-6666-666666666666"), 1600m, new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("e8946299-eb88-4d55-9306-293ed14e402b"), 2, new Guid("66666666-6666-6666-6666-666666666666"), 4800m, new Guid("88888888-8888-8888-8888-888888888888") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DetalleVenta",
                keyColumn: "idDetalleVenta",
                keyValue: new Guid("5b90d7e7-ac3d-406d-9123-ba234b3acde7"));

            migrationBuilder.DeleteData(
                table: "DetalleVenta",
                keyColumn: "idDetalleVenta",
                keyValue: new Guid("8c81f71e-8d65-4352-a341-252d4661e0c6"));

            migrationBuilder.DeleteData(
                table: "DetalleVenta",
                keyColumn: "idDetalleVenta",
                keyValue: new Guid("c4b45d34-5fac-4682-8f64-1ee3c66ac118"));

            migrationBuilder.DeleteData(
                table: "DetalleVenta",
                keyColumn: "idDetalleVenta",
                keyValue: new Guid("e60f793a-0d18-4ebd-a74f-4ebcdbac55ce"));

            migrationBuilder.DeleteData(
                table: "DetalleVenta",
                keyColumn: "idDetalleVenta",
                keyValue: new Guid("e8946299-eb88-4d55-9306-293ed14e402b"));
        }
    }
}
