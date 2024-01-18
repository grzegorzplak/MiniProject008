using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProject008.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB008 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MiniProject008_LanguageLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiniProject008_LanguageLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MiniProject008_Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiniProject008_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MiniProject008_Students_MiniProject008_LanguageLevels_LanguageLevelId",
                        column: x => x.LanguageLevelId,
                        principalTable: "MiniProject008_LanguageLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MiniProject008_Students_LanguageLevelId",
                table: "MiniProject008_Students",
                column: "LanguageLevelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MiniProject008_Students");

            migrationBuilder.DropTable(
                name: "MiniProject008_LanguageLevels");
        }
    }
}
