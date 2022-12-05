using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharpboolflix.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameCastsToAttori : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CastContenuto");

            migrationBuilder.DropTable(
                name: "Casts");

            migrationBuilder.CreateTable(
                name: "Attori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttoreContenuto",
                columns: table => new
                {
                    AttoriId = table.Column<int>(type: "int", nullable: false),
                    ContenutiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttoreContenuto", x => new { x.AttoriId, x.ContenutiId });
                    table.ForeignKey(
                        name: "FK_AttoreContenuto_Attori_AttoriId",
                        column: x => x.AttoriId,
                        principalTable: "Attori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttoreContenuto_Contenuto_ContenutiId",
                        column: x => x.ContenutiId,
                        principalTable: "Contenuto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttoreContenuto_ContenutiId",
                table: "AttoreContenuto",
                column: "ContenutiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttoreContenuto");

            migrationBuilder.DropTable(
                name: "Attori");

            migrationBuilder.CreateTable(
                name: "Casts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CastContenuto",
                columns: table => new
                {
                    CastsId = table.Column<int>(type: "int", nullable: false),
                    ContenutiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastContenuto", x => new { x.CastsId, x.ContenutiId });
                    table.ForeignKey(
                        name: "FK_CastContenuto_Casts_CastsId",
                        column: x => x.CastsId,
                        principalTable: "Casts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CastContenuto_Contenuto_ContenutiId",
                        column: x => x.ContenutiId,
                        principalTable: "Contenuto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CastContenuto_ContenutiId",
                table: "CastContenuto",
                column: "ContenutiId");
        }
    }
}
