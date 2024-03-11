using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioComputadoras.Datos.Migrations
{
    /// <inheritdoc />
    public partial class Office : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ConLicenciaOffice",
                table: "Computadoras",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Office",
                table: "Computadoras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SinLicenciaOffice",
                table: "Computadoras",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConLicenciaOffice",
                table: "Computadoras");

            migrationBuilder.DropColumn(
                name: "Office",
                table: "Computadoras");

            migrationBuilder.DropColumn(
                name: "SinLicenciaOffice",
                table: "Computadoras");
        }
    }
}
