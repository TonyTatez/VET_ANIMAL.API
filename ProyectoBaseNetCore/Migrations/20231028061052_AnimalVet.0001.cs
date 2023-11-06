using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoBaseNetCore.Migrations
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
                name: "Catalogs",
                schema: "CAT",
                columns: table => new
                {
                    IdCatalog = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.IdCatalog);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                schema: "CAT",
                columns: table => new
                {
                    IdCliente = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
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
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Codigos",
                schema: "CAT",
                columns: table => new
                {
                    IdCodigosSecuencia = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimoNumero = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Codigos", x => x.IdCodigosSecuencia);
                });

            migrationBuilder.CreateTable(
                name: "Enfermedad",
                schema: "CAT",
                columns: table => new
                {
                    IdEnfermedad = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoEnfermedads = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Enfermedad", x => x.IdEnfermedad);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                schema: "CAT",
                columns: table => new
                {
                    IdForm = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.IdForm);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTypes",
                schema: "CAT",
                columns: table => new
                {
                    IdQuestionType = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTypes", x => x.IdQuestionType);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "SEG",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                schema: "CAT",
                columns: table => new
                {
                    IdSection = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.IdSection);
                });

            migrationBuilder.CreateTable(
                name: "Sintomas",
                schema: "CAT",
                columns: table => new
                {
                    IdSintoma = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Sintomas", x => x.IdSintoma);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "SEG",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bloqueo = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "CAT",
                columns: table => new
                {
                    IdItem = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatalogIdCatalog = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.IdItem);
                    table.ForeignKey(
                        name: "FK_Items_Catalogs_CatalogIdCatalog",
                        column: x => x.CatalogIdCatalog,
                        principalSchema: "CAT",
                        principalTable: "Catalogs",
                        principalColumn: "IdCatalog");
                });

            migrationBuilder.CreateTable(
                name: "Mascotas",
                schema: "CAT",
                columns: table => new
                {
                    IdMascota = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMascota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Raza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCliente = table.Column<long>(type: "bigint", nullable: false),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoEnfermedad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConteoDiagnosticoTipos = table.Column<int>(type: "int", nullable: false),
                    IdEnfermedad = table.Column<long>(type: "bigint", nullable: true),
                    EnfermedadIdEnfermedad = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_TipoEnfermedad", x => x.IdTipoEnfermedad);
                    table.ForeignKey(
                        name: "FK_TipoEnfermedad_Enfermedad_EnfermedadIdEnfermedad",
                        column: x => x.EnfermedadIdEnfermedad,
                        principalSchema: "CAT",
                        principalTable: "Enfermedad",
                        principalColumn: "IdEnfermedad");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                schema: "CAT",
                columns: table => new
                {
                    IdQuestion = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Placeholder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdQuestionType = table.Column<long>(type: "bigint", nullable: false),
                    IdCatalog = table.Column<long>(type: "bigint", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    IsMultiAnswer = table.Column<bool>(type: "bit", nullable: false),
                    MinAnswersCount = table.Column<int>(type: "int", nullable: false),
                    MaxAnswersCount = table.Column<int>(type: "int", nullable: false),
                    MinRequiredAnswersCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.IdQuestion);
                    table.ForeignKey(
                        name: "FK_Questions_Catalogs_IdCatalog",
                        column: x => x.IdCatalog,
                        principalSchema: "CAT",
                        principalTable: "Catalogs",
                        principalColumn: "IdCatalog");
                    table.ForeignKey(
                        name: "FK_Questions_QuestionTypes_IdQuestionType",
                        column: x => x.IdQuestionType,
                        principalSchema: "CAT",
                        principalTable: "QuestionTypes",
                        principalColumn: "IdQuestionType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                schema: "SEG",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "CatalogItems",
                schema: "CAT",
                columns: table => new
                {
                    IdCatalogItem = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCatalog = table.Column<long>(type: "bigint", nullable: false),
                    IdItem = table.Column<long>(type: "bigint", nullable: false),
                    CatalogOrder = table.Column<int>(type: "int", nullable: false),
                    ItemOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItems", x => x.IdCatalogItem);
                    table.ForeignKey(
                        name: "FK_CatalogItems_Catalogs_IdCatalog",
                        column: x => x.IdCatalog,
                        principalSchema: "CAT",
                        principalTable: "Catalogs",
                        principalColumn: "IdCatalog",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogItems_Items_IdItem",
                        column: x => x.IdItem,
                        principalSchema: "CAT",
                        principalTable: "Items",
                        principalColumn: "IdItem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormSectionQuestions",
                schema: "CAT",
                columns: table => new
                {
                    IdFormSectionQuestion = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdForm = table.Column<long>(type: "bigint", nullable: false),
                    IdSection = table.Column<long>(type: "bigint", nullable: false),
                    IdQuestion = table.Column<long>(type: "bigint", nullable: false),
                    FormOrder = table.Column<int>(type: "int", nullable: false),
                    SectionOrder = table.Column<int>(type: "int", nullable: false),
                    QuestionOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormSectionQuestions", x => x.IdFormSectionQuestion);
                    table.ForeignKey(
                        name: "FK_FormSectionQuestions_Forms_IdForm",
                        column: x => x.IdForm,
                        principalSchema: "CAT",
                        principalTable: "Forms",
                        principalColumn: "IdForm",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormSectionQuestions_Questions_IdQuestion",
                        column: x => x.IdQuestion,
                        principalSchema: "CAT",
                        principalTable: "Questions",
                        principalColumn: "IdQuestion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormSectionQuestions_Sections_IdSection",
                        column: x => x.IdSection,
                        principalSchema: "CAT",
                        principalTable: "Sections",
                        principalColumn: "IdSection",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FichaDetalle",
                schema: "DET",
                columns: table => new
                {
                    IdDetalle = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFicha = table.Column<long>(type: "bigint", nullable: false),
                    IdSintoma = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_FichaDetalle", x => x.IdDetalle);
                    table.ForeignKey(
                        name: "FK_FichaDetalle_Sintomas_IdSintoma",
                        column: x => x.IdSintoma,
                        principalSchema: "CAT",
                        principalTable: "Sintomas",
                        principalColumn: "IdSintoma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FichaSintoma",
                schema: "DET",
                columns: table => new
                {
                    IdFicha = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoFicha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoriaClinicaIdHistoriaClinica = table.Column<long>(type: "bigint", nullable: true),
                    ResultadoIdResultado = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_FichaSintoma", x => x.IdFicha);
                });

            migrationBuilder.CreateTable(
                name: "Resultado",
                schema: "DET",
                columns: table => new
                {
                    IdResultado = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFicha = table.Column<long>(type: "bigint", nullable: true),
                    FichaSintomaIdFicha = table.Column<long>(type: "bigint", nullable: true),
                    FechaResultado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Resultados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEnfermedad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnfermedadIdEnfermedad = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_Resultado", x => x.IdResultado);
                    table.ForeignKey(
                        name: "FK_Resultado_Enfermedad_EnfermedadIdEnfermedad",
                        column: x => x.EnfermedadIdEnfermedad,
                        principalSchema: "CAT",
                        principalTable: "Enfermedad",
                        principalColumn: "IdEnfermedad");
                    table.ForeignKey(
                        name: "FK_Resultado_FichaSintoma_FichaSintomaIdFicha",
                        column: x => x.FichaSintomaIdFicha,
                        principalSchema: "DET",
                        principalTable: "FichaSintoma",
                        principalColumn: "IdFicha");
                });

            migrationBuilder.CreateTable(
                name: "HistoriaClinica",
                schema: "DET",
                columns: table => new
                {
                    IdHistoriaClinica = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoHistorial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMascotas = table.Column<long>(type: "bigint", nullable: false),
                    ResultadoIdResultado = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_HistoriaClinica", x => x.IdHistoriaClinica);
                    table.ForeignKey(
                        name: "FK_HistoriaClinica_Mascotas_IdMascotas",
                        column: x => x.IdMascotas,
                        principalSchema: "CAT",
                        principalTable: "Mascotas",
                        principalColumn: "IdMascota",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoriaClinica_Resultado_ResultadoIdResultado",
                        column: x => x.ResultadoIdResultado,
                        principalSchema: "DET",
                        principalTable: "Resultado",
                        principalColumn: "IdResultado");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_IdCatalog",
                schema: "CAT",
                table: "CatalogItems",
                column: "IdCatalog");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_IdItem",
                schema: "CAT",
                table: "CatalogItems",
                column: "IdItem");

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
                name: "IX_FichaSintoma_ResultadoIdResultado",
                schema: "DET",
                table: "FichaSintoma",
                column: "ResultadoIdResultado");

            migrationBuilder.CreateIndex(
                name: "IX_FormSectionQuestions_IdForm",
                schema: "CAT",
                table: "FormSectionQuestions",
                column: "IdForm");

            migrationBuilder.CreateIndex(
                name: "IX_FormSectionQuestions_IdQuestion",
                schema: "CAT",
                table: "FormSectionQuestions",
                column: "IdQuestion");

            migrationBuilder.CreateIndex(
                name: "IX_FormSectionQuestions_IdSection",
                schema: "CAT",
                table: "FormSectionQuestions",
                column: "IdSection");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaClinica_IdMascotas",
                schema: "DET",
                table: "HistoriaClinica",
                column: "IdMascotas");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaClinica_ResultadoIdResultado",
                schema: "DET",
                table: "HistoriaClinica",
                column: "ResultadoIdResultado");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CatalogIdCatalog",
                schema: "CAT",
                table: "Items",
                column: "CatalogIdCatalog");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_IdCliente",
                schema: "CAT",
                table: "Mascotas",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_IdCatalog",
                schema: "CAT",
                table: "Questions",
                column: "IdCatalog");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_IdQuestionType",
                schema: "CAT",
                table: "Questions",
                column: "IdQuestionType");

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
                name: "RoleNameIndex",
                schema: "SEG",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_FichaDetalle_FichaSintoma_IdFicha",
                schema: "DET",
                table: "FichaDetalle",
                column: "IdFicha",
                principalSchema: "DET",
                principalTable: "FichaSintoma",
                principalColumn: "IdFicha",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FichaSintoma_HistoriaClinica_HistoriaClinicaIdHistoriaClinica",
                schema: "DET",
                table: "FichaSintoma",
                column: "HistoriaClinicaIdHistoriaClinica",
                principalSchema: "DET",
                principalTable: "HistoriaClinica",
                principalColumn: "IdHistoriaClinica");

            migrationBuilder.AddForeignKey(
                name: "FK_FichaSintoma_Resultado_ResultadoIdResultado",
                schema: "DET",
                table: "FichaSintoma",
                column: "ResultadoIdResultado",
                principalSchema: "DET",
                principalTable: "Resultado",
                principalColumn: "IdResultado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resultado_FichaSintoma_FichaSintomaIdFicha",
                schema: "DET",
                table: "Resultado");

            migrationBuilder.DropTable(
                name: "CatalogItems",
                schema: "CAT");

            migrationBuilder.DropTable(
                name: "Codigos",
                schema: "CAT");

            migrationBuilder.DropTable(
                name: "FichaDetalle",
                schema: "DET");

            migrationBuilder.DropTable(
                name: "FormSectionQuestions",
                schema: "CAT");

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
                name: "Items",
                schema: "CAT");

            migrationBuilder.DropTable(
                name: "Sintomas",
                schema: "CAT");

            migrationBuilder.DropTable(
                name: "Forms",
                schema: "CAT");

            migrationBuilder.DropTable(
                name: "Questions",
                schema: "CAT");

            migrationBuilder.DropTable(
                name: "Sections",
                schema: "CAT");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "SEG");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "SEG");

            migrationBuilder.DropTable(
                name: "Catalogs",
                schema: "CAT");

            migrationBuilder.DropTable(
                name: "QuestionTypes",
                schema: "CAT");

            migrationBuilder.DropTable(
                name: "FichaSintoma",
                schema: "DET");

            migrationBuilder.DropTable(
                name: "HistoriaClinica",
                schema: "DET");

            migrationBuilder.DropTable(
                name: "Mascotas",
                schema: "CAT");

            migrationBuilder.DropTable(
                name: "Resultado",
                schema: "DET");

            migrationBuilder.DropTable(
                name: "Clientes",
                schema: "CAT");

            migrationBuilder.DropTable(
                name: "Enfermedad",
                schema: "CAT");
        }
    }
}
