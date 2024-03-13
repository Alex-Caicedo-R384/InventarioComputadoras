using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioComputadoras.Datos.Migrations
{
    /// <inheritdoc />
    public partial class RAM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MemoriaRamCapacidad",
                table: "Computadoras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemoriaRamMarca",
                table: "Computadoras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemoriaRamNumeroParte",
                table: "Computadoras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemoriaRamNumeroSerie",
                table: "Computadoras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemoriaRamTipo",
                table: "Computadoras",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemoriaRamCapacidad",
                table: "Computadoras");

            migrationBuilder.DropColumn(
                name: "MemoriaRamMarca",
                table: "Computadoras");

            migrationBuilder.DropColumn(
                name: "MemoriaRamNumeroParte",
                table: "Computadoras");

            migrationBuilder.DropColumn(
                name: "MemoriaRamNumeroSerie",
                table: "Computadoras");

            migrationBuilder.DropColumn(
                name: "MemoriaRamTipo",
                table: "Computadoras");
        }
    }
}
