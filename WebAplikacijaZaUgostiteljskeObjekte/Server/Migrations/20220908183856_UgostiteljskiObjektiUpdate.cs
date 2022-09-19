using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Migrations
{
    public partial class UgostiteljskiObjektiUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UgostiteljskiObjektiOIB",
                table: "UgostiteljskiObjekti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UgostiteljskiObjektiVlasnik",
                table: "UgostiteljskiObjekti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UgostiteljskiObjektiOIB",
                table: "UgostiteljskiObjekti");

            migrationBuilder.DropColumn(
                name: "UgostiteljskiObjektiVlasnik",
                table: "UgostiteljskiObjekti");
        }
    }
}
