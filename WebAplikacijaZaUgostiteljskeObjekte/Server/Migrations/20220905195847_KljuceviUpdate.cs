using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Migrations
{
    public partial class KljuceviUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komentari_Korisnici_UserId",
                table: "Komentari");

            migrationBuilder.DropColumn(
                name: "SlikaUrl",
                table: "Jela");

            migrationBuilder.RenameColumn(
                name: "UgostiteljskiObjektiId",
                table: "Pica",
                newName: "UgostiteljskiObjektiIddUgostiteljskiObjektiId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Ocjene",
                newName: "UserIddUserId");

            migrationBuilder.RenameColumn(
                name: "UgostiteljskiObjektiId",
                table: "Ocjene",
                newName: "UgostiteljskiObjektiIddUgostiteljskiObjektiId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Komentari",
                newName: "UserIddUserId");

            migrationBuilder.RenameColumn(
                name: "UgostiteljskiObjektId",
                table: "Komentari",
                newName: "UgostiteljskiObjektIddUgostiteljskiObjektiId");

            migrationBuilder.RenameIndex(
                name: "IX_Komentari_UserId",
                table: "Komentari",
                newName: "IX_Komentari_UserIddUserId");

            migrationBuilder.RenameColumn(
                name: "UgostiteljskiObjektiId",
                table: "Jela",
                newName: "UgostiteljskiObjektiIddUgostiteljskiObjektiId");

            migrationBuilder.AddColumn<string>(
                name: "UgostiteljskiObjektiRadnoVrijeme",
                table: "UgostiteljskiObjekti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UgostiteljskiObjektiRadnoVrijemeNed",
                table: "UgostiteljskiObjekti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UgostiteljskiObjektiRadnoVrijemePraznici",
                table: "UgostiteljskiObjekti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UgostiteljskiObjektiRadnoVrijemeSub",
                table: "UgostiteljskiObjekti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Pica_UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Pica",
                column: "UgostiteljskiObjektiIddUgostiteljskiObjektiId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Ocjene",
                column: "UgostiteljskiObjektiIddUgostiteljskiObjektiId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_UserIddUserId",
                table: "Ocjene",
                column: "UserIddUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Komentari_UgostiteljskiObjektIddUgostiteljskiObjektiId",
                table: "Komentari",
                column: "UgostiteljskiObjektIddUgostiteljskiObjektiId");

            migrationBuilder.CreateIndex(
                name: "IX_Jela_UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Jela",
                column: "UgostiteljskiObjektiIddUgostiteljskiObjektiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jela_UgostiteljskiObjekti_UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Jela",
                column: "UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                principalTable: "UgostiteljskiObjekti",
                principalColumn: "UgostiteljskiObjektiId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Komentari_Korisnici_UserIddUserId",
                table: "Komentari",
                column: "UserIddUserId",
                principalTable: "Korisnici",
                principalColumn: "UserId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jela_UgostiteljskiObjekti_UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Jela");

            migrationBuilder.DropForeignKey(
                name: "FK_Komentari_Korisnici_UserIddUserId",
                table: "Komentari");

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

            migrationBuilder.DropIndex(
                name: "IX_Pica_UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Pica");

            migrationBuilder.DropIndex(
                name: "IX_Ocjene_UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Ocjene");

            migrationBuilder.DropIndex(
                name: "IX_Ocjene_UserIddUserId",
                table: "Ocjene");

            migrationBuilder.DropIndex(
                name: "IX_Komentari_UgostiteljskiObjektIddUgostiteljskiObjektiId",
                table: "Komentari");

            migrationBuilder.DropIndex(
                name: "IX_Jela_UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Jela");

            migrationBuilder.DropColumn(
                name: "UgostiteljskiObjektiRadnoVrijeme",
                table: "UgostiteljskiObjekti");

            migrationBuilder.DropColumn(
                name: "UgostiteljskiObjektiRadnoVrijemeNed",
                table: "UgostiteljskiObjekti");

            migrationBuilder.DropColumn(
                name: "UgostiteljskiObjektiRadnoVrijemePraznici",
                table: "UgostiteljskiObjekti");

            migrationBuilder.DropColumn(
                name: "UgostiteljskiObjektiRadnoVrijemeSub",
                table: "UgostiteljskiObjekti");

            migrationBuilder.RenameColumn(
                name: "UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Pica",
                newName: "UgostiteljskiObjektiId");

            migrationBuilder.RenameColumn(
                name: "UserIddUserId",
                table: "Ocjene",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Ocjene",
                newName: "UgostiteljskiObjektiId");

            migrationBuilder.RenameColumn(
                name: "UserIddUserId",
                table: "Komentari",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UgostiteljskiObjektIddUgostiteljskiObjektiId",
                table: "Komentari",
                newName: "UgostiteljskiObjektId");

            migrationBuilder.RenameIndex(
                name: "IX_Komentari_UserIddUserId",
                table: "Komentari",
                newName: "IX_Komentari_UserId");

            migrationBuilder.RenameColumn(
                name: "UgostiteljskiObjektiIddUgostiteljskiObjektiId",
                table: "Jela",
                newName: "UgostiteljskiObjektiId");

            migrationBuilder.AddColumn<string>(
                name: "SlikaUrl",
                table: "Jela",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Komentari_Korisnici_UserId",
                table: "Komentari",
                column: "UserId",
                principalTable: "Korisnici",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
