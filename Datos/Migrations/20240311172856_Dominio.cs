using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioComputadoras.Datos.Migrations
{
    /// <inheritdoc />
    public partial class Dominio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dominio",
                table: "Computadoras",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dominio",
                table: "Computadoras");
        }
    }
}
