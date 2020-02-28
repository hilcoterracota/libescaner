using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace libescaner.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "C_CATEGORIA",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    Clave = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C_CATEGORIA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_ARCHIVO",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    Titulo = table.Column<string>(maxLength: 150, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: true),
                    Identificador = table.Column<string>(maxLength: 50, nullable: false),
                    PathArchivo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ARCHIVO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BRE_ARCHIVO_CATEGORIA",
                columns: table => new
                {
                    IdArchivo = table.Column<string>(maxLength: 50, nullable: false),
                    IdCategoria = table.Column<string>(maxLength: 50, nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRE_ARCHIVO_CATEGORIA", x => new { x.IdArchivo, x.IdCategoria });
                    table.ForeignKey(
                        name: "FK_BRE_ARCHIVO_CATEGORIA_T_ARCHIVO_IdArchivo",
                        column: x => x.IdArchivo,
                        principalTable: "T_ARCHIVO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BRE_ARCHIVO_CATEGORIA_C_CATEGORIA_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "C_CATEGORIA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BRE_ARCHIVO_CATEGORIA_IdCategoria",
                table: "BRE_ARCHIVO_CATEGORIA",
                column: "IdCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BRE_ARCHIVO_CATEGORIA");

            migrationBuilder.DropTable(
                name: "T_ARCHIVO");

            migrationBuilder.DropTable(
                name: "C_CATEGORIA");
        }
    }
}
