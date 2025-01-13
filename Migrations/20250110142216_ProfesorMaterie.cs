using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Profesori_Meditatii.Migrations
{
    /// <inheritdoc />
    public partial class ProfesorMaterie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfesorMaterie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfesorID = table.Column<int>(type: "int", nullable: false),
                    MaterieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesorMaterie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProfesorMaterie_Materie_MaterieID",
                        column: x => x.MaterieID,
                        principalTable: "Materie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfesorMaterie_Profesor_ProfesorID",
                        column: x => x.ProfesorID,
                        principalTable: "Profesor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfesorMaterie_MaterieID",
                table: "ProfesorMaterie",
                column: "MaterieID");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesorMaterie_ProfesorID",
                table: "ProfesorMaterie",
                column: "ProfesorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfesorMaterie");
        }
    }
}
