using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoBaseNetCore.Migrations
{
    /// <inheritdoc />
    public partial class AnimalVet0002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichaSintoma_Resultado_ResultadoIdResultado",
                schema: "DET",
                table: "FichaSintoma");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoriaClinica_Resultado_ResultadoIdResultado",
                schema: "DET",
                table: "HistoriaClinica");

            migrationBuilder.DropForeignKey(
                name: "FK_Resultado_Enfermedad_EnfermedadIdEnfermedad",
                schema: "DET",
                table: "Resultado");

            migrationBuilder.DropForeignKey(
                name: "FK_Resultado_FichaSintoma_FichaSintomaIdFicha",
                schema: "DET",
                table: "Resultado");

            migrationBuilder.DropIndex(
                name: "IX_Resultado_EnfermedadIdEnfermedad",
                schema: "DET",
                table: "Resultado");

            migrationBuilder.DropIndex(
                name: "IX_Resultado_FichaSintomaIdFicha",
                schema: "DET",
                table: "Resultado");

            migrationBuilder.DropIndex(
                name: "IX_HistoriaClinica_ResultadoIdResultado",
                schema: "DET",
                table: "HistoriaClinica");

            migrationBuilder.DropIndex(
                name: "IX_FichaSintoma_ResultadoIdResultado",
                schema: "DET",
                table: "FichaSintoma");

            migrationBuilder.DropColumn(
                name: "EnfermedadIdEnfermedad",
                schema: "DET",
                table: "Resultado");

            migrationBuilder.DropColumn(
                name: "FechaResultado",
                schema: "DET",
                table: "Resultado");

            migrationBuilder.DropColumn(
                name: "FichaSintomaIdFicha",
                schema: "DET",
                table: "Resultado");

            migrationBuilder.DropColumn(
                name: "Resultados",
                schema: "DET",
                table: "Resultado");

            migrationBuilder.DropColumn(
                name: "ResultadoIdResultado",
                schema: "DET",
                table: "HistoriaClinica");

            migrationBuilder.DropColumn(
                name: "ResultadoIdResultado",
                schema: "DET",
                table: "FichaSintoma");

            migrationBuilder.RenameColumn(
                name: "CodigoEnfermedads",
                schema: "CAT",
                table: "Enfermedad",
                newName: "CodigoEnfermedad");

            migrationBuilder.AlterColumn<long>(
                name: "IdFicha",
                schema: "DET",
                table: "Resultado",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IdEnfermedad",
                schema: "DET",
                table: "Resultado",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resultado_IdEnfermedad",
                schema: "DET",
                table: "Resultado",
                column: "IdEnfermedad");

            migrationBuilder.CreateIndex(
                name: "IX_Resultado_IdFicha",
                schema: "DET",
                table: "Resultado",
                column: "IdFicha");

            migrationBuilder.AddForeignKey(
                name: "FK_Resultado_Enfermedad_IdEnfermedad",
                schema: "DET",
                table: "Resultado",
                column: "IdEnfermedad",
                principalSchema: "CAT",
                principalTable: "Enfermedad",
                principalColumn: "IdEnfermedad",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resultado_FichaSintoma_IdFicha",
                schema: "DET",
                table: "Resultado",
                column: "IdFicha",
                principalSchema: "DET",
                principalTable: "FichaSintoma",
                principalColumn: "IdFicha",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resultado_Enfermedad_IdEnfermedad",
                schema: "DET",
                table: "Resultado");

            migrationBuilder.DropForeignKey(
                name: "FK_Resultado_FichaSintoma_IdFicha",
                schema: "DET",
                table: "Resultado");

            migrationBuilder.DropIndex(
                name: "IX_Resultado_IdEnfermedad",
                schema: "DET",
                table: "Resultado");

            migrationBuilder.DropIndex(
                name: "IX_Resultado_IdFicha",
                schema: "DET",
                table: "Resultado");

            migrationBuilder.RenameColumn(
                name: "CodigoEnfermedad",
                schema: "CAT",
                table: "Enfermedad",
                newName: "CodigoEnfermedads");

            migrationBuilder.AlterColumn<long>(
                name: "IdFicha",
                schema: "DET",
                table: "Resultado",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "IdEnfermedad",
                schema: "DET",
                table: "Resultado",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "EnfermedadIdEnfermedad",
                schema: "DET",
                table: "Resultado",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaResultado",
                schema: "DET",
                table: "Resultado",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "FichaSintomaIdFicha",
                schema: "DET",
                table: "Resultado",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resultados",
                schema: "DET",
                table: "Resultado",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ResultadoIdResultado",
                schema: "DET",
                table: "HistoriaClinica",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ResultadoIdResultado",
                schema: "DET",
                table: "FichaSintoma",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resultado_EnfermedadIdEnfermedad",
                schema: "DET",
                table: "Resultado",
                column: "EnfermedadIdEnfermedad");

            migrationBuilder.CreateIndex(
                name: "IX_Resultado_FichaSintomaIdFicha",
                schema: "DET",
                table: "Resultado",
                column: "FichaSintomaIdFicha");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaClinica_ResultadoIdResultado",
                schema: "DET",
                table: "HistoriaClinica",
                column: "ResultadoIdResultado");

            migrationBuilder.CreateIndex(
                name: "IX_FichaSintoma_ResultadoIdResultado",
                schema: "DET",
                table: "FichaSintoma",
                column: "ResultadoIdResultado");

            migrationBuilder.AddForeignKey(
                name: "FK_FichaSintoma_Resultado_ResultadoIdResultado",
                schema: "DET",
                table: "FichaSintoma",
                column: "ResultadoIdResultado",
                principalSchema: "DET",
                principalTable: "Resultado",
                principalColumn: "IdResultado");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoriaClinica_Resultado_ResultadoIdResultado",
                schema: "DET",
                table: "HistoriaClinica",
                column: "ResultadoIdResultado",
                principalSchema: "DET",
                principalTable: "Resultado",
                principalColumn: "IdResultado");

            migrationBuilder.AddForeignKey(
                name: "FK_Resultado_Enfermedad_EnfermedadIdEnfermedad",
                schema: "DET",
                table: "Resultado",
                column: "EnfermedadIdEnfermedad",
                principalSchema: "CAT",
                principalTable: "Enfermedad",
                principalColumn: "IdEnfermedad");

            migrationBuilder.AddForeignKey(
                name: "FK_Resultado_FichaSintoma_FichaSintomaIdFicha",
                schema: "DET",
                table: "Resultado",
                column: "FichaSintomaIdFicha",
                principalSchema: "DET",
                principalTable: "FichaSintoma",
                principalColumn: "IdFicha");
        }
    }
}
