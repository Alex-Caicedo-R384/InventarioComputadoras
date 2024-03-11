using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioComputadoras.Datos.Migrations
{
    /// <inheritdoc />
    public partial class antivirus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ConAntivirus",
                table: "Computadoras",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LicenciaAntivirus",
                table: "Computadoras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SinAntivirus",
                table: "Computadoras",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "VersionAntivirus",
                table: "Computadoras",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConAntivirus",
                table: "Computadoras");

            migrationBuilder.DropColumn(
                name: "LicenciaAntivirus",
                table: "Computadoras");

            migrationBuilder.DropColumn(
                name: "SinAntivirus",
                table: "Computadoras");

            migrationBuilder.DropColumn(
                name: "VersionAntivirus",
                table: "Computadoras");
        }
    }
}
