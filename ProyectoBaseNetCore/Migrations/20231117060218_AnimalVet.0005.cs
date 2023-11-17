using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoBaseNetCore.Migrations
{
    /// <inheritdoc />
    public partial class AnimalVet0005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdSintoma",
                schema: "DET",
                table: "MotivoConsulta");

            migrationBuilder.RenameTable(
                name: "MotivoConsulta",
                schema: "DET",
                newName: "MotivoConsulta",
                newSchema: "CAT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "MotivoConsulta",
                schema: "CAT",
                newName: "MotivoConsulta",
                newSchema: "DET");

            migrationBuilder.AddColumn<long>(
                name: "IdSintoma",
                schema: "DET",
                table: "MotivoConsulta",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
