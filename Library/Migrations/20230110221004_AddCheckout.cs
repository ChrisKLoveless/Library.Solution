using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    public partial class AddCheckout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copies_Titles_TitleId",
                table: "Copies");

            migrationBuilder.AlterColumn<int>(
                name: "TitleId",
                table: "Copies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AuthorTitleId",
                table: "Copies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Copies_AuthorTitleId",
                table: "Copies",
                column: "AuthorTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Copies_AuthorTitles_AuthorTitleId",
                table: "Copies",
                column: "AuthorTitleId",
                principalTable: "AuthorTitles",
                principalColumn: "AuthorTitleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Copies_Titles_TitleId",
                table: "Copies",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "TitleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copies_AuthorTitles_AuthorTitleId",
                table: "Copies");

            migrationBuilder.DropForeignKey(
                name: "FK_Copies_Titles_TitleId",
                table: "Copies");

            migrationBuilder.DropIndex(
                name: "IX_Copies_AuthorTitleId",
                table: "Copies");

            migrationBuilder.DropColumn(
                name: "AuthorTitleId",
                table: "Copies");

            migrationBuilder.AlterColumn<int>(
                name: "TitleId",
                table: "Copies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Copies_Titles_TitleId",
                table: "Copies",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "TitleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
