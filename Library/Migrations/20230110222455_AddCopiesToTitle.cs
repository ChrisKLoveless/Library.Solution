using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    public partial class AddCopiesToTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copies_Titles_TitleId",
                table: "Copies");

            migrationBuilder.DropIndex(
                name: "IX_Copies_TitleId",
                table: "Copies");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "Copies");

            migrationBuilder.AddColumn<int>(
                name: "Copies",
                table: "Titles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Copies",
                table: "Titles");

            migrationBuilder.AddColumn<int>(
                name: "TitleId",
                table: "Copies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Copies_TitleId",
                table: "Copies",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Copies_Titles_TitleId",
                table: "Copies",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "TitleId");
        }
    }
}
