using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _2026web3.Migrations
{
    /// <inheritdoc />
    public partial class CompletarCrudPersonas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incripcion_Materia_MateriasId",
                table: "Incripcion");

            migrationBuilder.DropForeignKey(
                name: "FK_Incripcion_Personas_PersonasId",
                table: "Incripcion");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Pais_paisId",
                table: "Personas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Incripcion",
                table: "Incripcion");

            migrationBuilder.RenameTable(
                name: "Incripcion",
                newName: "Inscripcion");

            migrationBuilder.RenameIndex(
                name: "IX_Incripcion_PersonasId",
                table: "Inscripcion",
                newName: "IX_Inscripcion_PersonasId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Personas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Pasaporte",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pais",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Materia",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inscripcion",
                table: "Inscripcion",
                columns: new[] { "MateriasId", "PersonasId" });

            migrationBuilder.InsertData(
                table: "Materia",
                columns: new[] { "Id", "Creditos", "Name" },
                values: new object[,]
                {
                    { 1, 4, "Programación Web" },
                    { 2, 4, "Base de Datos" },
                    { 3, 3, "Ingeniería de Software" },
                    { 4, 3, "Redes" }
                });

            migrationBuilder.InsertData(
                table: "Pais",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bolivia" },
                    { 2, "Argentina" },
                    { 3, "Brasil" },
                    { 4, "Chile" },
                    { 5, "Perú" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pasaporte_Numero",
                table: "Pasaporte",
                column: "Numero",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripcion_Materia_MateriasId",
                table: "Inscripcion",
                column: "MateriasId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripcion_Personas_PersonasId",
                table: "Inscripcion",
                column: "PersonasId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Pais_paisId",
                table: "Personas",
                column: "paisId",
                principalTable: "Pais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscripcion_Materia_MateriasId",
                table: "Inscripcion");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripcion_Personas_PersonasId",
                table: "Inscripcion");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Pais_paisId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Pasaporte_Numero",
                table: "Pasaporte");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inscripcion",
                table: "Inscripcion");

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pais",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pais",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pais",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pais",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pais",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.RenameTable(
                name: "Inscripcion",
                newName: "Incripcion");

            migrationBuilder.RenameIndex(
                name: "IX_Inscripcion_PersonasId",
                table: "Incripcion",
                newName: "IX_Incripcion_PersonasId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Pasaporte",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pais",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Materia",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Incripcion",
                table: "Incripcion",
                columns: new[] { "MateriasId", "PersonasId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Incripcion_Materia_MateriasId",
                table: "Incripcion",
                column: "MateriasId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incripcion_Personas_PersonasId",
                table: "Incripcion",
                column: "PersonasId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Pais_paisId",
                table: "Personas",
                column: "paisId",
                principalTable: "Pais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
