using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Migrations
{
    public partial class PdfUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UgostiteljskiObjektiPdfPutanja",
                table: "UgostiteljskiObjekti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UgostiteljskiObjektiIdBug",
                table: "PrijavljeniBugovi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserOIB",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PrijavljeniBugovi_UgostiteljskiObjektiIdBug",
                table: "PrijavljeniBugovi",
                column: "UgostiteljskiObjektiIdBug");

            migrationBuilder.AddForeignKey(
                name: "FK_PrijavljeniBugovi_UgostiteljskiObjekti_UgostiteljskiObjektiIdBug",
                table: "PrijavljeniBugovi",
                column: "UgostiteljskiObjektiIdBug",
                principalTable: "UgostiteljskiObjekti",
                principalColumn: "UgostiteljskiObjektiId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrijavljeniBugovi_UgostiteljskiObjekti_UgostiteljskiObjektiIdBug",
                table: "PrijavljeniBugovi");

            migrationBuilder.DropIndex(
                name: "IX_PrijavljeniBugovi_UgostiteljskiObjektiIdBug",
                table: "PrijavljeniBugovi");

            migrationBuilder.DropColumn(
                name: "UgostiteljskiObjektiPdfPutanja",
                table: "UgostiteljskiObjekti");

            migrationBuilder.DropColumn(
                name: "UgostiteljskiObjektiIdBug",
                table: "PrijavljeniBugovi");

            migrationBuilder.DropColumn(
                name: "UserOIB",
                table: "Korisnici");
        }
    }
}
