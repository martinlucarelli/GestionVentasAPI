﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionVentasAPI.Migrations
{
    [DbContext(typeof(VentasContext))]
    [Migration("20241230182459_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Categoria", b =>
                {
                    b.Property<Guid>("idCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombreCategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCategoria");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            idCategoria = new Guid("11111111-1111-1111-1111-111111111111"),
                            nombreCategoria = "Higiene personal"
                        },
                        new
                        {
                            idCategoria = new Guid("22222222-2222-2222-2222-222222222222"),
                            descripcion = "Articulos repeletes y antiplagas",
                            nombreCategoria = "Repelentes"
                        },
                        new
                        {
                            idCategoria = new Guid("33333333-3333-3333-3333-333333333333"),
                            nombreCategoria = "Limpieza"
                        });
                });

            modelBuilder.Entity("DetalleVenta", b =>
                {
                    b.Property<Guid>("idDetalleVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<Guid>("productoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ventaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("idDetalleVenta");

                    b.HasIndex("productoId");

                    b.HasIndex("ventaId");

                    b.ToTable("DetalleVenta", (string)null);
                });

            modelBuilder.Entity("Producto", b =>
                {
                    b.Property<Guid>("idProdcuto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("cantidadStock")
                        .HasColumnType("int");

                    b.Property<Guid>("categoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("nombreProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("precio")
                        .HasColumnType("float");

                    b.HasKey("idProdcuto");

                    b.HasIndex("categoriaId");

                    b.ToTable("Producto", (string)null);
                });

            modelBuilder.Entity("Venta", b =>
                {
                    b.Property<Guid>("idVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("fecha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<decimal>("total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("idVenta");

                    b.ToTable("Venta", (string)null);
                });

            modelBuilder.Entity("DetalleVenta", b =>
                {
                    b.HasOne("Producto", "producto")
                        .WithMany("detalleVentas")
                        .HasForeignKey("productoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Venta", "venta")
                        .WithMany("detalleVentas")
                        .HasForeignKey("ventaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("producto");

                    b.Navigation("venta");
                });

            modelBuilder.Entity("Producto", b =>
                {
                    b.HasOne("Categoria", "categoria")
                        .WithMany("productos")
                        .HasForeignKey("categoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categoria");
                });

            modelBuilder.Entity("Categoria", b =>
                {
                    b.Navigation("productos");
                });

            modelBuilder.Entity("Producto", b =>
                {
                    b.Navigation("detalleVentas");
                });

            modelBuilder.Entity("Venta", b =>
                {
                    b.Navigation("detalleVentas");
                });
#pragma warning restore 612, 618
        }
    }
}