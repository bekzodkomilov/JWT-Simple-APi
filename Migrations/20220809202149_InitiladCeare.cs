using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentLibrary.Migrations
{
    public partial class InitiladCeare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Students",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_Username",
                table: "Students",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_Username",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Students");
        }
    }
}
