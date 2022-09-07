using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Migrations
{
    public partial class IspravakBaze : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komentari_UgostiteljskiObjekti_UgostiteljskiObjektiId",
                table: "Komentari");

            migrationBuilder.DropForeignKey(
                name: "FK_PrijavljeniBugovi_Korisnici_UserId",
                table: "PrijavljeniBugovi");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PrijavljeniBugovi",
                newName: "UserIdBug");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "PrijavljeniBugovi",
                newName: "UserEmail");

            migrationBuilder.RenameIndex(
                name: "IX_PrijavljeniBugovi_UserId",
                table: "PrijavljeniBugovi",
                newName: "IX_PrijavljeniBugovi_UserIdBug");

            migrationBuilder.RenameColumn(
                name: "UgostiteljskiObjektiId",
                table: "Komentari",
                newName: "UgostiteljskiObjektId");

            migrationBuilder.RenameIndex(
                name: "IX_Komentari_UgostiteljskiObjektiId",
                table: "Komentari",
                newName: "IX_Komentari_UgostiteljskiObjektId");

            migrationBuilder.AddForeignKey(
                name: "FK_Komentari_UgostiteljskiObjekti_UgostiteljskiObjektId",
                table: "Komentari",
                column: "UgostiteljskiObjektId",
                principalTable: "UgostiteljskiObjekti",
                principalColumn: "UgostiteljskiObjektiId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrijavljeniBugovi_Korisnici_UserIdBug",
                table: "PrijavljeniBugovi",
                column: "UserIdBug",
                principalTable: "Korisnici",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komentari_UgostiteljskiObjekti_UgostiteljskiObjektId",
                table: "Komentari");

            migrationBuilder.DropForeignKey(
                name: "FK_PrijavljeniBugovi_Korisnici_UserIdBug",
                table: "PrijavljeniBugovi");

            migrationBuilder.RenameColumn(
                name: "UserIdBug",
                table: "PrijavljeniBugovi",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "PrijavljeniBugovi",
                newName: "Email");

            migrationBuilder.RenameIndex(
                name: "IX_PrijavljeniBugovi_UserIdBug",
                table: "PrijavljeniBugovi",
                newName: "IX_PrijavljeniBugovi_UserId");

            migrationBuilder.RenameColumn(
                name: "UgostiteljskiObjektId",
                table: "Komentari",
                newName: "UgostiteljskiObjektiId");

            migrationBuilder.RenameIndex(
                name: "IX_Komentari_UgostiteljskiObjektId",
                table: "Komentari",
                newName: "IX_Komentari_UgostiteljskiObjektiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Komentari_UgostiteljskiObjekti_UgostiteljskiObjektiId",
                table: "Komentari",
                column: "UgostiteljskiObjektiId",
                principalTable: "UgostiteljskiObjekti",
                principalColumn: "UgostiteljskiObjektiId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrijavljeniBugovi_Korisnici_UserId",
                table: "PrijavljeniBugovi",
                column: "UserId",
                principalTable: "Korisnici",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
