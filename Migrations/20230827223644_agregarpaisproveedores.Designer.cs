﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Productos.Models;

#nullable disable

namespace Proyec1.Migrations
{
    [DbContext(typeof(ConexionBD))]
    [Migration("20230827223644_agregarpaisproveedores")]
    partial class agregarpaisproveedores
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Productos.Models.ModeloProductos", b =>
                {
                    b.Property<int>("idproducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Idproducto");

                    b.Property<string>("Marca")
                        .HasColumnType("longtext");

                    b.Property<string>("Modelo")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("descripcion")
                        .HasColumnType("longtext");

                    b.Property<string>("imgprincipal")
                        .HasColumnType("longtext");

                    b.HasKey("idproducto");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Productos.Models.Prodcts", b =>
                {
                    b.Property<int>("idproducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Idproducto");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<string>("descripcion")
                        .HasColumnType("longtext");

                    b.HasKey("idproducto");

                    b.ToTable("Prodcts");
                });

            modelBuilder.Entity("Productos.Models.Proveedores", b =>
                {
                    b.Property<int>("Idcompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Idcompra");

                    b.Property<int>("CantCompra")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<string>("NombreProducto")
                        .HasColumnType("longtext");

                    b.Property<string>("PaisProveedor")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("TipoProducto")
                        .HasColumnType("longtext");

                    b.Property<int>("idproveedor")
                        .HasColumnType("int");

                    b.Property<string>("imgprincipal")
                        .HasColumnType("longtext");

                    b.HasKey("Idcompra");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("Productos.Models.Stock", b =>
                {
                    b.Property<int>("idproducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Idproducto");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .HasColumnType("longtext");

                    b.Property<string>("Modelo")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<int?>("NumBodega")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("TipoProducto")
                        .HasColumnType("longtext");

                    b.Property<string>("imgprincipal")
                        .HasColumnType("longtext");

                    b.HasKey("idproducto");

                    b.ToTable("Stokc");
                });

            modelBuilder.Entity("Productos.Models.VentasProductos", b =>
                {
                    b.Property<int>("Idventa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Idventa");

                    b.Property<int>("CantidadVenta")
                        .HasColumnType("int");

                    b.Property<string>("CedulaCliente")
                        .HasColumnType("longtext");

                    b.Property<string>("Marca")
                        .HasColumnType("longtext");

                    b.Property<string>("Modelo")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<string>("NombreCliente")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("idproducto")
                        .HasColumnType("int");

                    b.Property<string>("imgprincipal")
                        .HasColumnType("longtext");

                    b.HasKey("Idventa");

                    b.ToTable("VentasProductos");
                });
#pragma warning restore 612, 618
        }
    }
}