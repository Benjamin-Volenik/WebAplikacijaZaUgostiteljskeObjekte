using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Migrations
{
    public partial class KljuceviUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komentari_Korisnici_UserIddUserId",
                table: "Komentari");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "PrijavljeniBugovi",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "UserIddUserId",
                table: "Komentari",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Komentari_UserIddUserId",
                table: "Komentari",
                newName: "IX_Komentari_UserId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PrijavljeniBugovi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PrijavljeniBugovi_UserId",
                table: "PrijavljeniBugovi",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Komentari_Korisnici_UserId",
                table: "Komentari",
                column: "UserId",
                principalTable: "Korisnici",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrijavljeniBugovi_Korisnici_UserId",
                table: "PrijavljeniBugovi",
                column: "UserId",
                principalTable: "Korisnici",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komentari_Korisnici_UserId",
                table: "Komentari");

            migrationBuilder.DropForeignKey(
                name: "FK_PrijavljeniBugovi_Korisnici_UserId",
                table: "PrijavljeniBugovi");

            migrationBuilder.DropIndex(
                name: "IX_PrijavljeniBugovi_UserId",
                table: "PrijavljeniBugovi");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PrijavljeniBugovi");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "PrijavljeniBugovi",
                newName: "UserEmail");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Komentari",
                newName: "UserIddUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Komentari_UserId",
                table: "Komentari",
                newName: "IX_Komentari_UserIddUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Komentari_Korisnici_UserIddUserId",
                table: "Komentari",
                column: "UserIddUserId",
                principalTable: "Korisnici",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
