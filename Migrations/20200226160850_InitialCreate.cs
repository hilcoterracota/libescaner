using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace libescaner.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "C_TIPOARCHIVO",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    NombreTipo = table.Column<string>(maxLength: 20, nullable: false),
                    ClaveTipoArchivo = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C_TIPOARCHIVO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_ACREDITADO",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    NumeroLoan = table.Column<string>(maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ACREDITADO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_CLIENTE",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CLIENTE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_ARCHIVO",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    IdAcreditado = table.Column<string>(nullable: false),
                    Titulo = table.Column<string>(maxLength: 150, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: true),
                    IdTipoArchivo = table.Column<string>(nullable: true),
                    PathArchivo = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(maxLength: 100, nullable: true),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ARCHIVO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_ARCHIVO_T_ACREDITADO_IdAcreditado",
                        column: x => x.IdAcreditado,
                        principalTable: "T_ACREDITADO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_T_ARCHIVO_C_TIPOARCHIVO_IdTipoArchivo",
                        column: x => x.IdTipoArchivo,
                        principalTable: "C_TIPOARCHIVO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BRE_CREDITO",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    IdAcreditado = table.Column<string>(nullable: false),
                    IdCliente = table.Column<string>(nullable: false),
                    NumeroCredito = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRE_CREDITO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BRE_CREDITO_T_ACREDITADO_IdAcreditado",
                        column: x => x.IdAcreditado,
                        principalTable: "T_ACREDITADO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BRE_CREDITO_T_CLIENTE_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "T_CLIENTE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BRE_CREDITO_IdAcreditado",
                table: "BRE_CREDITO",
                column: "IdAcreditado");

            migrationBuilder.CreateIndex(
                name: "IX_BRE_CREDITO_IdCliente",
                table: "BRE_CREDITO",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_T_ARCHIVO_IdAcreditado",
                table: "T_ARCHIVO",
                column: "IdAcreditado");

            migrationBuilder.CreateIndex(
                name: "IX_T_ARCHIVO_IdTipoArchivo",
                table: "T_ARCHIVO",
                column: "IdTipoArchivo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BRE_CREDITO");

            migrationBuilder.DropTable(
                name: "T_ARCHIVO");

            migrationBuilder.DropTable(
                name: "T_CLIENTE");

            migrationBuilder.DropTable(
                name: "T_ACREDITADO");

            migrationBuilder.DropTable(
                name: "C_TIPOARCHIVO");
        }
    }
}
