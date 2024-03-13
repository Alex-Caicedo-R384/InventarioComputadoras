﻿// <auto-generated />
using System;
using InventarioComputadoras.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InventarioComputadoras.Datos.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("CodigoConstitucional")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ConAntivirus")
                        .HasColumnType("bit");

                    b.Property<bool>("ConLicenciaOffice")
                        .HasColumnType("bit");

                    b.Property<bool>("ConLicenciaSO")
                        .HasColumnType("bit");

                    b.Property<string>("Departamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dominio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaAdquisicion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaOffice")
                        .HasColumnType("datetime2");

                    b.Property<string>("LicenciaAntivirus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicenciaSO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemoriaModulos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemoriaRamCapacidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemoriaRamMarca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemoriaRamNumeroParte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemoriaRamNumeroSerie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemoriaRamTipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherBoard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NParte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NSerie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreAnterior")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreNuevo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Office")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oficina")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Procesador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SinAntivirus")
                        .HasColumnType("bit");

                    b.Property<bool>("SinDireccionIP")
                        .HasColumnType("bit");

                    b.Property<bool>("SinLicenciaOffice")
                        .HasColumnType("bit");

                    b.Property<bool>("SinLicenciaSO")
                        .HasColumnType("bit");

                    b.Property<bool>("SinNombreAnterior")
                        .HasColumnType("bit");

                    b.Property<string>("SistemaOperativo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VersionAntivirus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VersionOffice")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Computadoras");
                });
#pragma warning restore 612, 618
        }
    }
}
