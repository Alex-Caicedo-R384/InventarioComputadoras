using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioComputadoras.Datos.Migrations
{
    /// <inheritdoc />
    public partial class DiscoDuro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Almacenamiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlmacenamientoTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlmacenamientoCapacidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlmacenamientoMarca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlmacenamientoNumeroSerie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlmacenamientoNumeroParte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComputadoraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Almacenamiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Almacenamiento_Computadoras_ComputadoraId",
                        column: x => x.ComputadoraId,
                        principalTable: "Computadoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Almacenamiento_ComputadoraId",
                table: "Almacenamiento",
                column: "ComputadoraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Almacenamiento");
        }
    }
}
