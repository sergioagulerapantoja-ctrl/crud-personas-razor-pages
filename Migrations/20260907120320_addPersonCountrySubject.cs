using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2026web3.Migrations
{
    /// <inheritdoc />
    public partial class addPersonCountrySubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "paisId",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creditos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Incripcion",
                columns: table => new
                {
                    MateriasId = table.Column<int>(type: "int", nullable: false),
                    PersonasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incripcion", x => new { x.MateriasId, x.PersonasId });
                    table.ForeignKey(
                        name: "FK_Incripcion_Materia_MateriasId",
                        column: x => x.MateriasId,
                        principalTable: "Materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incripcion_Personas_PersonasId",
                        column: x => x.PersonasId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_paisId",
                table: "Personas",
                column: "paisId");

            migrationBuilder.CreateIndex(
                name: "IX_Incripcion_PersonasId",
                table: "Incripcion",
                column: "PersonasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Pais_paisId",
                table: "Personas",
                column: "paisId",
                principalTable: "Pais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Pais_paisId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "Incripcion");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "Materia");

            migrationBuilder.DropIndex(
                name: "IX_Personas_paisId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "paisId",
                table: "Personas");
        }
    }
}
