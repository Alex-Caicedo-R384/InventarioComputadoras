using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioComputadoras.Datos.Migrations
{
    /// <inheritdoc />
    public partial class Almacenamiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlmacenamientoCapacidad",
                table: "Computadoras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlmacenamientoMarca",
                table: "Computadoras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlmacenamientoModulos",
                table: "Computadoras",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlmacenamientoNumeroParte",
                table: "Computadoras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlmacenamientoNumeroSerie",
                table: "Computadoras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlmacenamientoTipo",
                table: "Computadoras",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlmacenamientoCapacidad",
                table: "Computadoras");

            migrationBuilder.DropColumn(
                name: "AlmacenamientoMarca",
                table: "Computadoras");

            migrationBuilder.DropColumn(
                name: "AlmacenamientoModulos",
                table: "Computadoras");

            migrationBuilder.DropColumn(
                name: "AlmacenamientoNumeroParte",
                table: "Computadoras");

            migrationBuilder.DropColumn(
                name: "AlmacenamientoNumeroSerie",
                table: "Computadoras");

            migrationBuilder.DropColumn(
                name: "AlmacenamientoTipo",
                table: "Computadoras");
        }
    }
}
