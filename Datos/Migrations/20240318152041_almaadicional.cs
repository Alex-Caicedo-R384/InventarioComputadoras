using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioComputadoras.Datos.Migrations
{
    /// <inheritdoc />
    public partial class almaadicional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Almacenamientos",
                newName: "TipoAlmacenamiento");

            migrationBuilder.RenameColumn(
                name: "NumeroSerie",
                table: "Almacenamientos",
                newName: "NumeroSerieAlmacenamiento");

            migrationBuilder.RenameColumn(
                name: "NumeroParte",
                table: "Almacenamientos",
                newName: "NumeroParteAlmacenamiento");

            migrationBuilder.RenameColumn(
                name: "Marca",
                table: "Almacenamientos",
                newName: "MarcaAlmacenamiento");

            migrationBuilder.RenameColumn(
                name: "Capacidad",
                table: "Almacenamientos",
                newName: "CapacidadAlmacenamiento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoAlmacenamiento",
                table: "Almacenamientos",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "NumeroSerieAlmacenamiento",
                table: "Almacenamientos",
                newName: "NumeroSerie");

            migrationBuilder.RenameColumn(
                name: "NumeroParteAlmacenamiento",
                table: "Almacenamientos",
                newName: "NumeroParte");

            migrationBuilder.RenameColumn(
                name: "MarcaAlmacenamiento",
                table: "Almacenamientos",
                newName: "Marca");

            migrationBuilder.RenameColumn(
                name: "CapacidadAlmacenamiento",
                table: "Almacenamientos",
                newName: "Capacidad");
        }
    }
}
