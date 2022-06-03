using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Migrations
{
    public partial class FullDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Korisnici",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Korisnici",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Jela",
                columns: table => new
                {
                    JelaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UgostiteljskiObjektId = table.Column<int>(type: "int", nullable: false),
                    NazivJela = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cjena = table.Column<decimal>(type: "money", nullable: false),
                    SlikaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jela", x => x.JelaId);
                });

            migrationBuilder.CreateTable(
                name: "Komentari",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UgostiteljskiObjektId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentari", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Komentari_Korisnici_UserId",
                        column: x => x.UserId,
                        principalTable: "Korisnici",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ocjene",
                columns: table => new
                {
                    OcjeneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UgostiteljskiObjektiId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ocjena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjene", x => x.OcjeneId);
                });

            migrationBuilder.CreateTable(
                name: "UgostiteljskiObjekti",
                columns: table => new
                {
                    UgostiteljskiObjektiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UgostiteljskiObjektiNaziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UgostiteljskiObjektiKontakt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UgostiteljskiObjektiEmali = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UgostiteljskiObjektiLozinka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UgostiteljskiObjektiProsjecnaOcjena = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UgostiteljskiObjekti", x => x.UgostiteljskiObjektiId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Komentari_UserId",
                table: "Komentari",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jela");

            migrationBuilder.DropTable(
                name: "Komentari");

            migrationBuilder.DropTable(
                name: "Ocjene");

            migrationBuilder.DropTable(
                name: "UgostiteljskiObjekti");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Korisnici");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Korisnici",
                newName: "UserName");
        }
    }
}
