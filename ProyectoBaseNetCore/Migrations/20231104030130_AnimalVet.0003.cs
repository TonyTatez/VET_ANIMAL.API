using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoBaseNetCore.Migrations
{
    /// <inheritdoc />
    public partial class AnimalVet0003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Apellidos",
                schema: "CAT",
                table: "Clientes",
                newName: "Codigo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNacimiento",
                schema: "CAT",
                table: "Mascotas",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                schema: "CAT",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Peso",
                schema: "CAT",
                table: "Mascotas",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                schema: "CAT",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "Peso",
                schema: "CAT",
                table: "Mascotas");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                schema: "CAT",
                table: "Clientes",
                newName: "Apellidos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNacimiento",
                schema: "CAT",
                table: "Mascotas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
