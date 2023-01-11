using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    public partial class AddUserToTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Titles",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Titles_UserId",
                table: "Titles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_AspNetUsers_UserId",
                table: "Titles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Titles_AspNetUsers_UserId",
                table: "Titles");

            migrationBuilder.DropIndex(
                name: "IX_Titles_UserId",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Titles");
        }
    }
}
