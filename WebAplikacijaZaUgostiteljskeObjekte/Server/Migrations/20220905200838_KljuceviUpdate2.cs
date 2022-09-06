using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Migrations
{
    public partial class KljuceviUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jela_UgostiteljskiObjekti_UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Jela");

            migrationBuilder.DropForeignKey(
                name: "FK_Komentari_UgostiteljskiObjekti_UgostiteljskiObjektIddUgostiteljskiObjektiId",
                table: "Komentari");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocjene_Korisnici_UserIddUserId",
                table: "Ocjene");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocjene_UgostiteljskiObjekti_UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Ocjene");

            migrationBuilder.DropForeignKey(
                name: "FK_Pica_UgostiteljskiObjekti_UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Pica");

            migrationBuilder.RenameColumn(
                name: "UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Pica",
                newName: "UgostiteljskiObjektiId");

            migrationBuilder.RenameIndex(
                name: "IX_Pica_UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Pica",
                newName: "IX_Pica_UgostiteljskiObjektiId");

            migrationBuilder.RenameColumn(
                name: "UserIddUserId",
                table: "Ocjene",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Ocjene",
                newName: "UgostiteljskiObjektiId");

            migrationBuilder.RenameIndex(
                name: "IX_Ocjene_UserIddUserId",
                table: "Ocjene",
                newName: "IX_Ocjene_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ocjene_UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Ocjene",
                newName: "IX_Ocjene_UgostiteljskiObjektiId");

            migrationBuilder.RenameColumn(
                name: "UgostiteljskiObjektIddUgostiteljskiObjektiId",
                table: "Komentari",
                newName: "UgostiteljskiObjektiId");

            migrationBuilder.RenameIndex(
                name: "IX_Komentari_UgostiteljskiObjektIddUgostiteljskiObjektiId",
                table: "Komentari",
                newName: "IX_Komentari_UgostiteljskiObjektiId");

            migrationBuilder.RenameColumn(
                name: "UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Jela",
                newName: "UgostiteljskiObjektiId");

            migrationBuilder.RenameIndex(
                name: "IX_Jela_UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Jela",
                newName: "IX_Jela_UgostiteljskiObjektiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jela_UgostiteljskiObjekti_UgostiteljskiObjektiId",
                table: "Jela",
                column: "UgostiteljskiObjektiId",
                principalTable: "UgostiteljskiObjekti",
                principalColumn: "UgostiteljskiObjektiId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Komentari_UgostiteljskiObjekti_UgostiteljskiObjektiId",
                table: "Komentari",
                column: "UgostiteljskiObjektiId",
                principalTable: "UgostiteljskiObjekti",
                principalColumn: "UgostiteljskiObjektiId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocjene_Korisnici_UserId",
                table: "Ocjene",
                column: "UserId",
                principalTable: "Korisnici",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocjene_UgostiteljskiObjekti_UgostiteljskiObjektiId",
                table: "Ocjene",
                column: "UgostiteljskiObjektiId",
                principalTable: "UgostiteljskiObjekti",
                principalColumn: "UgostiteljskiObjektiId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pica_UgostiteljskiObjekti_UgostiteljskiObjektiId",
                table: "Pica",
                column: "UgostiteljskiObjektiId",
                principalTable: "UgostiteljskiObjekti",
                principalColumn: "UgostiteljskiObjektiId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jela_UgostiteljskiObjekti_UgostiteljskiObjektiId",
                table: "Jela");

            migrationBuilder.DropForeignKey(
                name: "FK_Komentari_UgostiteljskiObjekti_UgostiteljskiObjektiId",
                table: "Komentari");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocjene_Korisnici_UserId",
                table: "Ocjene");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocjene_UgostiteljskiObjekti_UgostiteljskiObjektiId",
                table: "Ocjene");

            migrationBuilder.DropForeignKey(
                name: "FK_Pica_UgostiteljskiObjekti_UgostiteljskiObjektiId",
                table: "Pica");

            migrationBuilder.RenameColumn(
                name: "UgostiteljskiObjektiId",
                table: "Pica",
                newName: "UgostiteljskiObjektiIddUgostiteljskiObjektiId");

            migrationBuilder.RenameIndex(
                name: "IX_Pica_UgostiteljskiObjektiId",
                table: "Pica",
                newName: "IX_Pica_UgostiteljskiObjektiIddUgostiteljskiObjektiId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Ocjene",
                newName: "UserIddUserId");

            migrationBuilder.RenameColumn(
                name: "UgostiteljskiObjektiId",
                table: "Ocjene",
                newName: "UgostiteljskiObjektiIddUgostiteljskiObjektiId");

            migrationBuilder.RenameIndex(
                name: "IX_Ocjene_UserId",
                table: "Ocjene",
                newName: "IX_Ocjene_UserIddUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ocjene_UgostiteljskiObjektiId",
                table: "Ocjene",
                newName: "IX_Ocjene_UgostiteljskiObjektiIddUgostiteljskiObjektiId");

            migrationBuilder.RenameColumn(
                name: "UgostiteljskiObjektiId",
                table: "Komentari",
                newName: "UgostiteljskiObjektIddUgostiteljskiObjektiId");

            migrationBuilder.RenameIndex(
                name: "IX_Komentari_UgostiteljskiObjektiId",
                table: "Komentari",
                newName: "IX_Komentari_UgostiteljskiObjektIddUgostiteljskiObjektiId");

            migrationBuilder.RenameColumn(
                name: "UgostiteljskiObjektiId",
                table: "Jela",
                newName: "UgostiteljskiObjektiIddUgostiteljskiObjektiId");

            migrationBuilder.RenameIndex(
                name: "IX_Jela_UgostiteljskiObjektiId",
                table: "Jela",
                newName: "IX_Jela_UgostiteljskiObjektiIddUgostiteljskiObjektiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jela_UgostiteljskiObjekti_UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Jela",
                column: "UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                principalTable: "UgostiteljskiObjekti",
                principalColumn: "UgostiteljskiObjektiId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Komentari_UgostiteljskiObjekti_UgostiteljskiObjektIddUgostiteljskiObjektiId",
                table: "Komentari",
                column: "UgostiteljskiObjektIddUgostiteljskiObjektiId",
                principalTable: "UgostiteljskiObjekti",
                principalColumn: "UgostiteljskiObjektiId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocjene_Korisnici_UserIddUserId",
                table: "Ocjene",
                column: "UserIddUserId",
                principalTable: "Korisnici",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocjene_UgostiteljskiObjekti_UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Ocjene",
                column: "UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                principalTable: "UgostiteljskiObjekti",
                principalColumn: "UgostiteljskiObjektiId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pica_UgostiteljskiObjekti_UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Pica",
                column: "UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                principalTable: "UgostiteljskiObjekti",
                principalColumn: "UgostiteljskiObjektiId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
