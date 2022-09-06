using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Migrations
{
    public partial class BugUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PrijavljeniBugovi");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "PrijavljeniBugovi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "PrijavljeniBugovi");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PrijavljeniBugovi",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
