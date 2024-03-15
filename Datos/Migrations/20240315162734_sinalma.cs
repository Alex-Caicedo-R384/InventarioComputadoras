using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioComputadoras.Datos.Migrations
{
    /// <inheritdoc />
    public partial class sinalma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Almacenamiento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Almacenamiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComputadoraId = table.Column<int>(type: "int", nullable: false),
                    AlmacenamientoCapacidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlmacenamientoMarca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlmacenamientoNumeroParte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlmacenamientoNumeroSerie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlmacenamientoTipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
