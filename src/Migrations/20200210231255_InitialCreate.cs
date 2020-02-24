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
                    Id = table.Column<string>(nullable: false),
                    NombreTipo = table.Column<string>(maxLength: 20, nullable: false),
                    ClaveTipoArchivo = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C_TIPOARCHIVO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_ARCHIVO",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IdCredito = table.Column<string>(maxLength: 10, nullable: false),
                    Titulo = table.Column<string>(maxLength: 150, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: true),
                    IdTipoArchivo = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(maxLength: 100, nullable: true),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ARCHIVO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_ARCHIVO_C_TIPOARCHIVO_IdTipoArchivo",
                        column: x => x.IdTipoArchivo,
                        principalTable: "C_TIPOARCHIVO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_ARCHIVO_IdTipoArchivo",
                table: "T_ARCHIVO",
                column: "IdTipoArchivo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_ARCHIVO");

            migrationBuilder.DropTable(
                name: "C_TIPOARCHIVO");
        }
    }
}
