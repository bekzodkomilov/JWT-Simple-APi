using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentLibrary.Migrations
{
    public partial class initilacreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "studentHashes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentHashes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentHashes_Username",
                table: "studentHashes",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentHashes");
        }
    }
}
