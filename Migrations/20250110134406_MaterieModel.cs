using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Profesori_Meditatii.Migrations
{
    /// <inheritdoc />
    public partial class MaterieModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaterieID",
                table: "Profesor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Materie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeMaterie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materie", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_MaterieID",
                table: "Profesor",
                column: "MaterieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesor_Materie_MaterieID",
                table: "Profesor",
                column: "MaterieID",
                principalTable: "Materie",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesor_Materie_MaterieID",
                table: "Profesor");

            migrationBuilder.DropTable(
                name: "Materie");

            migrationBuilder.DropIndex(
                name: "IX_Profesor_MaterieID",
                table: "Profesor");

            migrationBuilder.DropColumn(
                name: "MaterieID",
                table: "Profesor");
        }
    }
}
