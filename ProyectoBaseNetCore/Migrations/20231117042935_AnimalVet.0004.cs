using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoBaseNetCore.Migrations
{
    /// <inheritdoc />
    public partial class AnimalVet0004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MotivoConsulta",
                schema: "DET",
                columns: table => new
                {
                    IdMotivo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSintoma = table.Column<long>(type: "bigint", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destalle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivoConsulta", x => x.IdMotivo);
                });

            migrationBuilder.CreateTable(
                name: "FichaControl",
                schema: "DET",
                columns: table => new
                {
                    IdFichaControl = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoFichaControl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdHistoriaClinica = table.Column<long>(type: "bigint", nullable: false),
                    IdMotivo = table.Column<long>(type: "bigint", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaControl", x => x.IdFichaControl);
                    table.ForeignKey(
                        name: "FK_FichaControl_HistoriaClinica_IdHistoriaClinica",
                        column: x => x.IdHistoriaClinica,
                        principalSchema: "DET",
                        principalTable: "HistoriaClinica",
                        principalColumn: "IdHistoriaClinica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FichaControl_MotivoConsulta_IdMotivo",
                        column: x => x.IdMotivo,
                        principalSchema: "DET",
                        principalTable: "MotivoConsulta",
                        principalColumn: "IdMotivo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FichaControl_IdHistoriaClinica",
                schema: "DET",
                table: "FichaControl",
                column: "IdHistoriaClinica");

            migrationBuilder.CreateIndex(
                name: "IX_FichaControl_IdMotivo",
                schema: "DET",
                table: "FichaControl",
                column: "IdMotivo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FichaControl",
                schema: "DET");

            migrationBuilder.DropTable(
                name: "MotivoConsulta",
                schema: "DET");
        }
    }
}
