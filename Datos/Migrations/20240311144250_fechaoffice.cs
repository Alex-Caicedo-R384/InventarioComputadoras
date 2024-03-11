using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioComputadoras.Datos.Migrations
{
    /// <inheritdoc />
    public partial class fechaoffice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FechaOffice",
                table: "Computadoras",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaOffice",
                table: "Computadoras");
        }
    }
}
