using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioComputadoras.Datos.Migrations
{
    /// <inheritdoc />
    public partial class listadealma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Almacenamiento_Computadoras_ComputadoraId",
                table: "Almacenamiento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Almacenamiento",
                table: "Almacenamiento");

            migrationBuilder.RenameTable(
                name: "Almacenamiento",
                newName: "Almacenamientos");

            migrationBuilder.RenameIndex(
                name: "IX_Almacenamiento_ComputadoraId",
                table: "Almacenamientos",
                newName: "IX_Almacenamientos_ComputadoraId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Almacenamientos",
                table: "Almacenamientos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Almacenamientos_Computadoras_ComputadoraId",
                table: "Almacenamientos",
                column: "ComputadoraId",
                principalTable: "Computadoras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Almacenamientos_Computadoras_ComputadoraId",
                table: "Almacenamientos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Almacenamientos",
                table: "Almacenamientos");

            migrationBuilder.RenameTable(
                name: "Almacenamientos",
                newName: "Almacenamiento");

            migrationBuilder.RenameIndex(
                name: "IX_Almacenamientos_ComputadoraId",
                table: "Almacenamiento",
                newName: "IX_Almacenamiento_ComputadoraId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Almacenamiento",
                table: "Almacenamiento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Almacenamiento_Computadoras_ComputadoraId",
                table: "Almacenamiento",
                column: "ComputadoraId",
                principalTable: "Computadoras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
