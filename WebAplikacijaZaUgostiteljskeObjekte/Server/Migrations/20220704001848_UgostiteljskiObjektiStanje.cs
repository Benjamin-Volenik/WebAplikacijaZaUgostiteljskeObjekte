using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Migrations
{
    public partial class UgostiteljskiObjektiStanje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UgostiteljskiObjektiStanje",
                table: "UgostiteljskiObjekti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UgostiteljskiObjektiStanje",
                table: "UgostiteljskiObjekti");
        }
    }
}
