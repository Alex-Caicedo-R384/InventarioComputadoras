﻿// <auto-generated />
using InventarioComputadoras.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InventarioComputadoras.Datos.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240308132743_LicenciaSO")]
    partial class LicenciaSO
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InventarioComputadoras.Models.Computadora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Departamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicenciaSO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreAnterior")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreNuevo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oficina")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SinDireccionIP")
                        .HasColumnType("bit");

                    b.Property<bool>("SinLicenciaSO")
                        .HasColumnType("bit");

                    b.Property<bool>("SinNombreAnterior")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Computadoras");
                });
#pragma warning restore 612, 618
        }
    }
}
