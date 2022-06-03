using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Migrations
{
    public partial class JelaUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UgostiteljskiObjektId",
                table: "Jela",
                newName: "UgostiteljskiObjektiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UgostiteljskiObjektiId",
                table: "Jela",
                newName: "UgostiteljskiObjektId");
        }
    }
}
