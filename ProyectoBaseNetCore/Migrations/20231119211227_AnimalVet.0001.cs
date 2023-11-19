using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VET_ANIMAL_API.Migrations
{
    /// <inheritdoc />
    public partial class AnimalVet0001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CAT");

            migrationBuilder.EnsureSchema(
                name: "DET");

            migrationBuilder.EnsureSchema(
                name: "SEG");

            migrationBuilder.CreateTable(
                name: "Clientes",
                schema: "CAT",
                columns: table => new
                {
                    IdCliente = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<string>(type: "text", nullable: true),
                    Identificacion = table.Column<string>(type: "text", nullable: true),
                    Nombres = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    Correo = table.Column<string>(type: "text", nullable: true),
                    Direccion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IpRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Codigos",
                schema: "CAT",
                columns: table => new
                {
                    IdCodigosSecuencia = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<string>(type: "text", nullable: true),
                    UltimoNumero = table.Column<int>(type: "integer", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IpRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Codigos", x => x.IdCodigosSecuencia);
                });

            migrationBuilder.CreateTable(
                name: "Enfermedad",
                schema: "CAT",
                columns: table => new
                {
                    IdEnfermedad = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoEnfermedad = table.Column<string>(type: "text", nullable: true),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IpRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermedad", x => x.IdEnfermedad);
                });

            migrationBuilder.CreateTable(
                name: "MotivoConsulta",
                schema: "CAT",
                columns: table => new
                {
                    IdMotivo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Destalle = table.Column<string>(type: "text", nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IpRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivoConsulta", x => x.IdMotivo);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "SEG",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sintomas",
                schema: "CAT",
                columns: table => new
                {
                    IdSintoma = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IpRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sintomas", x => x.IdSintoma);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "SEG",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Bloqueo = table.Column<bool>(type: "boolean", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mascotas",
                schema: "CAT",
                columns: table => new
                {
                    IdMascota = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<string>(type: "text", nullable: true),
                    NombreMascota = table.Column<string>(type: "text", nullable: true),
                    Raza = table.Column<string>(type: "text", nullable: true),
                    Sexo = table.Column<string>(type: "text", nullable: true),
                    Peso = table.Column<float>(type: "real", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdCliente = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IpRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascotas", x => x.IdMascota);
                    table.ForeignKey(
                        name: "FK_Mascotas_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalSchema: "CAT",
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoEnfermedad",
                schema: "CAT",
                columns: table => new
                {
                    IdTipoEnfermedad = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreTipoEnfermedad = table.Column<string>(type: "text", nullable: true),
                    ConteoDiagnosticoTipos = table.Column<int>(type: "integer", nullable: false),
                    IdEnfermedad = table.Column<long>(type: "bigint", nullable: true),
                    EnfermedadIdEnfermedad = table.Column<long>(type: "bigint", nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IpRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEnfermedad", x => x.IdTipoEnfermedad);
                    table.ForeignKey(
                        name: "FK_TipoEnfermedad_Enfermedad_EnfermedadIdEnfermedad",
                        column: x => x.EnfermedadIdEnfermedad,
                        principalSchema: "CAT",
                        principalTable: "Enfermedad",
                        principalColumn: "IdEnfermedad");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                schema: "SEG",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "SEG",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                schema: "SEG",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "SEG",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                schema: "SEG",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "SEG",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "SEG",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "SEG",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "SEG",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersToken",
                schema: "SEG",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UsersToken_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "SEG",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoriaClinica",
                schema: "DET",
                columns: table => new
                {
                    IdHistoriaClinica = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoHistorial = table.Column<string>(type: "text", nullable: true),
                    IdMascotas = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IpRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriaClinica", x => x.IdHistoriaClinica);
                    table.ForeignKey(
                        name: "FK_HistoriaClinica_Mascotas_IdMascotas",
                        column: x => x.IdMascotas,
                        principalSchema: "CAT",
                        principalTable: "Mascotas",
                        principalColumn: "IdMascota",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FichaControl",
                schema: "DET",
                columns: table => new
                {
                    IdFichaControl = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoFichaControl = table.Column<string>(type: "text", nullable: true),
                    IdHistoriaClinica = table.Column<long>(type: "bigint", nullable: false),
                    IdMotivo = table.Column<long>(type: "bigint", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    Observacion = table.Column<string>(type: "text", nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IpRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true)
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
                        principalSchema: "CAT",
                        principalTable: "MotivoConsulta",
                        principalColumn: "IdMotivo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FichaSintoma",
                schema: "DET",
                columns: table => new
                {
                    IdFicha = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoFicha = table.Column<string>(type: "text", nullable: true),
                    HistoriaClinicaIdHistoriaClinica = table.Column<long>(type: "bigint", nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IpRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaSintoma", x => x.IdFicha);
                    table.ForeignKey(
                        name: "FK_FichaSintoma_HistoriaClinica_HistoriaClinicaIdHistoriaClini~",
                        column: x => x.HistoriaClinicaIdHistoriaClinica,
                        principalSchema: "DET",
                        principalTable: "HistoriaClinica",
                        principalColumn: "IdHistoriaClinica");
                });

            migrationBuilder.CreateTable(
                name: "FichaDetalle",
                schema: "DET",
                columns: table => new
                {
                    IdDetalle = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdFicha = table.Column<long>(type: "bigint", nullable: false),
                    IdSintoma = table.Column<long>(type: "bigint", nullable: false),
                    Observacion = table.Column<string>(type: "text", nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IpRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaDetalle", x => x.IdDetalle);
                    table.ForeignKey(
                        name: "FK_FichaDetalle_FichaSintoma_IdFicha",
                        column: x => x.IdFicha,
                        principalSchema: "DET",
                        principalTable: "FichaSintoma",
                        principalColumn: "IdFicha",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FichaDetalle_Sintomas_IdSintoma",
                        column: x => x.IdSintoma,
                        principalSchema: "CAT",
                        principalTable: "Sintomas",
                        principalColumn: "IdSintoma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resultado",
                schema: "DET",
                columns: table => new
                {
                    IdResultado = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdFicha = table.Column<long>(type: "bigint", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    IdEnfermedad = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IpRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultado", x => x.IdResultado);
                    table.ForeignKey(
                        name: "FK_Resultado_Enfermedad_IdEnfermedad",
                        column: x => x.IdEnfermedad,
                        principalSchema: "CAT",
                        principalTable: "Enfermedad",
                        principalColumn: "IdEnfermedad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resultado_FichaSintoma_IdFicha",
                        column: x => x.IdFicha,
                        principalSchema: "DET",
                        principalTable: "FichaSintoma",
                        principalColumn: "IdFicha",
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

            migrationBuilder.CreateIndex(
                name: "IX_FichaDetalle_IdFicha",
                schema: "DET",
                table: "FichaDetalle",
                column: "IdFicha");

            migrationBuilder.CreateIndex(
                name: "IX_FichaDetalle_IdSintoma",
                schema: "DET",
                table: "FichaDetalle",
                column: "IdSintoma");

            migrationBuilder.CreateIndex(
                name: "IX_FichaSintoma_HistoriaClinicaIdHistoriaClinica",
                schema: "DET",
                table: "FichaSintoma",
                column: "HistoriaClinicaIdHistoriaClinica");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaClinica_IdMascotas",
                schema: "DET",
                table: "HistoriaClinica",
                column: "IdMascotas");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_IdCliente",
                schema: "CAT",
                table: "Mascotas",
                column: "IdCliente");

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

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "SEG",
                table: "Role",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                schema: "SEG",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoEnfermedad_EnfermedadIdEnfermedad",
                schema: "CAT",
                table: "TipoEnfermedad",
                column: "EnfermedadIdEnfermedad");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                schema: "SEG",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                schema: "SEG",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                schema: "SEG",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "SEG",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "SEG",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Codigos",
                schema: "CAT");

            migrationBuilder.DropTable(
                name: "FichaControl",
                schema: "DET");

            migrationBuilder.DropTable(
                name: "FichaDetalle",
                schema: "DET");

            migrationBuilder.DropTable(
                name: "Resultado",
                schema: "DET");

            migrationBuilder.DropTable(
                name: "RoleClaim",
                schema: "SEG");

            migrationBuilder.DropTable(
                name: "TipoEnfermedad",
                schema: "CAT");

            migrationBuilder.DropTable(
                name: "UserClaim",
                schema: "SEG");

            migrationBuilder.DropTable(
                name: "UserLogin",
                schema: "SEG");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "SEG");

            migrationBuilder.DropTable(
                name: "UsersToken",
                schema: "SEG");

            migrationBuilder.DropTable(
                name: "MotivoConsulta",
                schema: "CAT");

            migrationBuilder.DropTable(
                name: "Sintomas",
                schema: "CAT");

            migrationBuilder.DropTable(
                name: "FichaSintoma",
                schema: "DET");

            migrationBuilder.DropTable(
                name: "Enfermedad",
                schema: "CAT");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "SEG");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "SEG");

            migrationBuilder.DropTable(
                name: "HistoriaClinica",
                schema: "DET");

            migrationBuilder.DropTable(
                name: "Mascotas",
                schema: "CAT");

            migrationBuilder.DropTable(
                name: "Clientes",
                schema: "CAT");
        }
    }
}
